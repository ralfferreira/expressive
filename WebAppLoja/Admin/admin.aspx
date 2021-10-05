<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="WebAppLoja.admin" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

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
                        <img class="restrict-header-icon" src="../assets/img/icon1-header_ativo.png"/>
                        <h2 class="restrict-header-links-ativo">Dashboard</h2>
                    </a>
                </div>
                <div class="restrict-header-box">
                    <a href="pedidos.aspx">
                        <img class="restrict-header-icon" src="../assets/img/icon2-header.png"/>
                        <h2 class="restrict-header-links">Pedidos</h2>
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
                <h1 class="restrict-title">Vendedores mais rentáveis</h1>
                    <asp:Repeater ID="rptVendedores" runat="server" ItemType="Library.Model.Funcionario">
                        <HeaderTemplate>
                            <div class="restrict-sellers-list">
                                <table id="sellers-admin-table">
                                    <tr>
                                    <th>Nome</th>
                                    <th>Número de Vendas</th>
                                    <th>Valor Total</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# DataBinder.Eval(Container.DataItem, "Nome") %></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "Vendas") %></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "ValorTotal") %></td>
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
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.3/Chart.bundle.js" integrity="sha512-G8JE1Xbr0egZE5gNGyUm1fF764iHVfRXshIoUWCTPAbKkkItp/6qal5YAHXrxEu4HNfPTQs6HOu3D5vCGS1j3w==" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.3/Chart.min.js" integrity="sha512-s+xg36jbIujB2S2VKfpGmlC3T5V2TF3lY48DX7u2r9XzGzgPsa6wTpOQA7J9iffvdeBN0q9tKzRxVxw1JviZPg==" crossorigin="anonymous"></script>
    <script src="../assets/js/main.js"></script>
</body>
</html>
