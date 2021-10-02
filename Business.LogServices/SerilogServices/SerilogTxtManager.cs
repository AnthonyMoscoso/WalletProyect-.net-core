using Core.Entities.Utilities.Logs;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.LogServices.SerilogServices
{
    public class SerilogTxtManager : LogManagerBase
    {
        protected ILogger _log;
        private static readonly string DEFAULTFILE = @"C:\Logs\Log.txt";
        public SerilogTxtManager(string connection= @"C:\Logs\Log.txt") : base(connection)
        {

            if (string.IsNullOrWhiteSpace(connection))
            {
                _connection = DEFAULTFILE;
                ExistOrCreateDiretory( Path.GetFullPath(_connection));
            }
            else
            {
                _connection = connection;
                ExistOrCreateDiretory(Path.GetFullPath(_connection));
            }
           
      

            _log = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(_connection, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        private void ExistOrCreateDiretory(string url)
        {
            string directory = Path.GetDirectoryName(url);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public override string Read()
        {
            throw new NotImplementedException();
        }

        public override string Read(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public override string Read(DateTime dateTime, MessageType messageType = MessageType.information)
        {
            throw new NotImplementedException();
        }

        public override string Read(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public override string Read(DateTime start, DateTime end, MessageType messageType = MessageType.information)
        {
            throw new NotImplementedException();
        }

        public override void Write(string message, MessageType messageType = MessageType.information)
        {
            switch (messageType)
            {
                case MessageType.debug:
                    _log.Debug(message);
                    break;
                case MessageType.error:
                    _log.Error(message);
                    break;
                case MessageType.information:
                    _log.Information(message);
                    break;
                default:
                    _log.Information(message);
                    break;

            }

        }
    }
}

