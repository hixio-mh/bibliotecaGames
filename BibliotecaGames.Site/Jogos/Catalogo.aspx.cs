using BibliotecaGames.Entities;
using BIbliotecaGames.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaGames.Site.Jogos
{
    public partial class Catalogo : System.Web.UI.Page
    {
        private JogosBo _jogosBo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarJogosNoRepeater();
                Deslogar();
            }
            
        }

        private void CarregarJogosNoRepeater()
        {
            _jogosBo = new JogosBo();

            RepeaterJogos.DataSource = _jogosBo.ObterTodosOsJogos();
            RepeaterJogos.DataBind();
        }

        private void Deslogar()
        {
            if (!string.IsNullOrEmpty(Page.Request.QueryString["logout"]))
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                //FormsAuthentication.RedirectToLoginPage();
                Response.Redirect("../Autenticacao/Login.aspx");
            }
        }

        protected void BtnNovoJogo_click(object sender, EventArgs e)
        {

        }
    }
}