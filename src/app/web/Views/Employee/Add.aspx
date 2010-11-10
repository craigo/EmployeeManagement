<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"  Inherits="System.Web.Mvc.ViewPage<UserCreation.ViewModels.NewEmployee>"%>
<%@ Import Namespace="MvcContrib.FluentHtml" %>
<%@ Import Namespace="MvcContrib" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<% using (Html.BeginForm("AddNew", "Employee", FormMethod.Post))
   {%>
      <p><%=Html.LabelFor(x => x.FirstName)%>
       <%=Html.TextBoxFor(x => x.FirstName)%></p>
       <p><%=Html.LabelFor(x => x.LastName)%>
       <%=Html.TextBoxFor(x => x.LastName)%></p>
       <%=this.SubmitButton("Add") %>
   <% }%>
</asp:Content>