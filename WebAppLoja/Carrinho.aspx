<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Carrinho.aspx.cs" Inherits="WebAppLoja.Carrinho" %>
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
                <a href="carrinho.aspx"><img class="carrinho-icon" src="assets/img/carrinho.png"/></a>                    
                <asp:Panel ID="panLogin" runat="server" Visible="True">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btnLogin" PostBackUrl="~/login.aspx" />
                </asp:Panel>
                <asp:Panel ID="panOptions" runat="server" Visible="False">
                    <div class="dropdown">
                        <a href="#relogios" class="dropbtn">Opções</a>
                        <div class="dropdown-content" id="dropdown-options">
                        <a href="User/EditarASiMesmo.aspx">Editar Perfil</a>
                        <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btnLogout" PostBackUrl="~/Logout.aspx" />
                        </div>
                    </div>
                </asp:Panel> 
            </ul>
        </header>

       <div class="carrinho-content">
           <h1 class="carrinho-title">Carrinho</h1>            
            <asp:GridView ID="gvCarrinho" runat="server" AutoGenerateColumns="False" CssClass="carrinho-table" DataKeyNames="Produto">
                <EmptyDataTemplate>
                        <label class="label">Nenhum item adicionado no carrinho.</label>
                </EmptyDataTemplate>
               <Columns>
                   <asp:BoundField HeaderText="Produto" DataField="Produto.Nome" ReadOnly="True" />
                   <asp:BoundField HeaderText="Quantidade" DataField="Qtd" />
                   <asp:BoundField HeaderText="Preço" DataField="Produto.Val_Unit" ReadOnly="True" />                   
               </Columns>                
            </asp:GridView>           
            <table class="carrinho-resumo">
                <tr>
                    <th>Nome</th>
                    <td>
                        <asp:Label ID="lblNome" runat="server"></asp:Label>
                    </td>             
                </tr>
                <asp:Panel ID="panVendedor" runat="server" Visible="False">
                    <tr>
                        <th>Vendedor</th>
                        <td>
                            <asp:DropDownList ID="ddlVendedor" runat="server"></asp:DropDownList>
                        </td>             
                    </tr>
                </asp:Panel>
                <tr>
                    <th>Endereço</th>
                    <td>
                        <asp:Label ID="lblEndereco" runat="server"></asp:Label>
                    </td>             
                </tr>
                <tr>
                    <th>Cidade</th>
                    <td>
                        <asp:Label ID="lblCidade" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>UF</th>
                    <td>
                        <asp:Label ID="lblUF" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>CEP</th>
                    <td>
                        <asp:Label ID="lblCEP" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>Valor Total</th>
                    <td>
                        <asp:Label ID="lblValorTotal" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>Prazo de Entrega</th>
                    <td>
                        <asp:Label ID="lblPrazo" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>        
        <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar Compra" CssClass="button-finalizar" OnClick="btnFinalizar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="button-cancelar" OnClick="btnCancelar_Click" />
       </div>
   </div>
</a>
</asp:Content>
