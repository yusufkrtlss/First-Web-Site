<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Salary.aspx.cs" Inherits="WebApplication2.Salary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!--- Writing Salary Class -->
            <div class="box-1">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                <table>
                    <thead>
                        <tr>
                            <th>Adding Salary</th>
                        </tr>
                        <tr>
                            <td>Write a Salary : <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                <asp:DropDownList ID="SalaryDropDown" runat ="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Saved" />
                            </td>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
