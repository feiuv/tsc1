<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estudiantes.aspx.cs" Inherits="TestWeb.Estudiantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
       <h2>Estudiantes</h1> &nbsp;<table style="width:100%;">
           <tr>
               <td>
                   Nombre</td>
               <td>
                   <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   App</td>
               <td>
                   &nbsp;</td>
           </tr>
           <tr>
               <td>
                   &nbsp;</td>
               <td>
                   <asp:Button ID="Button2" runat="server" Text="Guardar" 
                       onclick="Button2_Click" />
               </td>
           </tr>
      
           </table>
    
    <p>
        &nbsp;</p>
</asp:Content>
