using Core.Entities.Utilities.Logs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.LogServices.SerilogServices
{
    public class SerilogDBManager : LogManagerBase
    {
        public SerilogDBManager(string connection) : base(connection)
        {
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
            throw new NotImplementedException();
        }
    }
}
