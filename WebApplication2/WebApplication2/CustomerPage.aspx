<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerPage.aspx.cs" Inherits="WebApplication2.CustomerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Personal Detail</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css"
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!--- This is the detail of a employee --->
                <div class="box-1">
                  <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <table>
                        <tr>
                            <td>FirstName
                            </td>
                            <td>LastName
                            </td>
                            <td>Age
                            </td>
                            <td>Gender
                            </td>
                        </tr>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Eval("FirstName") %>
                                    </td>
                                    <td>
                                        <%# Eval("LastName") %>
                                    </td>
                                    <td>
                                        <%# Eval("Age") %>
                                    </td>
                                    <td>
                                        <%# Eval("Gender") %>
                                    </td>
                                    <td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                 </div>
         </div>
    </form>
     
</body>
</html>
