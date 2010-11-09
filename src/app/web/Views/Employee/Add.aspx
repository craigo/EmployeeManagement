<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"  Inherits="System.Web.Mvc.ViewPage<UserCreation.ViewModels.NewEmployee>"%>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<% using (Html.BeginForm("Add", "AddNewEmployeeController", FormMethod.Post))
   {
       Html.LabelFor(x => x.FirstName);
       Html.TextBoxFor(x => x.FirstName);
       Html.LabelFor(x => x.LastName);
       Html.TextBoxFor(x => x.LastName);
   }%>
</asp:Content>