<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="Articulos_Web.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label ID="LbId" runat="server" Text="Id"></asp:Label>
                <asp:TextBox ID="TxtId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="LbCodigo" runat="server" Text="Codigo"></asp:Label>
                <asp:TextBox ID="TxtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="LbNombre" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción:</label>
                <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio:</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca:</label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Button runat="server" ID="btnAceptar" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                <a href="ArticuloListar.aspx">Cancelar</a>
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoría:</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select" />
            </div>
            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtUrlImagen" class="form-label">URL de Imagen:</label>
                        <asp:TextBox runat="server" ID="txtUrlImagen" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtUrlImagen_textChanged" />
                    </div>
                    <div class="mb-3">
                        <asp:Image ImageUrl="https://www.istockphoto.com/es/ilustraciones/placeholder-image"
                            ID="ImageArticulo" runat="server" Width="60%" />
                    </div>
                    <asp:Label ID="lblDebug" runat="server" Text="Label"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
