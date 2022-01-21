<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>First Web</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet2.css" />
   
</head>
<body>

    <form id="form1" runat="server">
                   <!-- Main Header -->
                   <header id="main-header">
                       <div class="container">
                       <h1>Personal Information</h1>
                        </div>
                   </header>   
                  <div class="container">
                    <div class="box-1">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                       <!--- List of Employee --->  
                        <label>Employee List</label>
                        <table>
                            <tr>
                                <td>Employee ID
                                </td>
                                <td>First Name
                                </td>
                                <td>Last Name
                                </td>
                                <td>Age
                                </td>
                                <td>Gender
                                </td>
                                <td>
                                    Department No
                                </td>
                                <td>
                                    Tc No
                                </td>
                                <td>
                                    Salaries
                                </td>
                            </tr>
                            <!--- Taking every element of EmployeeDemographics in Sql using Eval --->
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("EmployeeID") %>
                                        </td>
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
                                            <%# Eval("DepartmentID") %>
                                        </td>
                                        <td>
                                            <%# Eval("TcNo") %>
                                        </td>
                                        <td>
                                            <%# Eval("Salaries") %>
                                        </td>
                                        <td>
                                            <!--- We use here querystring method which allows us to see all detail of a person in the CustomerPage. --->
                                            <a href="CustomerPage.aspx?EmployeeID=<%# Eval("EmployeeID") %>">Detail</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                      <!-- Adding a new person to the EmployeeDemographics -->
                    <div class="box-2">
                         <table>
                            <thead>
                                <tr>
                                <th>Adding New Person</th>
                                 </tr>
                            </thead>
                            <tbody>
                                <tr>
                                
                                    <td>
                                        Write First Name : <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                
                                    <td>
                                       Write Last Name : <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                               
                                    <td>
                                        Write Age : <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                
                                    <td>
                                        Write Gender :
                                        <asp:DropDownList ID="GenderDropdown" runat="server">
                                            <asp:ListItem>Male</asp:ListItem>
                                            <asp:ListItem>Female</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                     <tr>
                               
                                    <td>
                                        Write DepartmentID :
                                        <asp:DropDownList ID="DIDropDown" runat ="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                 <tr>
                               
                                    <td>
                                        Write Tc No  : <asp:TextBox ID ="TextBox5" runat="server"></asp:TextBox>
                                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                       
                                    </td>
                                </tr>

                               
                                <tr>
                                    <td>
                                        <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Add" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        </div>
                      <!--- Deleting a person in the EmployeeDemographics --->
                        <div class="box-3">
                         <table>
                            <thead>
                                <tr>


                                      <th>Deleting Person</th>
                                </tr>
                          
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        EmployeeID : <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                         <asp:Button Text="Delete" ID="Button1" OnClick="Button2_Click" runat="server" />
                                    </td>
                                </tr>
                            </tbody>
                           </table>
                          </div>
                      <!--- Job Title with Repeater --->
                          <div class="box-4">
                             
                              <table>
                                  <tr>
                                      <th>Department Name</th>
                                  </tr>
                             <asp:Repeater ID ="Repeater2" runat="server">
                                 <ItemTemplate>
                                     <tr>
                                         <td>
                                             <%# Eval("DepartmentName") %>
                                         </td>
                                     </tr>
                                 </ItemTemplate>
                             </asp:Repeater>
                          </table>
                          </div>
                        </div>
        </form>
</body>
</html>
