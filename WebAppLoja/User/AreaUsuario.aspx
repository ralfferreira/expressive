<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AreaUsuario.aspx.cs" Inherits="WebAppLoja.AreaUsuario" %>
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
        <div class="areaUsuario-content"> 
            <h1 class="areaUsuario-tittle">Meus Pedidos</h1>
            <asp:Repeater ID="rptAreaUruario" runat="server" ItemType="Library.Model.Pedido">
                <HeaderTemplate>
                    <div class="areaUsuario-list">
                        <table id="areaUsuario-table">
                            <tr>
                                <th>Número do pedido:</th>
                                <th>Data do pedido:</th>
                                <th>Valor:</th>
                                <th>Cliente:</th>
                                <th>Funcionário:</th>
                                <th></th>
                            </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# DataBinder.Eval(Container.DataItem, "Num") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Dt_pedido", "{0:dd/MM/yyyy}") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Valor", "{0:c}") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Cliente.Nome") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Funcionario.Nome") %></td>
                        <td class="btnExcluir"><a class="btnExcluir" href="../index.aspx?num_pedido=<%# DataBinder.Eval(Container.DataItem,"Num") %>">Cancelar</a></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </table>
                    </div>
                </FooterTemplate>
            </asp:Repeater>            
        </div>          
    </div>             
</asp:Content>
