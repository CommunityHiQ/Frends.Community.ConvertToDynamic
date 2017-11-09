﻿using System;
using System.Threading;
using NUnit.Framework;

namespace Frends.Community.ConvertToDynamic.Tests
{
    [TestFixture]
    public class ConvertToDynamicV2Tests
    {
        [Test]
        public void TestConvertDynamicShouldReturnValue()
        {
            var par = new ConvertData.Parameters()
            {
                Input = "<Contract><StartDate>2006-08-30T00:00:00</StartDate></Contract>",
                InputType = ConvertData.InputType.XmlString,
                OptionalRootNameWhenConvertingFromJSON = ""
            };
            var result = ConvertData.ConvertToDynamic(par, new CancellationToken());
            Assert.IsTrue(result.Result.Contract.StartDate.Contains("2006-08-30T00:00:00"));
        }

        [Test]
        public void TestConvertDynamicShouldReturnValueWithInputNamespace()
        {
            var par = new ConvertData.Parameters()
            {
                Input = "<v150:Contract xmlns:v150=\"http://schemas.forum.com/ForumService/V150\"><v150:StartDate>2006-08-30T00:00:00</v150:StartDate></v150:Contract>",
                InputType = ConvertData.InputType.XmlString,
                OptionalRootNameWhenConvertingFromJSON = ""
            };
            var result = ConvertData.ConvertToDynamic(par, new CancellationToken());
            Assert.IsTrue(result.Result.Contract.StartDate.Contains("2006-08-30T00:00:00"));
        }
        
        [Test]
        public void JsonToDyn_arr()
        {
            const string json = @"{
                            ""foo"": [
                                        {
	                                    ""asd"" : ""dsa""
                                        },
                                        {
	                                    ""aa"" : ""bb""
                                        }
                                    ]
                            }";
            var par = new ConvertData.Parameters()
            {
                Input = json,
                InputType = ConvertData.InputType.JsonString,
                OptionalRootNameWhenConvertingFromJSON = "root"
            };

            var result = ConvertData.ConvertToDynamic(par, new CancellationToken());

            Assert.IsTrue(result.Result.root.foo[1].aa == "bb");
        }

        [Test]
        public void JsonToDyn_normal()
        {
            const string json = @"{
                            ""foo1"": ""bar1"",
                            ""foo2"": ""bar2""
                            }";

            var par = new ConvertData.Parameters()
            {
                Input = json,
                InputType = ConvertData.InputType.JsonString,
                OptionalRootNameWhenConvertingFromJSON = "root"
            };

            var result = ConvertData.ConvertToDynamic(par, new CancellationToken());
            Assert.IsTrue(result.Result.root.foo1 == "bar1");
        }
    }
}
