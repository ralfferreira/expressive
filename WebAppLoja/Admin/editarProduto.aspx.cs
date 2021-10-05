using Library.Business;
using Library.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppLoja.Admin
{
    public partial class editarProduto : System.Web.UI.Page
    {
        ProdutoBLL prodService = new ProdutoBLL();

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
                if (Request.QueryString["cod_prod"] != null)
                {
                    int cod = Convert.ToInt32(Request.QueryString["cod_prod"]);

                    if (Request.QueryString["excluir"] != null)
                    {
                        prodService.Deletar(cod);

                        Response.Redirect("produtosAdmin.aspx");
                    }
                    CarregarCategorias();
                    CarregarProduto(cod);                    
                }
            }
        }

        public void CarregarCategorias()
        {
            ddlCategoria.Items.Insert(0, new ListItem("---SELECIONE---", "0"));
            ddlCategoria.Items.Insert(1, new ListItem("Instrumentos", "Instrumentos"));
            ddlCategoria.Items.Insert(2, new ListItem("Calçados", "Calçados"));
            ddlCategoria.Items.Insert(3, new ListItem("Acessório", "Acessórios"));
        }

        public void CarregarProduto(int cod)
        {
            Produto p = prodService.SelecionarPorCod(cod);

            imgFoto.ImageUrl = "../assets/img/upload/" + p.Foto;
            txtName.Text = p.Nome;
            txtDescricao.Text = p.Descricao;
            txtEstoque.Text = p.Estoque.ToString();
            txtValor.Text = p.Val_unit.ToString();
            hfCod.Value = p.Cod.ToString();
            Session["path"] = p.Foto;
        }

        protected void btnSalvarImg_Click(object sender, EventArgs e)
        {
            File.Delete("../assets/img/upload/" + Session["path"].ToString());

            if (fuImagem.PostedFile.ContentLength < 8388608)
            {
                try
                {
                    if (fuImagem.HasFile)
                    {
                        try
                        {
                            //Aqui ele vai filtrar pelo tipo de arquivo
                            if (fuImagem.PostedFile.ContentType == "image/jpeg" ||
                                fuImagem.PostedFile.ContentType == "image/png")
                            {
                                try
                                {
                                    //Obtem o  HttpFileCollection
                                    HttpFileCollection hfc = Request.Files;
                                    for (int i = 0; i < hfc.Count; i++)
                                    {
                                        HttpPostedFile hpf = hfc[i];
                                        if (hpf.ContentLength > 0)
                                        {
                                            //Pega o nome do arquivo
                                            string nome = Path.GetFileName(hpf.FileName);
                                            //Pega a extensão do arquivo
                                            string extensao = Path.GetExtension(hpf.FileName);
                                            //Gera nome novo do Arquivo numericamente
                                            string filename = string.Format("{0:00000000000000}", GerarID());
                                            Session["path"] = filename + i + extensao;
                                            //Caminho a onde será salvo
                                            hpf.SaveAs(Server.MapPath("~/assets/img/upload/") + filename + i
                                            + extensao);
                                        }
                                        imgFoto.ImageUrl = "../assets/img/upload/" + Session["path"].ToString();
                                    }
                                    
                                }
                                catch (Exception ex)
                                {
                                    lblImagem.Text = ex.Message;
                                }
                                // Mensagem se tudo ocorreu bem
                                lblImagem.Text = "Todas imagens carregadas com sucesso!";

                            }
                            else
                            {
                                // Mensagem notifica que é permitido carregar apenas
                                // as imagens definida la em cima.
                                lblImagem.Text = "É permitido carregar apenas imagens!";
                            }
                        }
                        catch (Exception ex)
                        {
                            // Mensagem notifica quando ocorre erros
                            lblImagem.Text = "O arquivo não pôde ser carregado." +
                                "O seguinte erro ocorreu: " + ex.Message;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Mensagem notifica quando ocorre erros
                    lblImagem.Text = "O arquivo não pôde ser carregado." +
                        "O seguinte erro ocorreu: " + ex.Message;
                }
            }
            else
            {
                // Mensagem notifica quando imagem é superior a 8 MB
                lblImagem.Text = "Não é permitido carregar mais do que 8 MB";
            }
        }

        public Int64 GerarID()
        {
            Int64 e = 12;
            try
            {
                DateTime data = new DateTime();
                data = DateTime.Now;
                string s = data.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
                return Convert.ToInt64(s);
            }
            catch (Exception erro)
            {
                lblImagem.Text = erro.Message;
                return e;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtName.Text) || string.IsNullOrWhiteSpace(txtName.Text))
                {
                    throw new Exception("O Nome é obrigatório");
                }
                if (string.IsNullOrWhiteSpace(txtDescricao.Text) || string.IsNullOrEmpty(txtDescricao.Text))
                {
                    throw new Exception("A Descrição do produto deve ser informada");
                }
                if (ddlCategoria.SelectedIndex == 0)
                {
                    throw new Exception("A Categoria deve ser informada");
                }
                if (Convert.ToInt32(txtEstoque.Text) < 0)
                {
                    throw new Exception("O Estoque não pode ser negativo");
                }
                if(string.IsNullOrWhiteSpace(txtValor.Text) || string.IsNullOrEmpty(txtValor.Text))
                {
                    throw new Exception("O Preço do produto deve ser informado");
                }
                try
                {
                    decimal preco = Convert.ToDecimal(txtValor.Text);
                    if(preco < 0)
                    {
                        throw new Exception("O Preço não pode ser negativo");
                    }

                    Produto p = prodService.SelecionarPorCod(Convert.ToInt32(hfCod.Value));

                    p.Nome = txtName.Text;
                    p.Foto = Session["path"].ToString();
                    p.Descricao = txtDescricao.Text;
                    p.Val_unit = preco;
                    p.Categoria = ddlCategoria.SelectedValue;
                    p.Estoque = Convert.ToInt32(txtEstoque.Text);

                    if (prodService.Atualizar(p))
                    {
                        lblMensagem.Text = "Produto Atualizado com sucesso";
                    }
                    else
                    {
                        lblMensagem.Text = "Não foi possivel atualizar o produto";
                    }
                }
                catch(Exception ex)
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