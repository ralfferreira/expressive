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
    public partial class cadFuncionario : System.Web.UI.Page
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
            //if (!Page.IsPostBack)
            //{
            //    Funcionario f = (Funcionario)Session["login"];

            //    if (f.Cargo != "Admin")
            //    {
            //        Response.Redirect("../User/AreaUsuario.aspx");
            //    }
            //    CarregarCargos();
            //    CarregarComissoes();
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

        protected void btnCadastrarFunc_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    throw new Exception("O Nome é obrigatorio");
                }
                if (string.IsNullOrEmpty(txtEndereco.Text) || string.IsNullOrWhiteSpace(txtEndereco.Text))
                {
                    throw new Exception("O Endereço é obrigatorio");
                }
                if (string.IsNullOrEmpty(txtCidade.Text) || string.IsNullOrWhiteSpace(txtCidade.Text))
                {
                    throw new Exception("A Cidade é obrigatoria");
                }
                if (string.IsNullOrEmpty(txtCEP.Text) || string.IsNullOrWhiteSpace(txtCEP.Text))
                {
                    throw new Exception("O CEP é obrigatorio");
                }
                if (string.IsNullOrEmpty(txtUF.Text) || string.IsNullOrWhiteSpace(txtUF.Text))
                {
                    throw new Exception("A UF é obrigatoria");
                }
                if (string.IsNullOrEmpty(txtCPF.Text) || string.IsNullOrWhiteSpace(txtCPF.Text))
                {
                    throw new Exception("O CPF é obrigatorio");
                }
                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    throw new Exception("O Email é obrigatorio");
                }
                if (string.IsNullOrEmpty(txtSenha.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    throw new Exception("A Senha é obrigatoria");
                }
                if (ddlCargo.SelectedIndex == 0)
                {
                    throw new Exception("O Cargo é obrigatório");
                }
                if (string.IsNullOrEmpty(txtSalario.Text) || string.IsNullOrWhiteSpace(txtSalario.Text))
                {
                    throw new Exception("O Salário é obrigatorio");
                }
                else
                {
                    try
                    {
                        decimal sal = Convert.ToDecimal(txtSalario.Text);
                        if(sal < 0)
                        {
                            throw new Exception("O Salário não pode ser negativo");
                        }

                        Usuario u = new Usuario()
                        {
                            Email = txtEmail.Text,
                            Cpf = txtCPF.Text
                        }; 

                        UsuarioBLL uService = new UsuarioBLL();

                        if (uService.Registrar(u))
                        {
                            throw new Exception("Funcionario já cadastrado");
                        }
                        else
                        {
                            Funcionario f = new Funcionario()
                            {
                                Nome = txtNome.Text,
                                Endereco = txtEndereco.Text,
                                Cidade = txtCidade.Text,
                                Cep = txtCEP.Text,
                                Uf = txtUF.Text,
                                Cpf = txtCPF.Text,
                                Email = txtEmail.Text,
                                Senha = txtSenha.Text,
                                Cargo = ddlCargo.SelectedValue,
                                Salario_fixo = sal,
                                Comissao = ddlComissao.SelectedValue,
                                Dt_contrato = DateTime.Now.Date
                            };

                            FuncionarioBLL fService = new FuncionarioBLL();

                            if (fService.CadFun(f))
                            {
                                lblMensagem.Text = "Funcionario registrado com Sucesso!";
                            }
                            else
                            {
                                lblMensagem.Text = "Não foi possível registrar o funcionário";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMensagem.Text = ex.Message;
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