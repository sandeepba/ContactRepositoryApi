

using ContactRepositoryApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ContactRepositoryApi.DAL
{
    public static class ContactEngineHelper
    {
        public static List<Contact> MapContactToReader(SqlDataReader result)
        {
            List<Contact> contacts = new List<Contact>();
            while(result.Read())
            {
                Contact contact = new Contact();
                contact.ID = Convert.ToInt32(result["ID"].ToString());
                contact.FirstName = result["FirstName"].ToString();
                contact.LastName = result["LastName"].ToString();
                contact.Email = result["Email"].ToString();
                contact.PhoneNumber = result["PhoneNumber"].ToString();
                contact.Status = Convert.ToBoolean(result["ContactStatus"].ToString());
                contacts.Add(contact);
             }
            return contacts;
        }
    }
}