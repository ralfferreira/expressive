<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetalhesProduto.aspx.cs" Inherits="WebAppLoja.DetalhesProduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" href="assets/css/style.css">
<link rel="preconnect" href="https://fonts.gstatic.com">
<link href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400;500;700;900&display=swap" rel="stylesheet">
<title>Expressive</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper_all">
        <header class="header">
            <a href="index.aspx"><img src="assets/img/eh o expressive.png" class="logo"/></a>
            <ul class="header-menu">
                <div class="dropdown">
                    <a href="#instrumentos" class="dropbtn">Instrumentos</a>
                    <div class="dropdown-content" id="dropdown-instrumentos">
                        <a href="#">Guitarras</a>
                        <a href="#">Pianos</a>
                        <a href="#">Violinos</a>
                        <a href="produtos.aspx">Ver mais +</a>
                    </div>
                </div>
                <div class="dropdown">
                    <a href="#calcados" class="dropbtn">Calçados</a>
                    <div class="dropdown-content" id="dropdown-calcados">
                        <a href="#">Kyrie</a>
                        <a href="#">Jordan</a>
                        <a href="produtos.aspx">Ver mais +</a>
                    </div>
                </div>
                <div class="dropdown">
                    <a href="#relogios" class="dropbtn">Relógios</a>
                    <div class="dropdown-content" id="dropdown-relogio">
                        <a href="#">Relógios Desert</a>
                        <a href="#">Relógios Rolex</a>
                        <a href="produtos.aspx">Ver mais +</a>
                    </div>
                </div>
                <a href="Carrinho.aspx"><img class="carrinho-icon" src="assets/img/carrinho.png"/></a>
                <asp:Panel ID="panLogin" runat="server" Visible="True">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btnLogin" PostBackUrl="~/login.aspx" />
                </asp:Panel>
                <asp:Panel ID="panOptions" runat="server" Visible="False">
                    <div class="dropdown">
                        <a href="#relogios" class="dropbtn">Opções</a>
                        <div class="dropdown-content" id="dropdown-options">
                            <a href="User/AreaUsuario.aspx">Meus Pedidos</a>
                            <a href="User/EditarASiMesmo.aspx">Editar Perfil</a>
                            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btnLogout" PostBackUrl="~/Logout.aspx" />
                        </div>
                    </div>
                </asp:Panel> 
            </ul>
        </header>
        <div class="detalhesProduto-content">
            <h1 class="detalhesProduto-tittle">Detalhes do Produto</h1>       
            <grid class="detalhesProduto-grade">
                <div class="detalhesProduto-DivImg">
                    <asp:Image ID="imgFoto" runat="server" CssClass="detalhesProduto-img"></asp:Image>
                </div>          
                <div class="detalhesProduto-resto" >
                    <asp:HiddenField ID="hfCod" runat="server" Visible="False"></asp:HiddenField>
                    <asp:Label ID="lblNome" runat="server" CssClass="detalhesProduto-txt1"></asp:Label>
                    <asp:Label ID="lblPreco" runat="server" CssClass="detalhesProduto-txt2" ></asp:Label>
                    <asp:Label ID="lblCategoria" runat="server" CssClass="detalhesProduto-txt3" ></asp:Label>
                    <asp:Label ID="lblDesc" runat="server" CssClass="detalhesProduto-descricao"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblMensagem" runat="server" Text="" CssClass="label"></asp:Label>
                    <br />
                    <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar ao Carrinho" CssClass="button-adicionarAoCarrinho" OnClick="btnAdicionar_Click"></asp:Button>
                    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="button-voltar" PostBackUrl="~/produtos.aspx"></asp:Button>
                </div>
            </grid>
        </div>
    </div>
</asp:Content>
