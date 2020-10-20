#pragma warning disable 1591

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frends.Community.ConvertToDynamic
{
    /// <summary>
    /// Defines the type of the input parameter   
    /// </summary>
    public enum InputType { XmlString, XmlDocument, XDocument, JsonString }

    /// <summary>
    /// Parameter class
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// The input value that will be converted to dynamic.
        /// </summary>
        public dynamic Input { get; set; }

        /// <summary>
        /// Input value's data type
        /// </summary>
        [DisplayName("Input value's data type")]
        public InputType InputType { get; set; }

        /// <summary>
        /// If this value is given, different overload of the JsonConvert.DeserializeXmlNode method will be used.
        /// The alternative overload will add an additional root element which fixes error that occurs when the JSON has keyless array
        /// </summary>
        [DefaultValue("\"\"")]
        [DisplayFormat(DataFormatString = "Text")]
        public string OptionalRootNameWhenConvertingFromJSON { get; set; }
    }

    /// <summary>
    /// Return object
    /// </summary>
    public class Output
    {
        /// <summary>
        /// Result CSV
        /// </summary>
        public dynamic Result { get; set; }
    }
}
