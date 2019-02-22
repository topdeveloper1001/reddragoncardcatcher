//-----------------------------------------------------------------------
// <copyright file="ProtobufModelsGenerator.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using NUnit.Framework;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedDragonCardCatcher.Tests
{
    [TestFixture]
    internal class ProtobufModelsGenerator
    {
        public const string HeaderPattern = @"//-----------------------------------------------------------------------
// <copyright file=""{0}.cs"" company=""Ace Poker Solutions"">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------";

        [OneTimeSetUp]
        public void SetUp()
        {
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
        }

       // [TestCase(@"..\..\..\RedDragonCardCapturer\proto\red_dragon.proto", "Models")]
        public void Generate(string source, string destination)
        {
            FileAssert.Exists(source);

            if (Directory.Exists(destination))
            {
                Directory.Delete(destination, true);
            }

            Directory.CreateDirectory(destination);

            var lines = File.ReadAllLines(source);

            var result = new List<string>();

            ProtoWriter protoWriter = null;

            foreach (var line in lines)
            {
                var protoLine = line.Trim();

                if (protoLine.StartsWith("message ") ||
                    protoLine.StartsWith("enum "))
                {
                    protoWriter = new ProtoWriter();
                    protoWriter.ParseHeader(protoLine);
                    continue;
                }

                if (protoWriter == null)
                {
                    continue;
                }

                if (protoLine.StartsWith("}"))
                {
                    var protoModel = protoWriter.ToString();
                    result.Add(protoModel);
                    continue;
                }

                protoWriter.ParseProperty(protoLine);
            }

            CollectionAssert.IsNotEmpty(result);
        }

        private class ProtoWriter
        {
            private static readonly Dictionary<string, string> TypeMappings = new Dictionary<string, string>
            {
                ["uint32"] = "uint",
                ["string"] = "string",
                ["int64"] = "long",
                ["uint64"] = "ulong",
                ["bool"] = "bool",
                ["float"] = "double",
                ["int32"] = "int",
                ["sint32"] = "int",

            };

            public string Name { get; set; }

            public bool IsEnum { get; set; }

            public List<ProtoProperty> ProtoProperties { get; set; } = new List<ProtoProperty>();

            public List<string> EnumMembers { get; set; } = new List<string>();

            public void ParseHeader(string line)
            {
                IsEnum = line.StartsWith("enum");

                var nameStartIndex = line.IndexOf(" ") + 1;
                var nameEndIndex = line.IndexOf("{");

                Name = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(line.Substring(nameStartIndex, nameEndIndex - nameStartIndex).Trim());
            }

            public void ParseProperty(string line)
            {
                if (string.IsNullOrEmpty(line))
                {
                    return;
                }

                if (IsEnum)
                {
                    EnumMembers.Add(ToUpperFirstLetter(line.Replace(";", string.Empty)));
                    return;
                }

                // parse type
                var typeStart = line.IndexOf(" ") + 1;
                var typeEnd = line.IndexOf(" ", typeStart);
                var typeText = line.Substring(typeStart, typeEnd - typeStart);

                // parse property name
                var propertyNameStart = typeEnd + 1;
                var propertyNameEnd = line.IndexOf("=", typeEnd + 1);
                var propertyNameText = line.Substring(propertyNameStart, propertyNameEnd - propertyNameStart).Trim();
                
                // parse number
                var numberStart = propertyNameEnd + 1;
                var numberEnd = line.IndexOf(";", numberStart);
                var numberText = line.Substring(numberStart, numberEnd - numberStart).Trim();

                if (!TypeMappings.TryGetValue(typeText, out string type))
                {
                    type = ToUpperFirstLetter(typeText);
                }

                var protoProperty = new ProtoProperty
                {
                    Name = ToUpperFirstLetter(propertyNameText),
                    Number = int.Parse(numberText),
                    Type = type
                };

                ProtoProperties.Add(protoProperty);
            }

            public override string ToString()
            {
                if (IsEnum)
                {
                    return WriteEnum();
                }

                return WriteClass();
            }

            private string WriteClass()
            {
                var sb = new StringBuilder();
                sb.AppendLine(string.Format(HeaderPattern, Name));
                sb.AppendLine();
                sb.AppendLine("using ProtoBuf;");
                sb.AppendLine();
                sb.AppendLine("namespace RedDragonCardCatcher.Model");
                sb.AppendLine("{");
                sb.AppendLine("    [ProtoContract]");
                sb.AppendLine($"    internal class {Name}");
                sb.AppendLine("    {");

                for (var i = 0; i < ProtoProperties.Count; i++)
                {
                    sb.AppendLine($"        [ProtoMember({ProtoProperties[i].Number})]");
                    sb.AppendLine($"        public {ProtoProperties[i].Type} {ProtoProperties[i].Name} {{ get; set; }}");

                    if (i != ProtoProperties.Count - 1)
                    {
                        sb.AppendLine();
                    }
                }

                sb.AppendLine("    }");
                sb.AppendLine("}");

                return sb.ToString();
            }

            private string WriteEnum()
            {
                var sb = new StringBuilder();
                sb.AppendLine(string.Format(HeaderPattern, Name));
                sb.AppendLine();
                sb.AppendLine("namespace RedDragonCardCatcher.Model");
                sb.AppendLine("{");
                sb.AppendLine($"    internal enum {Name}");
                sb.AppendLine("    {");

                for (var i = 0; i < EnumMembers.Count; i++)
                {
                    sb.AppendLine($"        {EnumMembers[i]}{(i != EnumMembers.Count - 1 ? "," : string.Empty)}");
                }

                sb.AppendLine("    }");
                sb.AppendLine("}");

                return sb.ToString();
            }

            private static string ToUpperFirstLetter(string text)
            {
                return char.ToUpperInvariant(text[0]) + text.Substring(1);
            }
        }

        private class ProtoProperty
        {
            public int Number { get; set; }

            public string Name { get; set; }

            public string Type { get; set; }
        }
    }
}