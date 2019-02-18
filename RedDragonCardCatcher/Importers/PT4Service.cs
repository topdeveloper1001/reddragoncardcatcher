//-----------------------------------------------------------------------
// <copyright file="PT4Service.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using RedDragonCardCatcher.Overlays;

namespace RedDragonCardCatcher.Importers
{
    internal class PT4Service : HM2Service
    {        
        protected override string GetTableTitle(HandHistoryData handHistoryData)
        {
            var stacks = handHistoryData.HandHistory.GameDescription != null && handHistoryData.HandHistory.GameDescription.Limit != null ?
                $"${handHistoryData.HandHistory.GameDescription.Limit.SmallBlind}/${handHistoryData.HandHistory.GameDescription.Limit.BigBlind}" :
                "$1/$2";

            var title = handHistoryData.HandHistory.GameDescription != null && handHistoryData.HandHistory.GameDescription.IsTournament ?
                $"{handHistoryData.HandHistory.TableName} {handHistoryData.WindowHandle} | NL Hold'em | Level 1 | {stacks.Replace("$", string.Empty)}" :
                $"{handHistoryData.HandHistory.TableName} - {stacks} No limit Hold'em";

            return title;
        }      

        protected override RDOverlayWindow CreateOverlayWindow()
        {
            return new RDOverlayWindow
            {
                IsScalingEnabled = true
            };
        }
    }
}
 