<%@ Control Language="C#" ClassName="BankInformation" Inherits="System.Web.Mvc.ViewUserControl<UserCreation.ViewModels.EmployeePayrollInformationViewModel>"%>
<%@ Import Namespace="MvcContrib.FluentHtml" %>

<script runat="server">
</script>
<% using(Html.BeginForm(MVC.Payroll.BankInformation()))
   {%>
     <fieldset>
        <%=Html.TextBoxFor(x => x.BankName)%>
        <%=this.TextBox("BankNameTextBox").Value(Model.BankName).AutoLabel() %><br />
        <%=this.TextBox("TransitNumber").Value(Model.TransitNumber).AutoLabel() %><br />
        <%=this.TextBox("AccountNumber").Value(Model.AccountNumber).AutoLabel() %><br />
     </fieldset>  
   <%} %>
