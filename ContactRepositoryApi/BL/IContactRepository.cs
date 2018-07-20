using ContactRepositoryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactRepositoryApi.BL
{
    interface IContactRepository
    {
        IEnumerable<Contact> GetAll();
        Contact Get(int id);
        bool Add(Contact item);
        void Remove(int id);
        bool Update(Contact item);
    }
}
