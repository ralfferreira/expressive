<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditarASiMesmo.aspx.cs" Inherits="WebAppLoja.EditarASiMesmo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../assets/css/style.css">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400;500;700;900&display=swap" rel="stylesheet">
    <title>Expressive</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="wrapper_all">
        <header class="header">
            <a href="../index.aspx"><img src="../assets/img/eh o expressive.png" class="logo"/></a>
            <ul class="header-menu">
                <div class="dropdown">
                   <a href="#instrumentos" class="dropbtn">Instrumentos</a>
                    <div class="dropdown-content" id="dropdown-instrumentos">
                      <a href="#">Guitarras</a>
                      <a href="#">Pianos</a>
                      <a href="#">Violinos</a>
                      <a href="../produtos.aspx">Ver mais +</a>
                    </div>
                    </div>
                <div class="dropdown">
                   <a href="#calcados" class="dropbtn">Calçados</a>
                    <div class="dropdown-content" id="dropdown-calcados">
                      <a href="#">Kyrie</a>
                      <a href="#">Jordan</a>
                      <a href="../produtos.aspx">Ver mais +</a>
                    </div>
                    </div>
                <div class="dropdown">
                   <a href="#relogios" class="dropbtn">Relógios</a>
                    <div class="dropdown-content" id="dropdown-relogio">
                      <a href="#">Relógios Desert</a>
                      <a href="#">Relógios Rolex</a>
                      <a href="../produtos.aspx">Ver mais +</a>
                    </div>
                </div>
                <a href="../Carrinho.aspx"><img class="carrinho-icon" src="../assets/img/carrinho.png"/></a>                                
                <div class="dropdown">
                    <a href="#relogios" class="dropbtn">Opções</a>
                    <div class="dropdown-content" id="dropdown-options">
                        <a href="AreaUsuario.aspx">Meus Pedidos</a>
                        <a href="EditarASiMesmo.aspx">Editar Perfil</a>
                        <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btnLogout" PostBackUrl="~/Logout.aspx" />
                    </div>
                </div>
            </ul>
        </header>
        <div class="editarASiMesmo-content">          
            <h1 class="editarASiMesmo-tittle">Meu Perfil</h1>
            <img class="editarASiMesmo-img" src="../assets/img/perfil.png" />                         
            <grid class="editarASiMesmo-gridMaior">
                <grid class="editarASiMesmo-grid1">
                    <h2 class="editarASiMesmo-gridText">Nome</h2>
                    <asp:TextBox CssClass="editarASiMesmo-txtbox" ID ="txtNome" runat="server" MaxLength="50"></asp:TextBox>

                    <asp:HiddenField ID="hfTipo" runat="server" Visible="False"></asp:HiddenField>

                    <h2 class="editarASiMesmo-gridText">Endereço</h2>
                    <asp:TextBox CssClass="editarASiMesmo-txtbox" ID="txtEndereco" runat="server" MaxLength="30"></asp:TextBox>

                    <h2 class="editarASiMesmo-gridText">Cidade</h2>
                    <asp:TextBox CssClass="editarASiMesmo-txtbox" ID="txtCidade" runat="server" MaxLength="15"></asp:TextBox>
                    
                    <h2 class="editarASiMesmo-gridText">CPF</h2>
                    <asp:TextBox CssClass="editarASiMesmo-txtbox" ID="txtCPF" runat="server" ReadOnly="True"></asp:TextBox>  
                </grid>
                <grid class="editarASiMesmo-grid2">
                    <h2 class="editarASiMesmo-gridText">CEP</h2>
                    <asp:TextBox CssClass="editarASiMesmo-txtbox" ID="txtCEP" runat="server" MaxLength="8"></asp:TextBox>

                    <h2 class="editarASiMesmo-gridText">UF</h2>
                    <asp:TextBox CssClass="editarASiMesmo-txtbox" ID="txtUF" runat="server" MaxLength="2"></asp:TextBox>
                    
                    <h2 class="editarASiMesmo-gridText">Email</h2>
                    <asp:TextBox CssClass="editarASiMesmo-txtbox" ID="txtEmail" runat="server" ReadOnly="True"></asp:TextBox>  
                    
                    <h2 class="editarASiMesmo-gridText">Senha</h2>
                    <asp:TextBox CssClass="editarASiMesmo-txtbox" ID="txtSenha" runat="server" MaxLength="15" TextMode="Password"></asp:TextBox>    
                </grid>
            </grid>
            <asp:Label ID="lblMensagem" runat="server" Visible="False" CssClass="label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="button-salvar-edit" OnClick="btnSalvar_Click" />
        </div>
    </div>
</asp:Content>
