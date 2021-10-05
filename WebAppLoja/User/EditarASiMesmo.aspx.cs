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
    public partial class EditarASiMesmo : System.Web.UI.Page
    {
        ClienteBLL cService = new ClienteBLL();
        FuncionarioBLL fService = new FuncionarioBLL();
        
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Session["login"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    if (Session["TipoUser"].ToString() == "C")
                    {
                        Cliente c = (Cliente)Session["login"];
                        PreencherFormClie(c);
                    }
                    else
                    {
                        Funcionario f = (Funcionario)Session["login"];
                        PreencherFormFun(f);
                    }
                }                
            }                        
        }

        public void PreencherFormClie(Cliente c)
        {
            txtNome.Text = c.Nome;
            txtEndereco.Text = c.Endereco;
            txtCidade.Text = c.Cidade;
            txtCPF.Text = c.Cpf;
            txtCEP.Text = c.Cep;
            txtUF.Text = c.Uf;
            txtEmail.Text = c.Email;
            hfTipo.Value = "C";
        }

        public void PreencherFormFun(Funcionario f)
        {
            txtNome.Text = f.Nome;
            txtEndereco.Text = f.Endereco;
            txtCidade.Text = f.Cidade;
            txtCPF.Text = f.Cpf;
            txtCEP.Text = f.Cep;
            txtUF.Text = f.Uf;
            txtEmail.Text = f.Email;
            hfTipo.Value = "F";
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    throw new Exception("");
                }
                if (string.IsNullOrEmpty(txtEndereco.Text) || string.IsNullOrWhiteSpace(txtEndereco.Text))
                {
                    throw new Exception("");
                }
                if (string.IsNullOrEmpty(txtCidade.Text) || string.IsNullOrWhiteSpace(txtCidade.Text))
                {
                    throw new Exception("");
                }
                if (string.IsNullOrEmpty(txtUF.Text) || string.IsNullOrWhiteSpace(txtUF.Text))
                {
                    throw new Exception("");
                }
                if (string.IsNullOrEmpty(txtSenha.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    throw new Exception("");
                }
                if(hfTipo.Value == "C")
                {
                    Cliente c = (Cliente)Session["login"];
                    c.Nome = txtNome.Text;
                    c.Endereco = txtEndereco.Text;
                    c.Cidade = txtCidade.Text;
                    c.Cpf = txtCPF.Text;
                    c.Cep = txtCEP.Text;
                    c.Uf = txtUF.Text;
                    c.Email = txtEmail.Text;
                    c.Senha = txtSenha.Text;

                    lblMensagem.Visible = true;

                    if (cService.Atualizar(c))
                    {
                        lblMensagem.Text = "Informações alteradas com sucesso!";
                    }
                    else
                    {
                        lblMensagem.Text = "Falha ao alterar as informações";
                    }
                }
                else
                {
                    Funcionario f = (Funcionario)Session["login"];
                    f.Nome = txtNome.Text;
                    f.Endereco = txtEndereco.Text;
                    f.Cidade = txtCidade.Text;
                    f.Cpf = txtCPF.Text;
                    f.Cep = txtCEP.Text;
                    f.Uf = txtUF.Text;
                    f.Email = txtEmail.Text;
                    f.Senha = txtSenha.Text;
                    
                    lblMensagem.Visible = true;

                    if (fService.Atualizar(f))
                    {
                        lblMensagem.Text = "Informações alteradas com sucesso!";
                    }
                    else
                    {
                        lblMensagem.Text = "Falha ao alterar as informações";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Visible = true;
                lblMensagem.Text = ex.Message;
            }
        }
    }
}