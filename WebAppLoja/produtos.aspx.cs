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
    public partial class produtos : System.Web.UI.Page
    {
        ProdutoBLL prodService = new ProdutoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarCategorias();
                CarregarProdutos();

                if(Session["TipoUser"] != null)
                {
                    panLogin.Visible = false;
                    panOptions.Visible = true;

                    if (Session["TipoUser"].ToString() == "C")
                    {
                        Cliente c = (Cliente)Session["login"];
                    }
                    else
                    {
                        Funcionario f = (Funcionario)Session["login"];
                    }
                    if(Session["Carrinho"] != null)
                    {
                        Pedido cart  = (Pedido)Session["Carrinho"];
                    }
                    else
                    {
                        Pedido cart = new Pedido() { Pr_entrega = 14 };
                    }
                }
                else
                {
                    panLogin.Visible = true;
                    panOptions.Visible = false;
                }
            }
        }

        public void CarregarProdutos()
        {
            List<Produto> Lista = new List<Produto>();           
            Lista = prodService.SelecionarTodos();

            rptProdutos.DataSource = Lista;
            rptProdutos.DataBind();
        }

        public void CarregarCategorias()
        {
            ddlCategorias.Items.Insert(0, new ListItem("Todos os Produtos", "Todos"));
            ddlCategorias.Items.Insert(1, new ListItem("Instrumentos", "Instrumentos"));
            ddlCategorias.Items.Insert(2, new ListItem("Calçados", "Calçados"));
            ddlCategorias.Items.Insert(3, new ListItem("Acessório", "Acessórios"));
        }

        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {           
            int opcao = ddlCategorias.SelectedIndex;
            if(opcao == 1)
            {
                List<Produto> Lista = new List<Produto>();
                Lista = prodService.SelecionarTodos();
                List<Produto> listaFiltrada = (from r in Lista
                                               where r.Categoria.Equals("Instrumentos")
                                               select r).ToList();

                rptProdutos.DataSource = listaFiltrada;
                rptProdutos.DataBind();
            }
            else if(opcao == 2)
            {
                List<Produto> Lista = new List<Produto>();
                Lista = prodService.SelecionarTodos();
                List<Produto> listaFiltrada = (from r in Lista
                                               where r.Categoria.Equals("Calçados")
                                               select r).ToList();

                rptProdutos.DataSource = listaFiltrada;
                rptProdutos.DataBind();
            }
            else if(opcao == 3)
            {
                List<Produto> Lista = new List<Produto>();
                Lista = prodService.SelecionarTodos();
                List<Produto> listaFiltrada = (from r in Lista
                                               where r.Categoria.Equals("Acessórios")
                                               select r).ToList();

                rptProdutos.DataSource = listaFiltrada;
                rptProdutos.DataBind();
            }
            else
            {
                CarregarProdutos();
            }
        }        
    }
}