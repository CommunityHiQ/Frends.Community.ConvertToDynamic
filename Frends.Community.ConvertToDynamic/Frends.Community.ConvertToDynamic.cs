﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using Microsoft.CSharp; // You can remove this if you don't need dynamic type in .NET Standard frends Tasks
using Newtonsoft.Json;

#pragma warning disable 1591

namespace Frends.Community.ConvertToDynamic
{
    /// <summary>
    /// Main class
    /// </summary>
    public class ConvertData
    {
        private static void ParseToDynamic(dynamic parent, XElement node, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (node.HasElements)
            {
                if (node.Elements(node.Elements().First().Name.LocalName).Count() > 1)
                {
                    var item = new ExpandoObject();
                    var list = new List<dynamic>();
                    foreach (var element in node.Elements())
                    {
                        ParseToDynamic(list, element, cancellationToken);
                    }

                    AddProperty(item, node.Elements().First().Name.LocalName, list);
                    AddProperty(parent, node.Name.ToString(), item);
                }
                else
                {
                    var item = new ExpandoObject();
                    foreach (var attribute in node.Attributes())
                    {
                        AddProperty(item, attribute.Name.LocalName, attribute.Value.Trim());
                    }
                    foreach (var element in node.Elements())
                    {
                        ParseToDynamic(item, element, cancellationToken);
                    }

                    AddProperty(parent, node.Name.LocalName, item);
                }
            }
            else
            {
                AddProperty(parent, node.Name.LocalName, node.Value.Trim());
            }
        }

        private static void AddProperty(dynamic parent, string name, object value)
        {
            if (parent is List<dynamic>)
            {
                (parent as List<dynamic>).Add(value);
            }
            else
            {
                (parent as IDictionary<string, object>)[name] = value;
            }
        }

        /// <summary>
        /// Converts the input value to dynamic type.  
        /// </summary>
        /// <param name="parameters">Contains all input parameters</param>
        /// <param name="cancellationToken"></param>
        public static Output ConvertToDynamic(Parameters parameters, CancellationToken cancellationToken)
        {
            dynamic root = new ExpandoObject();
            XDocument inputDoc;

            switch (parameters.InputType)
            {
                case InputType.XmlString:
                    inputDoc = XDocument.Parse(parameters.Input, LoadOptions.PreserveWhitespace);
                    ParseToDynamic(root, inputDoc.Elements().First(), cancellationToken);
                    return new Output { Result = root };
                case InputType.XmlDocument:
                    inputDoc = XDocument.Parse(parameters.Input.OuterXml, LoadOptions.PreserveWhitespace);
                    ParseToDynamic(root, inputDoc.Elements().First(), cancellationToken);
                    return new Output { Result = root };
                case InputType.XDocument:
                    ParseToDynamic(root, parameters.Input.Elements().First(), cancellationToken);
                    return new Output { Result = root };
                case InputType.JsonString:
                    XmlDocument xdoc;
                    if (string.IsNullOrEmpty(parameters.OptionalRootNameWhenConvertingFromJSON))
                    {
                        xdoc = JsonConvert.DeserializeXmlNode(parameters.Input);
                    }
                    else
                    {
                        xdoc = JsonConvert.DeserializeXmlNode(parameters.Input, parameters.OptionalRootNameWhenConvertingFromJSON);
                    }
                    inputDoc = XDocument.Parse(xdoc.OuterXml, LoadOptions.PreserveWhitespace);
                    ParseToDynamic(root, inputDoc.Elements().First(), cancellationToken);
                    return new Output { Result = root };
                default:
                    throw new InvalidDataException("The input data type was not recognized.");
            }
        }
    }
}
