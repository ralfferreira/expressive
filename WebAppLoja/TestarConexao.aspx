<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestarConexao.aspx.cs" Inherits="WebAppLoja.TestarConexao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnTestar" runat="server" OnClick="btnTestar_Click" Text="Testar Conexão" />
        </div>
    </form>
</body>
</html>