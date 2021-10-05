using Library.Business;
using Library.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppLoja
{
    public partial class cadProdutos : System.Web.UI.Page
    {
        ProdutoBLL pService = new ProdutoBLL();

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

                CarregarCategorias();
                Session["path"] = "";                
            }
        }

        protected void btnSalvarImg_Click(object sender, EventArgs e)
        {
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

                                    }
                                    btnCadastrar.Enabled = true;
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

        public void CarregarCategorias()
        {
            ddlCategoria.Items.Insert(0, new ListItem("---SELECIONE---", "0"));
            ddlCategoria.Items.Insert(1, new ListItem("Instrumentos", "Instrumentos"));
            ddlCategoria.Items.Insert(2, new ListItem("Calçados", "Calçados"));
            ddlCategoria.Items.Insert(3, new ListItem("Acessório", "Acessórios"));
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    txtNome.Focus();
                    throw new Exception("O nome do produto é obrigatório");
                }
                if (string.IsNullOrEmpty(txtDesc.Text) || string.IsNullOrWhiteSpace(txtDesc.Text))
                {
                    txtDesc.Focus();
                    throw new Exception("Uma descrição do produto é obrigatoria");
                }
                if(ddlCategoria.SelectedIndex == 0)
                {
                    ddlCategoria.Focus();
                    throw new Exception("Escolha uma categoria");
                }
                if(Convert.ToInt32(txtEstoque.Text) < 0)
                {
                    txtEstoque.Focus();
                    throw new Exception("O estoque deve ser sempre positivo");
                }
                if(string.IsNullOrEmpty(txtVal_Unit.Text) || string.IsNullOrWhiteSpace(txtVal_Unit.Text))
                {
                    txtVal_Unit.Focus();
                    throw new Exception("O Valor do produto é obrigatório");
                }
                else
                {
                    try
                    {
                        decimal preco = Convert.ToDecimal(txtVal_Unit.Text);
                        try
                        {
                            Produto p = new Produto()
                            {
                                Nome = txtNome.Text,
                                Descricao = txtDesc.Text,
                                Val_unit = preco,
                                Categoria = ddlCategoria.SelectedValue,
                                Estoque = Convert.ToInt32(txtEstoque.Text),
                                Foto = (string)Session["path"]
                            };

                            if (pService.CadProd(p))
                            {
                                lblMensagem.Text = "Produto cadastrado com Sucesso!";
                            }
                            else
                            {
                                lblMensagem.Text = "O produto não foi possível cadastrar o produto";
                            }
                            Session["path"] = "";
                        }
                        catch (Exception ex)
                        {
                            lblMensagem.Text = ex.Message;
                        }
                    }
                    catch (Exception ex)
                    {
                        txtVal_Unit.Focus();
                        lblMensagem.Text = ex.Message;
                        lblMensagem.Text = "O preço é obrigatoriamente númerico";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }
    }
}