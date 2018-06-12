using christellePOC.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace christellePOC.App_Code
{
    public class UserRepository:IDisposable
    {
        // instance of the EF  fro data access
        private NoteMgEntities dbContext = new NoteMgEntities();
       
         /*
        * Method the get add user information to he database by calling a store procedure
        */
        public void addUser( string userID, string ufirstName, string uLastName, string uMiddleName, string uCountry, string uPicturePath,  ref bool dbfails)
        {
            try
            { 
                // call the ctore procedure to sace to the database
                dbContext.Client_Add(userID, ufirstName, uLastName, uMiddleName, uCountry, uPicturePath);
            }
            catch (Exception ex)
            {
                dbfails = true; // variable to indicate occurence of  an exception
            }

        }
        
        public void Dispose()
        {
            //  throw new NotImplementedException();
            this.dbContext = null;
        }
    }
}