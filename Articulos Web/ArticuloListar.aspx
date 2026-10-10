<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ArticuloListar.aspx.cs" Inherits="Articulos_Web.ArticuloListar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Lista de Articulos...</h2>
    <asp:GridView ID="dgvArticulos" runat="server" CssClass ="table" AutoGenerateColumns ="false">
        <Columns>
            <asp:BoundField HeaderText ="Nombre" Datafield ="Nombre" />
            <asp:BoundField HeaderText ="Codigo" DataField ="Codigo" />
            <asp:BoundField HeaderText ="Descripcion" DataField ="Descripcion" />
            <asp:BoundField HeaderText ="Marca" DataField ="Marca.descripcion" />
            <asp:BoundField HeaderText ="Categoria" DataField ="Categoria.descripcion" />
            <asp:BoundField HeaderText ="Precio" DataField ="Precio" />


        </Columns>
    </asp:GridView>
</asp:Content>
