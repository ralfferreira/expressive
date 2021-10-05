<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cadFuncionario.aspx.cs" Inherits="WebAppLoja.cadFuncionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../assets/css/style.css">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400;500;700;900&display=swap" rel="stylesheet">
    <title>Expressive</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cadFunc-wrapper">
        <div class="cadFunc-content">
        <div class="cadFunc-box">
            <h1 class="cad-title">Cadastrar Funcionários</h1>
            <label class="label">Nome</label>
            <br />
            <asp:TextBox ID="txtNome" runat="server" MaxLength="50"></asp:TextBox>
        </div>
        <br />
        <div class="cadFunc-box">
            <label class="label">Cargo</label>
            <br />
            <asp:DropDownList ID="ddlCargo" runat="server"></asp:DropDownList>
        </div>
        <br />
        <div class="cadFunc-box">
            <label class="label">Endereco</label>
            <br />
            <asp:TextBox ID="txtEndereco" runat="server" MaxLength="30"></asp:TextBox>
        </div>
        <br />
        <div class="cadFunc-box">
            <label class="label">Cidade</label>
            <br />
            <asp:TextBox ID="txtCidade" runat="server" MaxLength="15"></asp:TextBox>
        </div>
        <br />
        <div class="cadFunc-box">
            <label class="label">CEP</label>
            <br />
            <asp:TextBox ID="txtCEP" runat="server" MaxLength="8"></asp:TextBox>
        </div>
        <br />
        <div class="cadFunc-box">
            <label class="label">UF</label>
            <br />
            <asp:TextBox ID="txtUF" runat="server" MaxLength="2"></asp:TextBox>
        </div>
        <br />
        <div class="cadFunc-box">
            <label class="label">CPF</label>
            <br />
            <asp:TextBox ID="txtCPF" runat="server" MaxLength="11"></asp:TextBox>
        </div>
        <br />
        <div class="cadFunc-box">
            <label class="label">Salário</label>
            <br />
            <asp:TextBox ID="txtSalario" runat="server"></asp:TextBox>
        </div>
        <br />
        <div class="cadFunc-box">
            <label class="label">Email</label>
            <br />
            <asp:TextBox ID="txtEmail" runat="server" MaxLength="50"></asp:TextBox>
        </div>
        <br />
        <div class="cadFunc-box">
            <label class="label">Senha</label>
            <br />
            <asp:TextBox ID="txtSenha" runat="server" MaxLength="15"></asp:TextBox>
        </div>
        <br />
        <div class="cadFunc-box">
            <label class="label">Comissão</label>
            <br />
            <asp:DropDownList ID="ddlComissao" runat="server"></asp:DropDownList>
        </div>                
        <br />
            <asp:Label ID="lblMensagem" runat="server" CssClass="label" ForeColor="White" ></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnCadastrarFunc" CssClass="btnCadFunc" runat="server" Text="Cadastrar" OnClick="btnCadastrarFunc_Click" />
            <br /><br />
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" PostBackUrl="~/Admin/admin.aspx" CssClass="btnVoltar"/>
            <br /><br /><br /><br /><br /><br /><br />
    </div>
    </div>
</asp:Content>
