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
    public partial class AreaUsuario : System.Web.UI.Page
    {
        PedidoBLL pService = new PedidoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TipoUser"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            if (!Page.IsPostBack)
            {
                if(Session["TipoUser"].ToString() == "F")
                {
                    Funcionario f = (Funcionario)Session["login"];

                    if(f.Cargo == "Admin")
                    {
                        Response.Redirect("../Admin/admin.aspx");
                    }
                    CarregarPedidos(f.Cod, "F");
                }
                else
                {
                    Cliente c = (Cliente)Session["login"];

                    CarregarPedidos(c.Cod, "C");
                }
            }
        }

        public void CarregarPedidos(int cod, string tipo)
        {
            List<Pedido> Lista = new List<Pedido>();
            Lista = pService.SelecionarTodosUser(cod, tipo);

            rptAreaUruario.DataSource = Lista;
            rptAreaUruario.DataBind();
        }
    }
}