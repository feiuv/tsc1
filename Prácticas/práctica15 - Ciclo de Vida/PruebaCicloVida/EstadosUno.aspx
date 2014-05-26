<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstadosUno.aspx.cs" Inherits="PruebaCicloVida.EstadosUno" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button5" runat="server" Text="Ver Session" 
        onclick="Button5_Click" />
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>

    </div>
    <asp:Button ID="Button6" runat="server" Text="Ver Application" 
        onclick="Button6_Click" />
    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
