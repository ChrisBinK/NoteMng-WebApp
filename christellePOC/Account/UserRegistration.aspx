  <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="christellePOC.Account.Userregistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <div class="row">
        <div class="col-md-4">        </div>
        <div class=" col-md-4">
            <div class="form-container"> 
                <asp:PlaceHolder runat="server" ID="ErrorRegister" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureRegister" />
                        </p>
                 </asp:PlaceHolder>
                <div class="form-group">
                    <h3 class="page-header"> Complete Registration</h3>
                    <label for="firstName">First name </label>
                    <input type="text" class ="form-control" placeholder="First name"  id ="firstName" runat="server"/>
                </div>

                <div class ="form-group">
                    <label  for="lastName">Last name</label>
                    <input type="text" class ="form-control" placeholder ="Last name" id="lastName" runat="server" />
                </div>

                <div class ="form-group">
                    <label  for="middleName">Middle name</label>
                    <input type="text" class ="form-control" placeholder ="Last name" id="middleName" runat="server" />
                </div>

                 <div class="form-group">
                     <label for ="userPicture"> Upload picture </label>
                     <input type="file" class="form-control" id="userPicture" runat="server" />
                 </div>
                
                 <button type="submit" class="btn btn-default btn-block" runat="server" onserverclick ="completeRegistration">  Save </button>
                
           
            </div>
         </div>
            
         <div class="col-md-4"> </div>
        
    </div>
</asp:Content>
