<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<UserCreation.PendingEmployeeDisplay>>" %>
<%@ Import Namespace="MvcContrib.FluentHtml" %>
<%@ Import Namespace="MvcContrib" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="Biff" runat="server">
<table border="none" >
<tr><th>First Name</th>
<th>Last Name</th>
<th></th>
</tr>
<%foreach (var pendingEmployeeDisplay in Model)
{%>
<tr>
<td><%=pendingEmployeeDisplay.FirstName%></td>
<td><%=pendingEmployeeDisplay.LastName%></td>
<td><%=Html.ActionLink("Sign-on", MVC.Employee.SignOn(pendingEmployeeDisplay.Id)) %></td>
</tr>
<%} %>
</table>
</asp:Content>