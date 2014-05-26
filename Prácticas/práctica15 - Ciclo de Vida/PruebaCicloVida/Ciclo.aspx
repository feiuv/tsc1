<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ciclo.aspx.cs" Inherits="PruebaCicloVida.Ciclo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Sumar" />
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
        Text="Ver Resultado" />
    <br />
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    </form>
</body>
</html>
