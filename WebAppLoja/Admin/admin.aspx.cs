using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library.Business;

namespace WebAppLoja
{
    public partial class admin : System.Web.UI.Page
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

                CarregarVendedores();
            }
        }
        public void CarregarVendedores()
        {
            List<Funcionario> ListaVendedores = new List<Funcionario>();
            FuncionarioBLL fService = new FuncionarioBLL();

            ListaVendedores = fService.RelatorioVendas();

            rptVendedores.DataSource = ListaVendedores;
            rptVendedores.DataBind();
        }
    }
}