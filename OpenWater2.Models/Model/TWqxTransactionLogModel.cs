using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.Models.Model
{
    public class TWqxTransactionLogModel
    {
        public TWqxTransactionLogModel()
        {
            if (wqxTransactionLog == null) wqxTransactionLog = new TWqxTransactionLog();
        }
        public TWqxTransactionLog wqxTransactionLog { get; set; }
        // Converted xml from ResponseFile property from TWqxTransactionLog
        public string ResponseFileXML { get; set; }
    }
}
