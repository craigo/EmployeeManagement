<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<UserCreation.PendingEmployeeDisplay>>" %>
<%@ Import Namespace="UserCreation" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="Biff" runat="server">
<table border="none" >
<tr><th>First Name</th>
<th>Last Name</th></tr>
<%foreach (var pendingEmployeeDisplay in Model)
{%>
<tr>
<td><%=pendingEmployeeDisplay.FirstName%></td>
<td><%=pendingEmployeeDisplay.LastName%></td>
</tr>
<%} %>
</table>
</asp:Content>