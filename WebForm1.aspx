<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication5.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Label ID="Label3" runat="server" Font-Size="X-Large" Text="Customer Database"></asp:Label>
            <br />
            <asp:HiddenField ID="hfcontactsID" runat="server" />
 <table>
            <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            </td>
                </tr>

             <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Mobile"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtmobile" runat="server"></asp:TextBox>
            </td>
                </tr>
            <tr>
                <td >
                    <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
                
                <td >
                    <asp:Button ID="Button2" runat="server" Text="Delete" OnClick="Button2_Click" />
                
            </tr>
            <tr>
                <td>
                    &nbsp;<asp:Label ID="lblsuccess" runat="server" Text="" ForeColor="Green"></asp:Label>
                &nbsp;</td>
            </tr>
            <tr>
                <td>
                                
                    &nbsp;</td>            
                </tr>
         
        </table>
        <br />
            <asp:GridView ID="grcontact" runat="server" AutoGenerateColumns="false" OnPageIndexChanged="grcontact_PageIndexChanged">
                <Columns>
                    <asp:BoundField Datafield="Name" HeaderText="Name" />
                    <asp:BoundField Datafield="Mobile" HeaderText="Mobile" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument ='<%# Eval("ID") %>' OnClick ="link_OnClick">View</asp:LinkButton>
                                                 
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
           
                
        </div>
    </form>
</body>
</html>
