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
    public partial class Carrinho : System.Web.UI.Page
    {        
        Pedido cart;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TipoUser"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                if (Session["Carrinho"] != null)
                {
                    cart = (Pedido)Session["Carrinho"];
                }
                else
                {
                    cart = new Pedido() {
                        Pr_entrega = 14
                    };

                    if(Session["TipoUser"].ToString() == "F")
                    {
                        Funcionario f = (Funcionario)Session["login"];
                        cart.Funcionario = f;
                    }
                    else
                    {
                        Cliente c = (Cliente)Session["login"];
                        cart.Cliente = c;
                    }

                    Session["Carrinho"] = cart;
                }
                if (!Page.IsPostBack)
                {
                    CarregarInfo(Session["TipoUser"].ToString());
                }
            }            
        }

        public void CarregarInfo(string tipo)
        {
            gvCarrinho.DataSource = cart.Produtos;
            gvCarrinho.DataBind();

            lblPrazo.Text = string.Format("{0} dias",cart.Pr_entrega.ToString());

            cart.CalcularValorTotal();

            if (tipo == "C")
            {
                Cliente c = (Cliente)Session["login"];

                lblNome.Text = c.Nome;
                lblEndereco.Text = c.Endereco;
                lblCidade.Text = c.Cidade;
                lblUF.Text = c.Uf;
                lblCEP.Text = c.Cep;
                CarregarVendedores();
            }
            else
            {
                Funcionario f = (Funcionario)Session["login"];

                lblNome.Text = f.Nome;
                lblEndereco.Text = f.Endereco;
                lblCidade.Text = f.Cidade;
                lblUF.Text = f.Uf;
                lblCEP.Text = f.Cep;
            }
        }

        public void CarregarVendedores()
        {
            FuncionarioBLL fService = new FuncionarioBLL();
            List<Funcionario> funcionarios = fService.SelecionarTodos();
            List<Funcionario> vendedores = (from r in funcionarios
                                            where !r.Cargo.Equals("Admin")
                                            select r).ToList();

            int index = 1;
            ddlVendedor.Items.Insert(0, new ListItem("--SELECIONE--","0"));
            foreach  (Funcionario vendedor in vendedores)
            {
                ddlVendedor.Items.Insert(index, new ListItem(vendedor.Nome, vendedor.Cod.ToString()));
            }
            panVendedor.Visible = true;
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session["Carrinho"] = null;
            gvCarrinho.DataSource = null;
            gvCarrinho.DataBind();
        }
    }
}