using ContactRepositoryApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;

namespace ContactRepositoryApi.DAL
{
    public class ContactEngine
    {
        private SqlConnection connection;
        public ContactEngine()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[CommonConstants.CONNECTION_STRING].ConnectionString;
            connection = new SqlConnection(connectionString);
        } 
            

        public IEnumerable<Contact> GetAllContacts()
        {
            IEnumerable<Contact> lstContact = null;
            connection.Open();
            SqlCommand command = new SqlCommand(CommonConstants.SP_CONTACT_GETALLCONTACTS, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader result = command.ExecuteReader();
            lstContact = ContactEngineHelper.MapContactToReader(result);
            return lstContact;
        }

        public bool UpdateContact(Contact contact)
        {
            connection.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(CommonConstants.SP_CONTACT_UPDATECONTACT, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContactID", DbType.Int32).Value = contact.ID;
            cmd.Parameters.AddWithValue("@FirstName", DbType.String).Value = contact.FirstName;
            cmd.Parameters.AddWithValue("@LastName", DbType.String).Value = contact.LastName;
            cmd.Parameters.AddWithValue("@Email", DbType.String).Value = contact.Email;
            cmd.Parameters.AddWithValue("@PhoneNumer", DbType.String).Value = contact.PhoneNumber;
            cmd.Parameters.AddWithValue("@ContactStatus", DbType.Boolean).Value = contact.Status;
            cmd.ExecuteNonQuery();
            return true;
        }

       
        public bool AddContact(Contact contact)
        {
            bool status;
            connection.Open();
            SqlCommand cmd = new SqlCommand(CommonConstants.SP_CONTACT_INSERTCONTACT, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", DbType.String).Value = contact.FirstName;
            cmd.Parameters.AddWithValue("@LastName", DbType.String).Value = contact.LastName;
            cmd.Parameters.AddWithValue("@Email", DbType.String).Value = contact.Email;
            cmd.Parameters.AddWithValue("@PhoneNumer", DbType.String).Value = contact.PhoneNumber;
            cmd.Parameters.AddWithValue("@ContactStatus", DbType.Boolean).Value = contact.Status;
            status = Convert.ToInt32(cmd.ExecuteScalar()) > 0 ? true : false;
            connection.Close();
            return status;
        }

        public void RemoveContact(int contactID)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(CommonConstants.SP_CONTACT_REMOVECONTACT, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContactID", DbType.Int32).Value = contactID;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public Contact GetContactByID(int contactID)
        {
            Contact contact = new Contact();
            connection.Open();
            SqlCommand cmd = new SqlCommand(CommonConstants.SP_CONTACT_GETCONTACTBYID, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContactID", DbType.Int32).Value = contactID;
            SqlDataReader reader = cmd.ExecuteReader();
            contact = ContactEngineHelper.MapContactToReader(reader).FirstOrDefault();
            connection.Close();
            return contact;
        }
    }
}