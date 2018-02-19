<%@ Page Title="" Language="C#" MasterPageFile="~/Jogos/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="CadastroEdicaoJogo.aspx.cs" Inherits="BibliotecaGames.Site.Jogos.CadastroEdicaoJogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="form-horizontal">
            <div class="form-group">
                <div class="col-md-2">
                    <label for="exampleInputEmail1">Titulo</label>
                    <asp:TextBox runat="server" ID="TxtTitulo" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RfvTitulo" runat="server" ControlToValidate="TxtTitulo" ErrorMessage="Campo Título deve ser preenchito." Text="*"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2">
                    <label for="exampleInputEmail1">Valor Pago</label>
                    <asp:TextBox runat="server" ID="ValorPago" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2">
                    <label for="exampleInputEmail1">Data Compra</label>
                    <asp:TextBox runat="server" ID="DataCompra" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2">
                    <label for="exampleInputEmail1">Imagem</label>
                    <asp:FileUpload runat="server" ID="FileUploadImage" CssClass="form-control"></asp:FileUpload>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2">
                    <label for="exampleInputEmail1">Genero</label>
                    <asp:DropDownList ID="DdlGenero" runat="server" DataValueField="Id" DataTextField="Descricao" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RfvDdlGenero" runat="server" ControlToValidate="DdlGenero" ErrorMessage="Selecione um item na lista Genero." Text="*"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2">
                    <label for="exampleInputEmail1">Editor</label>
                    <asp:DropDownList runat="server" ID="DdlEditor" DataValueField="Id" DataTextField="Nome" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RfvDdlEditor" runat="server" ControlToValidate="DdlEditor" ErrorMessage="Selecione um item na lista Editor." Text="*"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <asp:ValidationSummary ID="ValSum" DisplayMode="BulletList" EnableClientScript="true" HeaderTex="Os seguintes campo são obrigatórios:" runat="server" ForeColor="Red" />
        <br />
        <asp:Button runat="server" ID="btnGravar" Text="Gravar" CssClass="btn btn-primary" OnClick="BtnGravar_click" />
        <asp:Button runat="server" ID="btnExcluir" Text="Excluir" CssClass="btn btn-primary" OnClick="BtnExcluir_click" />
        <asp:Button CausesValidation="false" runat="server" ID="btnCatalogo" Text="Catálago de Jogos" OnClick="BtnCatalogo_click" CssClass="btn btn-primary" PostBackUrl="~/Jogos/Catalogo.aspx"/><br /><br />
        <asp:Label runat="server" ID="LblMensagem"></asp:Label>
    </div>
</asp:Content>
