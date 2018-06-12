using christellePOC.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using christellePOC.App_Code;

namespace christellePOC.Account
{
    public partial class Userregistration : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                // this page is only visible to user after they have regitered
                if (User.Identity.IsAuthenticated == false)
                {
                    Response.Redirect("~/Account/Login");
                }
            }
           
        }

        /*
        * Method to recired user information
        */
        public void completeRegistration(object sender, EventArgs e)
        {
            
            bool dbError = false;
            using (UserRepository userCon = new UserRepository())
            {
                // get information saved in the  fields form
                string userID = User.Identity.GetUserId();
                string strfirstName = firstName.Value;
                string strLastName = lastName.Value;
                string strMiddleName = middleName.Value;
                string strCountry = "South Africa";
                string strPicturePath = this.saveUserPicture();

                try
                {
                    //add user infor to the db
                    userCon.addUser(userID, strfirstName, strLastName, strMiddleName, strCountry, strPicturePath, ref dbError);
                    // redirect user to his notes
                    Response.Redirect("~/User/Notes");
                }
                catch (Exception)
                {
                    // when an error occured while saving, notify the user.
                    if (dbError == true)
                    {
                        FailureRegister.Text = "Invalid Information";
                        ErrorRegister.Visible = true;
                    }
                    
                }  
                

            }


        }

        /*
        * Method to save the file uploaded by user in image folder and return the path
        */
        private string saveUserPicture()
        {
            //if no file is uploaded then set the default user picture
            if (userPicture.PostedFile.ContentLength == 0)
            {
                // store the default image path
                return "default.jpg";
            }
          
            //set filename to be user id
            string fileName = User.Identity.GetUserId() + "_" + userPicture.PostedFile.FileName;
            string imagePath = Server.MapPath("~/Images/") + fileName;
            //save  picture in image folder
            userPicture.PostedFile.SaveAs(imagePath);

            return fileName; // just return the file name after saving

        }
    }
} 