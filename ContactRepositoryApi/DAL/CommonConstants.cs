using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactRepositoryApi.DAL
{
    public static class CommonConstants
    {
        public const string CONNECTION_STRING = "contactRepositoryConnectionString";
        public const string SP_CONTACT_GETALLCONTACTS = "sp_Contact_GetAllContacts";
        public const string SP_CONTACT_UPDATECONTACT = "sp_Contact_UpdateContact";
        public const string SP_CONTACT_INSERTCONTACT = "sp_Contact_InsertContact";
        public const string SP_CONTACT_REMOVECONTACT = "sp_Contact_RemoveContact";
        public const string SP_CONTACT_GETCONTACTBYID = "sp_Contact_GetContactByID";

    }
}