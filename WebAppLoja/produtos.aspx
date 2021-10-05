<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="produtos.aspx.cs" Inherits="WebAppLoja.produtos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="assets/css/style.css">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400;500;700;900&display=swap" rel="stylesheet">
    <script  src="https://code.jquery.com/jquery-3.1.1.min.js"  integrity="sha256-hVVnYaiADRTO2PzUGmuLJr8BLUSjGIZsDYGmIJLv2b8="  crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js" ></script>
    <title>Expressive</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper_all">
        <header class="header">
            <a href="index.aspx"><img src="assets/img/eh o expressive.png" class="logo"/></a>
            <ul class="header-menu">
                <div class="dropdown">
                   <a href="#" class="dropbtn">Instrumentos</a>
                    <div class="dropdown-content" id="dropdown-instrumentos">
                      <a href="#">Guitarras</a>
                      <a href="#">Pianos</a>
                      <a href="#">Violinos</a>
                      <a href="#">Ver mais +</a>
                    </div>
                    </div>
                <div class="dropdown">
                   <a href="#" class="dropbtn">Calçados</a>
                    <div class="dropdown-content" id="dropdown-calcados">
                      <a href="#">Kyrie</a>
                      <a href="#">Jordan</a>
                      <a href="#">Ver mais +</a>
                    </div>
                    </div>
                <div class="dropdown">
                   <a href="#" class="dropbtn">Relógios</a>
                    <div class="dropdown-content" id="dropdown-relogio">
                      <a href="#">Relógios Desert</a>
                      <a href="#">Relógios Rolex</a>
                      <a href="#">Ver mais +</a>
                    </div>
                    </div>
            <a href="carrinho.aspx"><img class="carrinho-icon" src="assets/img/carrinho.png"/></a>
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

        <section id="produtos">
            <div class="produtos-wrapper">
            <div class="produtos-details">
                <h2 class="produtos-title">Produtos</h2>
                <br />
                <br />
                <h2 class="nome-categoria">Categorias</h2>
                <br />
                <asp:DropDownList ID="ddlCategorias" runat="server" OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                <br /><br /><br />
            </div>

            <asp:Repeater ID="rptProdutos" runat="server" ItemType="Library.Model.Produto">
                <HeaderTemplate>
                    <div class="produtos-list">
                </HeaderTemplate>
                    <ItemTemplate>
                        <div class="produtos-card">
                            <img src="assets/img/upload/<%# DataBinder.Eval(Container.DataItem, "Foto") %>" />
                            <h1 class="produtos-name"><%# DataBinder.Eval(Container.DataItem, "Nome") %></h1>
                            <p class="produtos-price"><%# DataBinder.Eval(Container.DataItem, "Val_Unit") %></p>
                            <a class="btnCompre" href="DetalhesProduto.aspx?Produto=<%# DataBinder.Eval(Container.DataItem, "Cod") %>">Comprar</a>
                        </div>
                    </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
          </div>
        </section>
  </div>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />    
</asp:Content>