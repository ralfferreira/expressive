using Library.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppLoja
{
    public partial class TestarConexao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTestar_Click(object sender, EventArgs e)
        {
            try
            {
                bool conexaoOK = new ConnectionFactory().TestarConexao();

                if (conexaoOK)
                    Response.Write("Conectado com sucesso!");
                else
                    Response.Write("Falha ao conectar!");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}