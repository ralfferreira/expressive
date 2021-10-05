using Library.Business;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppLoja.Admin
{
    public partial class editarFuncionario : System.Web.UI.Page
    {
        FuncionarioBLL fService = new FuncionarioBLL();

        protected void Page_Load(object sender, EventArgs e)
        {            
            //if (Session["TipoUser"] == null)
            //{
            //    //Response.Redirect("../login.aspx");
            //}
            //if (Session["TipoUser"].ToString() != "F")
            //{
            //    //Response.Redirect("../User/AreaUsuario.aspx");
            //}
            //if (!Page.IsPostBack)
            //{
            //    Funcionario f = (Funcionario)Session["login"];

            //    if (f.Cargo != "Admin")
            //    {
            //        //Response.Redirect("../User/AreaUsuario.aspx");
            //    }
            //    if (Request.QueryString["cod_fun"] != null)
            //    {
            //        int cod = Convert.ToInt32(Request.QueryString["cod_fun"]);                    

            //        if(Request.QueryString["excluir"] != null)
            //        {
            //            fService.Demitir(cod);

            //            Response.Redirect("funcionarios.aspx");
            //        }

            //        CarregarCargos();
            //        CarregarComissoes();
            //        CarregarInformacoes(cod);
            //    }
            //    else
            //    {
            //        Response.Redirect("funcionarios.aspx");
            //    }
            //}
        }

        public void CarregarCargos()
        {
            ddlCargo.Items.Insert(0, new ListItem("---SELECIONE---", "0"));
            ddlCargo.Items.Insert(1, new ListItem("Admin", "Admin"));
            ddlCargo.Items.Insert(2, new ListItem("Vendedor", "Vendedor"));
            ddlCargo.Items.Insert(3, new ListItem("Consultor", "Consultor"));
        }

        public void CarregarComissoes()
        {
            ddlComissao.Items.Insert(0, new ListItem("---SELECIONE---", null));
            ddlComissao.Items.Insert(1, new ListItem("A", "A"));
            ddlComissao.Items.Insert(2, new ListItem("B", "B"));
            ddlComissao.Items.Insert(3, new ListItem("C", "C"));
        }

        public void CarregarInformacoes(int cod)
        {
            Funcionario f = fService.SelecionarPorCod(cod);

            txtNome.Text = f.Nome;
            txtSalario.Text = f.Salario_fixo.ToString();
            hfCod.Value = f.Cod.ToString();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSalario.Text) || string.IsNullOrWhiteSpace(txtSalario.Text))
                {
                    throw new Exception("O Salário deve ser informado");
                }
                if(ddlCargo.SelectedIndex == 0)
                {
                    throw new Exception("O Cargo deve ser selecionado");
                }
                try
                {
                    decimal sal = Convert.ToDecimal(txtSalario.Text);
                    if(sal < 0)
                    {
                        throw new Exception("O Salário não pode ser negativo");
                    }

                    Funcionario f = fService.SelecionarPorCod(Convert.ToInt32(hfCod.Value));

                    f.Salario_fixo = sal;
                    f.Cargo = ddlCargo.SelectedValue;
                    f.Comissao = ddlComissao.SelectedValue;

                    if (fService.AtualizarAdmin(f))
                    {
                        lblMensagem.Text = "Funcionário atualizado com sucesso";
                    }
                    else
                    {
                        lblMensagem.Text = "Não foi possível atualizar o Funcionário";
                    }
                }
                catch (Exception ex)
                {
                    lblMensagem.Text = ex.Message;
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }
    }
}