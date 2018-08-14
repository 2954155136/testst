<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BigPrintWebApp.ExercisePages.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h1>Exercise Home</h1>
    <div class="row">
        <div class="col-sm-offset-1 col-sm-10 alert alert-info">
            <blockquote style="font-style:italic">
                This page will demonstrate CRUD against the Products table using web forms as the user interface.
                The web form will make calls to an application library called NorthwindSystem. This 
                application library containers public classes that will server as the web site interface
                to the data base. Each entity (sql table) will have its own controller.
            </blockquote>
        </div>
    </div>
    <div class="row">
        <asp:DataList ID="Message" runat="server">
          <ItemTemplate>
               <%# Container.DataItem %>
          </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="row">
        <div class="grid-form">
            <%--CustomerList--%>
            <asp:Label ID="label1" runat="server" AssociatedControlID="CustomerList" Text="Customer Name"></asp:Label>
            <asp:DropDownList ID="CustomerList" runat="server"></asp:DropDownList>
            <asp:Button ID="LookUp" runat="server" text="Look Up" CausesValidation="false" OnClick="LookUp_Click"></asp:Button>
            
            <%--Customer ID--%>
            <asp:Label ID="Label2" runat="server" AssociatedControlID="CustomerID" Text="ID:"></asp:Label>
            <asp:Literal ID="CustomerID" runat="server"></asp:Literal>

            <%--First Name--%>
            <asp:Label ID="Label5" runat="server" AssociatedControlID="FirstName" Text="First Name"></asp:Label>
            <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>

            <%--Last Name--%>
            <asp:Label ID="Label6" runat="server" AssociatedControlID="LastName" Text="Last Name"></asp:Label>
            <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
  
            <%--Email--%>
            <asp:Label ID="Label3" runat="server" AssociatedControlID="Email" Text="Email"></asp:Label>
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="RequiredFieldEmail" runat="server" ErrorMessage="Email address is required."
                 ControlToValidate="Email" SetFocusOnError="true" 
                 ForeColor ="Firebrick" Display="None"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionEmail" runat="server" ErrorMessage="Invalid email address"
                 ControlToValidate="Email" SetFocusOnError="true"
                 ForeColor="Firebrick" Display="None"
                 ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"></asp:RegularExpressionValidator>--%>

            <%--Contact Number--%>
            <asp:Label ID="Label4" runat="server" AssociatedControlID="ContactNumber" Text="Contact Number"></asp:Label>
            <asp:TextBox ID="ContactNumber" runat="server"></asp:TextBox>
           <%-- <asp:RegularExpressionValidator ID="RegularExpressionContactNumber" runat="server" ErrorMessage="Invalid contact number"
                 ControlToValidate="ContactNumber" SetFocusOnError="true"
                 ForeColor="Firebrick" Display="None"
                 ValidationExpression="[0-9][1-9][1-9]-[0-9][1-9][1-9]-[1-9][1-9][1-9][1-9]">
            </asp:RegularExpressionValidator>--%>
          
        </div>
    </div>
    <br />
    <div class ="row col-md-offest-2">       
        <asp:Button ID="Add" runat="server" Text="Add" height="26px" width="67px" OnClick="Add_Click" />&nbsp;&nbsp;
        <asp:Button ID ="Clear" runat="server" Text="Clear" height="26px"  width="67px" OnClick="Clear_Click" />     
    </div>
</asp:Content>
