<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Estados.aspx.cs" Inherits="PruebaCicloVida.Estados" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="View State 1" />
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
        Text="ViewState 2" />
    <asp:Button ID="Button4" runat="server" Text="Session 1" 
        onclick="Button4_Click" />
    <asp:Button ID="Button6" runat="server" Text="Application 1" 
        onclick="Button6_Click" />
    <br />
    <br />
    <br />
    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
        Text="Ver ViewState" />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="Button5" runat="server" Text="Ver Session" 
        onclick="Button5_Click" />
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="Button7" runat="server" Text="Ver Application" 
        onclick="Button7_Click" />
    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
