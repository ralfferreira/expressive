<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cadProdutos.aspx.cs" Inherits="WebAppLoja.cadProdutos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../assets/css/style.css">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400;500;700;900&display=swap" rel="stylesheet">
    <title>Expressive</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cadProdutos-wrapper">
        <div class="cadProdutos-content">
        <div class="cadProdutos-box">
            <h1 class="cad-title">Cadastrar Produtos</h1>
            <label class="label">Nome</label>
            <br />
            <asp:TextBox ID="txtNome" runat="server" MaxLength="50"></asp:TextBox>
        </div>
        <br />
        <div class="cadProdutos-box">
            <label class="label">Descrição</label>
            <br />
            <asp:TextBox ID="txtDesc" runat="server" MaxLength="200" TextMode="MultiLine" CssClass="txtDesc" ForeColor="White"></asp:TextBox>
        </div>
        <br />
        <div class="cadProdutos-box">
            <label class="label">Categoria</label>
            <br />
            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="dropdown-list"></asp:DropDownList>
        </div>
        <br />
        <div class="cadProdutos-box">
            <label class="label">Valor Unitário</label>
            <br />
            <asp:TextBox ID="txtVal_Unit" runat="server" ></asp:TextBox>
        </div>
        <br />
        <div class="cadProdutos-box">
            <label class="label">Estoque</label>
            <br />
            <asp:TextBox ID="txtEstoque" runat="server" TextMode="Number">0</asp:TextBox>
        </div>
        <br />
        <div class="cadProdutos-box">
            <label class="label">Imagem</label>
            <br />
            <asp:FileUpload ID="fuImagem" runat="server" />
            <br />
            <asp:Label ID="lblImagem" runat="server" CssClass="label" ForeColor="White"></asp:Label>
            <br />
            <asp:Button ID="btnSalvarImg" CssClass="btnSalvarIMG" runat="server" Text="Salvar Imagem" OnClick="btnSalvarImg_Click" />
        </div>
        <br />
            <asp:Label ID="lblMensagem" runat="server" Text="" CssClass="label" ForeColor="White"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnCadastrar" CssClass="btnCadProd" runat="server" Text="Cadastrar" Enabled="False" OnClick="btnCadastrar_Click" />    
            <br /><br />
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" PostBackUrl="~/Admin/admin.aspx" CssClass="btnVoltar" /><br />
             </div>
    </div>
</asp:Content>
