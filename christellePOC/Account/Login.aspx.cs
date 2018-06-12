using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using christellePOC.Models;
using christellePOC.EF;
using System.Linq;

namespace christellePOC.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        //get user ID 
                        string userId = signinManager.AuthenticationManager.AuthenticationResponseGrant.Identity.GetUserId();
                        checkUserRegistrationComplete(userId);
                        break;
                   
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }

        /*
        * Method to check if the user has completed the regsitration that is , the  user's infor
        * is stored in the Client table in database after the registration.
        */
        protected void checkUserRegistrationComplete(string userId)
        {
            // connect to the db using EF
            var dbCon = new NoteMgEntities();
            // call store procedure
            var result = dbCon.Client_GetClient(userId);
            // get the  user data foorm the result  of the database
            var user = (from a in result
                        select a).FirstOrDefault();

            if (user == null)
            {
                Response.Redirect("UserRegistration");
            }
             else
            {
                Response.Redirect("~/User/Notes");
            }

        }

    }
}