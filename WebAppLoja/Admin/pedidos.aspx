<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pedidos.aspx.cs" Inherits="WebAppLoja.pedidos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" href="../assets/css/style.css">
<link rel="preconnect" href="https://fonts.gstatic.com">
<link href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400;500;700;900&display=swap" rel="stylesheet">
<title>Expressive</title>
</head>
<body class="restrict-body">
    <form id="form1" runat="server">
        <div class="menu-wrap">
            <input type="checkbox" class="toggler">
            <div class="hamburger">
                <div>
                </div>
            </div>
            <div class="menu">
            <div>
                <div>
                    <ul>
                        <h2 class="profile-name">Admin</h2>                        
                        <a href="#">
                        <asp:Button ID ="btnLogout" runat="server" Text="Sair" CssClass="btnComprarRelogio" PostBackUrl="~/Logout.aspx" />
                        </a>
                    </ul>
                </div>
            </div>
            </div>
        </div>
        <div class="restrict-wrapper">
            <div class="restrict-header-wrapper">
            <header class="restrict-header">
                <a href="#"><img src="../assets/img/eh o expressive.png" class="restrict-logo"/></a>
                <div class="restrict-header-box">
                    <a href="admin.aspx">
                        <img class="restrict-header-icon" src="../assets/img/icon1-header.png"/>
                        <h2 class="restrict-header-links">Dashboard</h2>
                    </a>
                </div>
                <div class="restrict-header-box">
                    <a href="pedidos.aspx">
                        <img class="restrict-header-icon" src="../assets/img/icon2-header_ativo.png"/>
                        <h2 class="restrict-header-links-ativo">Pedidos</h2>
                    </a>
                </div>
                <div class="restrict-header-box">
                    <a href="funcionarios.aspx">
                        <img class="restrict-header-icon" src="../assets/img/icon3-header.png"/>
                        <h2 class="restrict-header-links">Funcionários</h2>
                    </a>
                </div>
                <div class="restrict-header-box">
                    <a href="produtosAdmin.aspx">
                        <img class="restrict-header-icon" src="../assets/img/icon4-header.png"/>
                        <h2 class="restrict-header-links">Produtos</h2>
                    </a>
                </div>
            </header>
            </div>

            <div class="restrict-content">
                <div>
                <h1 class="restrict-title">Todos os pedidos</h1>
                    <asp:Repeater ID="rptPedidos" runat="server" ItemType="Library.Model.Pedido">
                        <HeaderTemplate>
                            <div class="orders-admin-list">
                                <table id="orders-admin-table">
                                    <tr>
                                        <th>Número do pedido</th>
                                        <th>Data do pedido</th>
                                        <th>Valor</th>
                                        <th>Cliente</th>
                                        <th>Funcionário</th>
                                    </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# DataBinder.Eval(Container.DataItem, "Num") %></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "Dt_pedido", "{0:dd/MM/yyyy}") %></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "Valor") %></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "Cliente.Nome") %></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "Funcionario.Cargo") %> <%# DataBinder.Eval(Container.DataItem, "Funcionario.Nome") %></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                                </table>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div> 
        </div>
    </form>
</body>
</html>