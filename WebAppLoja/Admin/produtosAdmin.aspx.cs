using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library.Business;
using Library.Model;

namespace WebAppLoja.Admin
{
    public partial class produtosAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TipoUser"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            if (Session["TipoUser"].ToString() != "F")
            {
                Response.Redirect("../User/AreaUsuario.aspx");
            }
            if (!Page.IsPostBack)
            {
                Funcionario f = (Funcionario)Session["login"];

                if (f.Cargo != "Admin")
                {
                    Response.Redirect("../User/AreaUsuario.aspx");
                }

                CarregarProduto();
            }
        }
        public void CarregarProduto()
        {
            List<Produto> ListaProdAdmin = new List<Produto>();
            ProdutoBLL prodService = new ProdutoBLL();

            ListaProdAdmin = prodService.SelecionarTodos();

            rptProdAdmin.DataSource = ListaProdAdmin;
            rptProdAdmin.DataBind();
        }
    }
}