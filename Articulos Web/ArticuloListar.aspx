<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ArticuloListar.aspx.cs" Inherits="Articulos_Web.ArticuloListar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Lista de Articulos...</h2>
    <div class="row">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="mb-3">
                    <asp:Label Text="Filtro por NOMBRE" runat="server" />
                    <asp:TextBox ID="filtro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" runat="server" />
                    <asp:GridView ID="dgvArticulos" runat="server" DataKeyNames="Id"
                        CssClass="table" AutoGenerateColumns="false"
                        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
                        OnPageIndexChanging="dgvArticulos_PageIndexChanging"
                        AllowPaging="true" PageSize="5">
                        <Columns>
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                            <asp:BoundField HeaderText="Marca" DataField="Marca.descripcion" />
                            <asp:BoundField HeaderText="Categoria" DataField="Categoria.descripcion" />
                            <asp:BoundField HeaderText="Precio" DataField="Precio" />
                            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Modificar" />
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <a href="FormularioArticulo.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
