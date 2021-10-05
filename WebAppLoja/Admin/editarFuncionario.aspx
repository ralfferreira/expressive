<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editarFuncionario.aspx.cs" Inherits="WebAppLoja.Admin.editarFuncionario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../assets/css/style.css">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400;500;700;900&display=swap" rel="stylesheet">
    <title>Expressive</title>
</head>
<%--<body class="editarProduto">
    <form runat="server" id="form1">
    <div class="cadFunc-wrapper">
        <div class="cadFunc-content">
        <div class="cadFunc-box">
            <h1 class="cad-title">Cadastrar Funcionários</h1>
            <label class="label">Nome</label>
            <br />
            <asp:TextBox ID="txtNome" runat="server" MaxLength="50" ReadOnly="True"></asp:TextBox>
            <asp:HiddenField ID="hfCod" runat="server" Visible="False" />
        </div>
        <br />
        <div class="cadFunc-box">
            <label class="label">Cargo</label>
            <br />
            <asp:DropDownList ID="ddlCargo" runat="server"></asp:DropDownList>
        </div>        
        <br />
        <div class="cadFunc-box">
            <label class="label">Salário</label>
            <br />
            <asp:TextBox ID="txtSalario" runat="server"></asp:TextBox>
        </div>
        <br />
        <div class="cadFunc-box">
            <label class="label">Comissão</label>
            <br />
            <asp:DropDownList ID="ddlComissao" runat="server"></asp:DropDownList>
        </div>                
        <br />
            <asp:Label ID="lblMensagem" runat="server" CssClass="label" ForeColor="White"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnEditar" CssClass="btnCadFunc" runat="server" Text="Editar" OnClick="btnEditar_Click" />
            <br /><br />
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" PostBackUrl="~/Admin/funcionarios.aspx" CssClass="btnVoltar"/>
            <br /><br /><br /><br /><br /><br /><br />
    </div>
    </div>
</form>
</body>--%>

    <body class="editarProduto"><form runat="server" id="form1">
    <div class="wrapper_all">
        <div class="editarProduto-content">          
            <h1 class="editarProduto-title">Editar Funcionário</h1>
            <grid class="editarProduto-gridMaior">
                <grid class="editarProduto-grid1"><asp:HiddenField ID="hfCod" runat="server" Visible="False"></asp:HiddenField>
                    <h2 class="editarProduto-gridText">Nome</h2>
                    <asp:TextBox CssClass="editarProduto-txtbox" ID="txtNome" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:HiddenField ID="HiddenField1" runat="server" Visible="False" />
                    <h2 class="editarProduto-gridText">Cargo</h2>
                    <asp:DropDownList ID="ddlCargo" runat="server" CssClass="editarProduto-txtbox"></asp:DropDownList>      
                </grid>
                <grid class="editarProduto-grid2">
                    <h2 class="editarProduto-gridText">Salário</h2>
                    <asp:DropDownList ID="txtSalário" runat="server" CssClass="editarProduto-txtbox"></asp:DropDownList>
                    <br />
                    <h2 class="editarProduto-gridText">Comissão</h2>
                    <asp:DropDownList ID="ddlComissao" runat="server" CssClass="editarProduto-txtbox"></asp:DropDownList>
                </grid>
                <br />
                <asp:Label ID="lblMensagem" runat="server" CssClass="label" ForeColor="White"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btnEditar" CssClass="btnSalvar-editarFunc" runat="server" Text="Editar" OnClick="btnEditar_Click" />
                <br /><br />
                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" PostBackUrl="~/Admin/funcionarios.aspx" CssClass="btnVoltar-editarFunc"/>
                <br /><br /><br /><br />
            </grid>
         
            
        </div>
    </div></form>
</body>
</html>
