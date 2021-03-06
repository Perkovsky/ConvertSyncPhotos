﻿using System;
using System.IO;

namespace WindowsService
{
    /// <summary>
    /// This interface is required for DI
    /// </summary>
    public interface ILog
    {
        bool NeedToLog { set; }
        void Log(string fileName, string typeAction);
    }

    /// <summary>
    /// This class is needed to log the operation of the service
    /// </summary>
    public class Logger : ILog
    {
        private readonly string LOG_FILE_NAME = string.Format(@"{0}\log.txt", GeneralMethods.GetCurrentDirectory());

        private bool needToLog;
        private FileInfo file;
        private StreamWriter writer;

        public bool NeedToLog
        {
            set
            {
                needToLog = value;
                if (needToLog && writer == null)
                {
                    file = new FileInfo(LOG_FILE_NAME);
                    writer = file.AppendText();
                }
                else if (!needToLog && writer != null)
                {
                    writer.Close();
                    writer = null;
                }
            }
        }

        public static string FormatMsg(string fileName, string typeAction)
        {
            string msg = string.Format("{0} -> {1}", Path.GetFileName(fileName), typeAction);
            return string.Format("{0} :: {1}", DateTime.Now.ToString(), msg);
        }

        public void Log(string fileName, string typeAction)
        {
            if (!needToLog) return;

            writer.WriteLine(FormatMsg(fileName, typeAction));
            writer.Flush();
        }
    }
}
