﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace christellePOC.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class NoteMgEntities : DbContext
    {
        public NoteMgEntities()
            : base("name=NoteMgEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual int Client_Add(string clientID, string firstName, string lastName, string middleName, string country, string picturePath)
        {
            var clientIDParameter = clientID != null ?
                new ObjectParameter("clientID", clientID) :
                new ObjectParameter("clientID", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("firstName", firstName) :
                new ObjectParameter("firstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("lastName", lastName) :
                new ObjectParameter("lastName", typeof(string));
    
            var middleNameParameter = middleName != null ?
                new ObjectParameter("middleName", middleName) :
                new ObjectParameter("middleName", typeof(string));
    
            var countryParameter = country != null ?
                new ObjectParameter("Country", country) :
                new ObjectParameter("Country", typeof(string));
    
            var picturePathParameter = picturePath != null ?
                new ObjectParameter("picturePath", picturePath) :
                new ObjectParameter("picturePath", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Client_Add", clientIDParameter, firstNameParameter, lastNameParameter, middleNameParameter, countryParameter, picturePathParameter);
        }
    
        public virtual ObjectResult<Client_GetClient_Result> Client_GetClient(string clientId)
        {
            var clientIdParameter = clientId != null ?
                new ObjectParameter("clientId", clientId) :
                new ObjectParameter("clientId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Client_GetClient_Result>("Client_GetClient", clientIdParameter);
        }
    
        public virtual ObjectResult<Note_GetUserNotes_Result> Note_GetUserNotes(string userID)
        {
            var userIDParameter = userID != null ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Note_GetUserNotes_Result>("Note_GetUserNotes", userIDParameter);
        }
    }
}
