<%@ Page Title="" Language="C#" MasterPageFile="~/Jogos/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="BibliotecaGames.Site.Jogos.Catalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/Jogos/catalogo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Catálogo de Jogos</h2>
    <hr />
    <div>
        <div>
            <asp:repeater ID="RepeaterJogos" runat="server">
                <ItemTemplate>
                    <div class="jogo" onclick="redireionarparaPagianDoJogo('<%= Session["Perfil"].ToString() %>', <%# DataBinder.Eval(Container.DataItem,"Id") %>)">
                        <div class="capa-jogo">
                            <img src="../Content/imagensJogo/<%# DataBinder.Eval(Container.DataItem,"Imagem") %>" alt=" <%# DataBinder.Eval(Container.DataItem,"Titulo") %>"/>
                        </div>
                        <div class="nome-jogo">
                            <%# DataBinder.Eval(Container.DataItem,"Titulo") %>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:repeater>
        </div>
        <div>
            <asp:Button runat="server" ID="Button1" Text="Novo Jogo" OnClick="BtnNovoJogo_click" CssClass="btn btn-primary" PostBackUrl="~/Jogos/CadastroEdicaoJogo.aspx" class="btn shelf-cta ml-3"/> 
        </div>
    </div>
    <script>
        function redireionarparaPagianDoJogo(perfil, id) {
            if (perfil === 'A') {
                top.location.href = "CadastroEdicaoJogo.aspx?id=" + id;
            } else {
                top.location.href = "DetalhesJogo.aspx?id=" + id;
            }
        }
    </script>
</asp:Content>
