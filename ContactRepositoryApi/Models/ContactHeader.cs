using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ContactRepositoryApi.Models
{
    public class ContactHeader
    {
        public HttpStatusCode status { get; set; }
        public bool IsSuccess { get; set; }
    }
}
