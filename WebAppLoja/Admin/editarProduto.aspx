<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editarProduto.aspx.cs" Inherits="WebAppLoja.Admin.editarProduto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../assets/css/style.css">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400;500;700;900&display=swap" rel="stylesheet">
    <title>Expressive</title>
</head>
<body class="editarProduto"><form runat="server" id="form1">
    <div class="wrapper_all">
        <div class="editarProduto-content">          
            <h1 class="editarProduto-title">Editar Produto</h1>
            <asp:Image ID="imgFoto" runat="server" />
     
            <grid class="editarProduto-gridMaior">
                <grid class="editarProduto-grid1"><asp:HiddenField ID="hfCod" runat="server" Visible="False"></asp:HiddenField>
                    <h2 class="editarProduto-gridText">Nome</h2>
                    <asp:TextBox CssClass="editarProduto-txtbox" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                    <h2 class="editarProduto-gridText">Descrição</h2>
                    <asp:TextBox CssClass="editarProduto-txtbox" ID="txtDescricao" runat="server" MaxLength="200"></asp:TextBox>          
                </grid>
                <grid class="editarProduto-grid2">
                    <h2 class="editarProduto-gridText">Categoria</h2>
                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="dropdown-list"></asp:DropDownList>
                    <label class="editarProduto-gridText">Imagem</label>
                    <br />
                    <asp:FileUpload ID="fuImagem" runat="server" />
                    <br />
                    <asp:Label ID="lblImagem" runat="server"></asp:Label>
                    <br />
                    <asp:Button ID="btnSalvarImg" CssClass="btnSalvarIMG" runat="server" Text="Salvar Imagem" OnClick="btnSalvarImg_Click" />
                </grid>
                <grid class="editarProduto-grid3">
                    <h2 class="editarProduto-gridText">Estoque</h2>
                    <asp:TextBox CssClass="editarProduto-txtbox" ID="txtEstoque" runat="server" TextMode="Number" MaxLength="10"></asp:TextBox>
                    <h2 class="editarProduto-gridText">Valor Unitário</h2>
                    <asp:TextBox CssClass="editarProduto-txtbox" ID="txtValor" runat="server" MaxLength="15"></asp:TextBox>
                </grid>
                <asp:Label ID="lblMensagem" runat="server" Text="" CssClass="label"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="button-salvar" OnClick="btnSalvar_Click"></asp:Button>                
                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btnVoltar" PostBackUrl="~/Admin/produtosAdmin.aspx"></asp:Button>
                <br /><br /><br /><br />
            </grid>
         
            
        </div>
    </div></form>
</body>
</html>
