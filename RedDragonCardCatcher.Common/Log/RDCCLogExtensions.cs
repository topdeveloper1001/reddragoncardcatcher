﻿//-----------------------------------------------------------------------
// <copyright file="RDCCLogExtensions.cs" company="Ace Poker Solutions">
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

namespace RedDragonCardCatcher.Common.Log
{
    /// <summary>
    /// Extensions for RDCCLog
    /// </summary>
    public static class RDCCLogExtensions
    {
        public static void Log(this IRDCCLog log, object sender, object message, LogMessageType logMessageType)
        {
            Type logType = null;

            if (sender != null)
            {
                if (sender is string)
                {
                    log.Log(sender as string, message, logMessageType);
                    return;
                }

                logType = sender as Type ?? sender.GetType();
            }

            log.Log(logType, message, logMessageType);
        }

        public static void Log(this IRDCCLog log, object sender, object message, Exception exception, LogMessageType logMessageType)
        {
            Type logType = null;

            if (sender != null)
            {
                if (sender is string)
                {
                    log.Log(sender as string, message, exception, logMessageType);
                    return;
                }

                logType = sender as Type ?? sender.GetType();
            }

            log.Log(logType, message, exception, logMessageType);
        }

        public static void Log(this IRDCCLog log, object message, LogMessageType logMessageType)
        {
            log.Log(string.Empty, message, logMessageType);
        }

        public static void Error(this IRDCCLog log, object sender, Exception exception)
        {
            log.Log(sender, exception, LogMessageType.Error);
        }

        public static void Error(this IRDCCLog log, Exception exception)
        {
            log.Log(string.Empty, exception, LogMessageType.Error);
        }

        public static void Error(this IRDCCLog log, object sender, object message)
        {
            Exception exception = message as Exception;
            log.Log(sender, message, LogMessageType.Error);
        }

        public static void Error(this IRDCCLog log, object sender, object message, Exception exception)
        {
            log.Log(sender, message, exception, LogMessageType.Error);
        }

        public static void Error(this IRDCCLog log, object message)
        {
            log.Error(string.Empty, message);
        }

        public static void Debug(this IRDCCLog log, object sender, object message)
        {
            log.Log(sender, message, LogMessageType.Debug);
        }

        public static void Debug(this IRDCCLog log, object message)
        {
            log.Debug(string.Empty, message);
        }

        public static void Info(this IRDCCLog log, object sender, object message)
        {
            log.Log(sender, message, LogMessageType.Info);
        }

        public static void Info(this IRDCCLog log, object message)
        {
            log.Info(string.Empty, message);
        }

        public static void Warn(this IRDCCLog log, object sender, object message)
        {
            log.Log(sender, message, LogMessageType.Warning);
        }

        public static void Warn(this IRDCCLog log, object message)
        {
            log.Warn(string.Empty, message);
        }
    }
}