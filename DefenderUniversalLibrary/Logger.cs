using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DefenderUniversalLibrary
{
    public class Logger : ICloneable
    {
        private string _pathLogDirectory = @"../../../../Logger/";
        private string _fileName = "file";
        private string _pathLogFile => _pathLogDirectory + _fileName + ".log";

        private static object locker = new object();

        public class LogMessage
        {
            public string message;

            public LogMessage(string text)
            {
                message = text;
            }
        }

        public class LogMessageBuilder
        {
            private LogMessage message;

            public LogMessageBuilder()
            {
                message = new LogMessage("");
            }

            public LogMessageBuilder AddText(string text)
            {
                message.message += text;
                return this;
            }
            public LogMessageBuilder AddDate()
            {
                message.message += DateTime.Now.ToShortDateString() + ' ';
                return this;
            }
            public LogMessageBuilder AddTime()
            {
                message.message += DateTime.Now.ToShortTimeString() + ' ';
                return this;
            }
            public LogMessageBuilder AddSeparator()
            {
                message.message += " ::>>\t";
                return this;
            }

            public LogMessage Build()
            {
                message.message += '\n';
                return message;
            }

        }

        #region constructors
        public Logger()
        {
        }

        public Logger(string pathLogDirectory, string fileName)
        {
            _pathLogDirectory = pathLogDirectory;
            _fileName = fileName;
        }
        #endregion


        public object Clone()
        {
            return new Logger(_pathLogDirectory, _fileName);
        }

        public void SetLocation(string path)
        {
            _pathLogDirectory = path;
        }
        public void SetLocation(string dirPath, string fileName)
        {
            _pathLogDirectory = dirPath;
            _fileName = fileName;
        }

        public void CreateDirectoryAndFile()
        {
            try
            {
                var directory = new DirectoryInfo(_pathLogDirectory);
                var file = new FileInfo(_pathLogFile);

                if (!directory.Exists || !file.Exists)
                {
                    new Task(() =>
                    {
                        if (!directory.Exists)
                        {
                            directory.Create();
                        }
                        while (!directory.Exists)
                        {
                            Thread.Sleep(100);
                            directory.Refresh();
                        }

                        using (var stream = new FileStream(file.FullName, FileMode.Create)) { }

                    }).Start();
                }
            }
            catch
            {
            }
        }

        public bool IsFileExist()
        {
            var file = new FileInfo(_pathLogFile);
            if (!file.Exists)
            {
                return false;
            }
            return true;
        }


        public async void Write(string message)
        {
            CreateDirectoryAndFile();
            while (!IsFileExist()) { Thread.Sleep(100); }
            await writeAsync(new LogMessageBuilder().AddDate().AddTime().AddSeparator().AddText(message).Build().message);
        }

        private async Task writeAsync(string text)
        {
            if (IsFileExist())
            {
                var file = new FileInfo(_pathLogFile);

                using (var stream = new StreamWriter(file.FullName,true,Encoding.UTF8))
                {
                    await stream.WriteAsync(text);
                }
            }
        }
    }
}
