<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebAppLoja.index" %>
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
    <section id="instrumentos">
        <div class="instrumentos-content">
            <div class="instrumentos-text">
                <h1 class="instrumentos-title">Instrumentos</h1>
                <h1 class="instrumentos-subtitle">De alta qualidade</h1>
                <p class="instrumentos-description">Os melhores instrumentos musicais você encontra aqui! Desde <span class="font-regular">guitarras, pianos</span> e <span class="font-regular">violinos</span>.</p>
                <asp:Button ID ="Button3" runat="server" Text="Compre" CssClass="btnCompreInstrumentos" PostBackUrl="~/produtos.aspx" />
            </div>
            <div class="instrumentos-background">
            </div>
        </div>
    </section>

    <section id="calcados">
        <asp:Button ID ="btnCompreCalcados" runat="server" Text="Compre" CssClass="btnCompreCalcados" PostBackUrl="~/produtos.aspx" />
    </section>

    <section id="relogios">
        <div class="relogios-content">
            <div class="relogios-text">
            <h1 class="relogios-title">Artesanais tradicionais</h1>
            <p class="relogios-description">A <span class="expressive-span">Expressive</span>, sinônimo de cultura de escrita requintada, segue valores duradouros como qualidade e técnica artesanal tradicional.
            Suas firmes exigências quanto a formato, estilo, materiais e execução estão refletidas em todos os seus produtos.</p>
            </div>
            <div class="relogios-banner">
                <img src="assets/img/clock2.png" class="relogio-banner-img">
                <img src="assets/img/clock1.png" class="relogio-banner-img">
                <img src="assets/img/clock3.png" class="relogio-banner-img">
            </div>

            <div class="relogios-precos">
                <div class="relogios-card">
                    <img src="assets/img/clock2_front.png" class="relogio-card-img">
                    <h1 class="relogio-nome">Relógio Desert Masculino Nylon Preto e Cinza</h1>
                    <asp:Button ID ="Button4" runat="server" Text="Veja mais" CssClass="btnComprarRelogio" PostBackUrl="~/produtos.aspx" />
                </div>

                <div class="relogios-card">
                    <img src="assets/img/clock1_front.png" class="relogio-card-img">
                    <h1 class="relogio-nome">Relógio Desert Masculino Couro Marrom</h1>
                    <asp:Button ID ="Button5" runat="server" Text="Veja mais" CssClass="btnComprarRelogio" PostBackUrl="~/produtos.aspx" />
                </div>

                <div class="relogios-card">
                    <img src="assets/img/clock3_front.png" class="relogio-card-img">
                    <h1 class="relogio-nome">Relógio Desert Unissex Nylon Verde</h1>
                    <asp:Button ID ="Button6" runat="server" Text="Veja mais" CssClass="btnComprarRelogio" PostBackUrl="~/produtos.aspx" />
                </div>
            </div>
        </div>
    </section>
  </div>
</asp:Content>