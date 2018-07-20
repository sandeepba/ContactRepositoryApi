using System.Collections.Generic;

namespace ContactRepositoryApi.Models
{
    public class ContactResponse
    {
        public ContactHeader header { get; set; }
        public List<Contact> contracts { get; set; }
    }
}