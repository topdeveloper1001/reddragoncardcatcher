//-----------------------------------------------------------------------
// <copyright file="IniFile.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;

namespace RedDragonCardCatcher.DbInstallers
{
    internal sealed class IniFile
    {
        private readonly string file;
        private Dictionary<string, Dictionary<string, string>> iniDictionary = new Dictionary<string, Dictionary<string, string>>();

        public IniFile(string file)
        {
            if (!File.Exists(file))
            {
                throw new FileNotFoundException("Ini file not found");
            }

            this.file = file;

            Initialize();
        }

        public string GetParameter(string path)
        {
            var parsedPath = ParsePath(path);
            var section = parsedPath.Item1;
            var parameter = parsedPath.Item2;

            var value = string.Empty;

            if (!iniDictionary.ContainsKey(section) || !iniDictionary[section].ContainsKey(parameter))
            {
                return value;
            }

            return iniDictionary[section][parameter];
        }

        public void SetParameter(string path, string value)
        {
            var parsedPath = ParsePath(path);
            var section = parsedPath.Item1;
            var parameter = parsedPath.Item2;

            if (!iniDictionary.ContainsKey(section) || !iniDictionary[section].ContainsKey(parameter))
            {
                AddParameter(section, parameter, value);
            }

            iniDictionary[section][parameter] = value;
        }

        public void Save()
        {
            var fileLines = new List<string>();

            var sectionPattern = "[{0}]";
            var parameterPattern = "{0}={1}";

            foreach (var section in iniDictionary.Keys)
            {
                fileLines.Add(string.Format(sectionPattern, section));

                foreach (KeyValuePair<string, string> parameterValuePair in iniDictionary[section])
                {
                    fileLines.Add(string.Format(parameterPattern, parameterValuePair.Key, parameterValuePair.Value));
                }
            }

            File.WriteAllLines(file, fileLines);
        }

        #region Infrastructure

        private void Initialize()
        {
            var fileLines = File.ReadAllLines(file);

            var currentSection = string.Empty;

            foreach (var fileLine in fileLines)
            {
                if (string.IsNullOrWhiteSpace(fileLine))
                {
                    continue;
                }

                if (fileLine.StartsWith("["))
                {
                    currentSection = fileLine.Trim('[', ']');
                    continue;
                }

                if (string.IsNullOrWhiteSpace(currentSection))
                {
                    continue;
                }

                var paramValue = fileLine.Split('=');

                var parameter = paramValue[0];
                var value = paramValue.Length < 2 ? string.Empty : paramValue[1];

                AddParameter(currentSection, parameter, value);
            }
        }

        private void AddParameter(string section, string parameter, string value)
        {
            Dictionary<string, string> sectionDictionary;

            if (!iniDictionary.ContainsKey(section))
            {
                sectionDictionary = new Dictionary<string, string>();
                iniDictionary.Add(section, sectionDictionary);
            }
            else
            {
                sectionDictionary = iniDictionary[section];
            }

            if (sectionDictionary.ContainsKey(parameter))
            {
                return;
            }

            sectionDictionary.Add(parameter, value);
        }

        private Tuple<string, string> ParsePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Bad path");
            }

            var splittedPath = path.Split('/');

            if (splittedPath.Length != 2)
            {
                throw new ArgumentException("Path must contain section and parameter");
            }

            return new Tuple<string, string>(splittedPath[0], splittedPath[1]);
        }

        #endregion
    }
}