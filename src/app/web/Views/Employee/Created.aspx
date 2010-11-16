<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<UserCreation.ViewModels.NewEmployeeViewModel>"%>

<asp:Content ContentPlaceHolderID="MainContent" ID="stuff" runat="server">
<p>Employee <%=Model.FirstName %> has been created.</p>
</asp:Content>