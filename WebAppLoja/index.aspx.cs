using Library.Business;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppLoja
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["num_pedido"] != null)
            {
                int num = Convert.ToInt32(Request.QueryString["num_pedido"]);

                PedidoBLL pService = new PedidoBLL();
                Pedido p = pService.SelecionarPorCod(num);

                pService.Deletar(p.Num);
                Response.Redirect("User/AreaUsuario.aspx");
            }
            if (!Page.IsPostBack)
            {
                if (Session["TipoUser"] != null)
                {
                    panLogin.Visible = false;
                    panOptions.Visible = true;

                    Pedido Carrinho = (Pedido)Session["Carrinho"];

                    string tipo = Session["TipoUser"].ToString();
                    if (tipo == "C")
                    {
                        Cliente c = (Cliente)Session["login"];
                    }
                    else
                    {
                        Funcionario f = (Funcionario)Session["login"];
                    }
                }
            }            
        }
    }
}