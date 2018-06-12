using christellePOC.App_Code;
using christellePOC.EF;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace christellePOC.User
{
    public partial class UserNote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (User.Identity.IsAuthenticated == false)
                {
                    Response.Redirect("~/Account/Login");
                }
                using (NoteRepository noteCon = new NoteRepository())
                {
                    string userId = User.Identity.GetUserId();
                    StringBuilder strData = new StringBuilder();
                    List<Note_GetUserNotes_Result> notes = new List<Note_GetUserNotes_Result>();

                    notes = noteCon.getUserNote(userId);
                    int counter = 0;
                    foreach( var n in notes)
                    {
                        string strImgPath = "../Images/notes.jpg"; //"~/Images/notes.jpg"; 
                        strData.Append("<div class=\"col-md-3 col-lg-3 \">");
                        strData.Append("<div class =\"thumbnail\">");
                        strData.Append("<img src=\"" + strImgPath + "\" width=\"160px\" class=\"img-circle\"  />");
                        strData.Append("<h4> <strong>"+ n.noteTitle + " </strong> </h4>");
                        strData.Append("<em> Created on <strong>" + n.noteDateCreated.Value.ToShortDateString() + " </strong> </em> </br>");
                        strData.Append("<em> Last modified on <strong>" + n.noteDateModified.Value.ToShortDateString() + "</strong></em></br></br>");
                        strData.Append("<a href=\"\" class=\"iconCustom\"> <span class=\"glyphicon glyphicon-edit \"> </span> </a> ");
                        strData.Append("<a href=\"\"> <span class=\"glyphicon glyphicon-remove-sign iconCustom\"> </span> </a> ");
                        strData.Append("<a href=\"\"> <span class=\"glyphicon glyphicon-envelope iconCustom\"> </span> </a>");
                        strData.Append("</div>");
                        strData.Append("</div>");

                        // when counter is 3 , insert a  line a break
                        counter++;
                       if (counter == 4)
                        {
                            counter = 0;
                            strData.Append("< /br>");
                        }
                    }

                    userNotes.InnerHtml = strData.ToString();


                }
            }
        }
    }
}