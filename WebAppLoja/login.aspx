<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebAppLoja.login" %>
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
    <div class="login-wrap">
	<div class="login-html">
		<a href="index.aspx"><img src="assets/img/eh o expressive.png" class="logo"/></a>
		<br />
		<br />
		<input id="tab-1" type="radio" name="tab" class="sign-in" checked><label for="tab-1" class="tab">Login</label>
		<input id="tab-2" type="radio" name="tab" class="sign-up"><label for="tab-2" class="tab">Registre-se</label>
		<div class="login-form">
			<div class="sign-in-htm">
				<div class="group">
					<label for="txtLoginUser" class="label">Email</label>
					<br />
					<asp:TextBox ID="txtLoginUser" runat="server" CssClass="input" MaxLength="50"></asp:TextBox>
				</div>
				<div class="group">
					<label for="txtLoginPass" class="label">Senha</label>
					<br />
                    <asp:TextBox ID="txtLoginPass" runat="server" CssClass="input" MaxLength="15" TextMode="Password"></asp:TextBox>
				</div>
				<div class="group">
                    <asp:Label ID="lblMensagem" runat="server" Visible="True" CssClass="label" Text=""></asp:Label>
                    <br />
                    <br />
					<asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="button" OnClick="btnLogin_Click" />
				</div>
			</div>
			<div class="sign-up-htm">
				<div class="group">
					<label for="txtNome" class="label">Nome</label>
					<br />
					<asp:TextBox ID="txtNome" runat="server" CssClass="input" MaxLength="50"></asp:TextBox>
				</div>
				<div class="group">
					<label for="txtEndereco" class="label">Endereço</label>
					<br />
					<asp:TextBox ID="txtEndereco" runat="server" CssClass="input" MaxLength="30"></asp:TextBox>
				</div>
				<div class="group">
					<label for="txtCidade" class="label">Cidade</label>
					<br />
                    <asp:TextBox ID="txtCidade" runat="server" CssClass="input" MaxLength="15"></asp:TextBox>
				</div>
                <div class="group">
					<label for="txtCEP" class="label">CEP</label>
					<br />
                    <asp:TextBox ID="txtCEP" runat="server" CssClass="input" MaxLength="8"></asp:TextBox>
				</div>
                <div class="group">
					<label for="txtUF" class="label">UF</label>
					<br />
                    <asp:TextBox ID="txtUF" runat="server" CssClass="input" MaxLength="2"></asp:TextBox>
				</div>
                <div class="group">
					<label for="txtCPF" class="label">CPF</label>
					<br />
                    <asp:TextBox ID="txtCPF" runat="server" CssClass="input" MaxLength="11"></asp:TextBox>
				</div>
                <div class="group">
					<label for="txtEmail" class="label">Email</label>
					<br />
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="input" MaxLength="50"></asp:TextBox>
				</div>
                <div class="group">
					<label for="txtSenha" class="label">Senha</label>
					<br />
                    <asp:TextBox ID="txtSenha" runat="server" CssClass="input" MaxLength="15" TextMode="Password"></asp:TextBox>
				</div>
				<div class="group">
					<asp:Label ID="lblRegistro" runat="server" Visible="True" CssClass="label" Text=""></asp:Label>
                    <br />
                    <br />
					<asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="button" OnClick="btnRegistrar_Click"/>
				</div>
				
			</div>
		</div>
    </div>
</div>
</asp:Content>
