using christellePOC.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace christellePOC.App_Code
{
    public class NoteRepository:IDisposable
    {
        // instance of the EF  fro data access
        private NoteMgEntities dbContext = new NoteMgEntities();

        public List<Note_GetUserNotes_Result> getUserNote(string userID)
        {
            // create a list to hold  result from db
            List<Note_GetUserNotes_Result> notes = new List<Note_GetUserNotes_Result>();

            // get the data drom the database
            ObjectResult<Note_GetUserNotes_Result> result = this.dbContext.Note_GetUserNotes(userID);
            notes = result.ToList(); // convert the result to a list   
            return notes;
        }

        /**
         * this method calls a stores procedure to add a new note for the user specified
         **/
        public void AddNewNote(string userID, string noteTitle, string noteContent)
        {

        }

        /**+
         * method update the note   
         * **/
        public void editNote(string userID, int noteId, string noteTitle, string noteContent)
        {

        }

        public void deleteNote()
        {

        }
        public void Dispose()
        {
            //  throw new NotImplementedException();
            this.dbContext = null;
        }
    }
}