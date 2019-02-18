//-----------------------------------------------------------------------
// <copyright file="HandHistory.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using RedDragonCardCatcher.Common.Extensions;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace HandHistories.Converters.Ipoker
{
    [XmlRoot("session")]
    public class HandHistory
    {
        [XmlAttribute("sessioncode")]
        public string SessionCode { get; set; }

        [XmlElement("general")]
        public General General { get; set; }

        [XmlElement("game")]
        public List<Game> Games { get; set; }

        public XmlDocument ToHandHistoryXmlDocument()
        {
            var handHistoryXml = SerializationHelper.SerializeObject(this);

            var handHistoryXmlDocument = new XmlDocument
            {
                PreserveWhitespace = true
            };

            handHistoryXmlDocument.LoadXml(handHistoryXml);

            return handHistoryXmlDocument;
        }
    }
}