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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtLoginUser.Text) || string.IsNullOrEmpty(txtLoginUser.Text))
                {
                    throw new Exception("EMAIL");
                }
                if (string.IsNullOrWhiteSpace(txtLoginPass.Text) || string.IsNullOrEmpty(txtLoginPass.Text))
                {
                    throw new Exception("SENHA");
                }

                Usuario u = new Usuario()
                {
                    Email = txtLoginUser.Text,
                    Senha = txtLoginPass.Text
                };

                UsuarioBLL uService = new UsuarioBLL();

                int rsLogin = uService.Login(u);
                if (rsLogin == 1)
                {
                    ClienteBLL cService = new ClienteBLL();
                    Cliente cliente = cService.SelecionarPorCod(u.Cod);

                    Session["TipoUser"] = "C";
                    Session["login"] = cliente;
                    Session["Carrinho"] = new Pedido() { Pr_entrega = 14, Cliente = cliente };

                    Response.Redirect("produtos.aspx");
                }
                else if (rsLogin == 2)
                {
                    FuncionarioBLL fService = new FuncionarioBLL();
                    Funcionario funcionario = fService.SelecionarPorCod(u.Cod);

                    if (funcionario.Cargo == "Admin")
                    {
                        try
                        {
                            Response.Redirect("Admin/admin.aspx");
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        
                    }

                    Session["TipoUser"] = "F";
                    Session["login"] = funcionario;
                    Session["Carrinho"] = new Pedido() { Pr_entrega = 14, Funcionario = funcionario };

                    Response.Redirect("produtos.aspx");
                }
                else
                {
                    throw new Exception("FALHA");
                }
            }
            catch (Exception ex)
            {
                if(ex.Message == "EMAIL")
                {
                    lblMensagem.Text = "O Email é um campo obrigatório";
                    txtLoginUser.Focus();
                }
                else if(ex.Message == "SENHA")
                {
                    lblMensagem.Text = "A senha é um campo obrigatório";
                    txtLoginPass.Focus();
                }
                else if (ex.Message == "FALHA")
                {
                    lblMensagem.Text = "Email ou senha incorretos!";
                    txtLoginUser.Text = "";
                    txtLoginPass.Text = "";
                    txtLoginUser.Focus();
                }
                else
                {
                    lblMensagem.Text = ex.Message;
                }
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    txtNome.Focus();
                    throw new Exception("O Nome é obrigatório");
                }
                if (string.IsNullOrEmpty(txtEndereco.Text) || string.IsNullOrWhiteSpace(txtEndereco.Text))
                {
                    txtEndereco.Focus();
                    throw new Exception("O Endereço é obrigatório");
                }
                if (string.IsNullOrEmpty(txtCidade.Text) || string.IsNullOrWhiteSpace(txtCidade.Text))
                {
                    txtCidade.Focus();
                    throw new Exception("A Cidade é obrigatória");
                }
                if (string.IsNullOrEmpty(txtCEP.Text) || string.IsNullOrWhiteSpace(txtCEP.Text))
                {
                    txtCEP.Focus();
                    throw new Exception("O CEP é obrigatório");
                }
                if (string.IsNullOrEmpty(txtUF.Text) || string.IsNullOrWhiteSpace(txtUF.Text))
                {
                    txtUF.Focus();
                    throw new Exception("A UF é obrigatória");
                }
                if (string.IsNullOrEmpty(txtCPF.Text) || string.IsNullOrWhiteSpace(txtCPF.Text))
                {
                    txtCPF.Focus();
                    throw new Exception("O CPF é obrigatório");
                }
                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    txtEmail.Focus();
                    throw new Exception("O Email é obrigatório");
                }
                if (string.IsNullOrEmpty(txtSenha.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    txtSenha.Focus();
                    throw new Exception("O Endereço é obrigatório");
                }

                Usuario u = new Usuario()
                {
                    Nome = txtNome.Text,
                    Endereco = txtEndereco.Text,
                    Cidade = txtCidade.Text,
                    Cep = txtCEP.Text,
                    Uf = txtUF.Text,
                    Cpf = txtCPF.Text,
                    Email = txtEmail.Text,
                    Senha = txtSenha.Text
                };

                UsuarioBLL uService = new UsuarioBLL();

                if (uService.Registrar(u))
                {
                    throw new Exception("Usuário já registrado!");
                }
                else
                {
                    ClienteBLL cService = new ClienteBLL();
                    Cliente c = new Cliente()
                    {
                        Nome = u.Nome,
                        Endereco = u.Endereco,
                        Cidade = u.Cidade,
                        Cep = u.Cep,
                        Uf = u.Uf,
                        Cpf = u.Cpf,
                        Email = u.Email,
                        Senha = u.Senha
                    };

                    if (cService.CadClie(c))
                    {
                        Session["TipoUser"] = "C";
                        Session["login"] = c;
                        Session["Carrinho"] = new Pedido() { Pr_entrega = 14, Cliente = c };

                        Response.Redirect("produtos.aspx");
                    }
                    else
                    {
                        throw new Exception("Erro ao Cadastrar usuário!");
                    }
                }
            }
            catch (Exception ex)
            {
                lblRegistro.Text = ex.Message;
            }
        }
    }
}