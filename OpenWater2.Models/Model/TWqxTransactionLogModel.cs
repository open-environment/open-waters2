using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.Models.Model
{
    public class TWqxTransactionLogModel
    {
        public FileContentResult BlobFile { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }
}
