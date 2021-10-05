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
    public partial class funcionarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["TipoUser"] == null)
            //{
            //    Response.Redirect("../login.aspx");
            //}
            //if (Session["TipoUser"].ToString() != "F")
            //{
            //    Response.Redirect("../User/AreaUsuario.aspx");
            //}
            if (!Page.IsPostBack)
            {
                //Funcionario f = (Funcionario)Session["login"];

                //if (f.Cargo != "Admin")
                //{
                //    Response.Redirect("../User/AreaUsuario.aspx");
                //}

                CarregarFuncionario();
            }

            
        }
        public void CarregarFuncionario()
        {
            List<Funcionario> ListaFunc = new List<Funcionario>();
            FuncionarioBLL fService = new FuncionarioBLL();

            ListaFunc = fService.SelecionarTodos();

            rptFunc.DataSource = ListaFunc;
            rptFunc.DataBind();
        }
    }
}