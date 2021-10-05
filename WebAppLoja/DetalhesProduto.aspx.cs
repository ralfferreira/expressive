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
    public partial class DetalhesProduto : System.Web.UI.Page
    {
        Pedido cart;
        ProdutoBLL prodService = new ProdutoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["Produto"] == null)
            {
                Response.Redirect("index.aspx");
            }
            if (!Page.IsPostBack)
            {                
                int ProdutoEscolhido = Convert.ToInt32(Request.QueryString["Produto"]);
                CarregarProduto(ProdutoEscolhido);                
            }            
        }

        public void CarregarProduto(int cod)
        {
            Produto p = prodService.SelecionarPorCod(cod);

            imgFoto.ImageUrl = "assets/img/upload/" + p.Foto;
            lblNome.Text = p.Nome;
            lblDesc.Text = p.Descricao;
            lblCategoria.Text = p.Categoria;
            lblPreco.Text = string.Format("{0:c}", p.Val_unit);
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (Session["TipoUser"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if(Session["Carrinho"] == null)
            {
                cart = new Pedido() {
                    Pr_entrega = 14
                };
            }
            else
            {
                cart = (Pedido)Session["Carrinho"];
                try
                {
                    int cod = Convert.ToInt32(hfCod.Value);

                    if (VerificarProduto(cod))
                    {
                        throw new Exception("Produto já adicionado no carrinho");
                    }

                    Item_Pedido item = new Item_Pedido()
                    {
                        Produto = prodService.SelecionarPorCod(cod),
                        Qtd = 1,
                        CodProduto = cod,
                        NumPedido = cart.Num
                    };
                    cart.Produtos.Add(item);

                    if (Session["TipoUser"].ToString() == "F")
                    {
                        Funcionario f = (Funcionario)Session["Funcionario"];
                        cart.Funcionario = f;
                    }
                    else
                    {
                        Cliente c = (Cliente)Session["Session"];
                        cart.Cliente = c;
                    }
                }
                catch (Exception ex)
                {
                    lblMensagem.Text = ex.Message;
                }
            }            
        }

        public bool VerificarProduto(int cod)
        {
            bool adicionado = false;
            foreach (Item_Pedido item in cart.Produtos)
            {
                if(item.Produto.Cod == cod)
                {
                    adicionado = true;
                }
            }
            return adicionado;
        }
    }
}