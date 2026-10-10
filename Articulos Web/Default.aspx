<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Articulos_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Bienvenido a mi aplicacion web...</h2>
    <div class="row row-cols-1 md:row-cols-3 g-4">
        <% 
            foreach (Dominio.Articulo articu in ListarArticulos)
            {
        %>
        <div class="col">
            <div class="card h-100">
                <img src="<% %> " class="card-img-top" alt="...">
                <div class="card-body">
                    <h4 class="card-title"> <%: articu.Nombre %> </h4>
                    <p class="card-text"> <%: articu.Descripcion %> </p>
                </div>
            </div>
        </div>
        <%
            }
        %>
    </div>
</asp:Content>
