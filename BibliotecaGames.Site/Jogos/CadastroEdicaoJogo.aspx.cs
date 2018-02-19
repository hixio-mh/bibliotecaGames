using BibliotecaGames.Entities;
using BIbliotecaGames.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaGames.Site.Jogos
{ 
    public partial class CadastroEdicaoJogo : System.Web.UI.Page
    {
        private GeneroBo _generoBo;
        private EditorBo _editorBo;
        private JogosBo _jogosBo;

        protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    CarregarEditoresNoComboList();
                    CarregarGenerosNoComboList();

                    if (EstaEmModoEdicao())
                    {
                        CarregarDadosParaEdicao();
                    }
                }
            }

        protected void BtnGravar_click(Object sender, EventArgs e)
        {
            _jogosBo = new JogosBo();

            var jogo = ObeterModeloPreechido();

            
            try
            {
                jogo.Imagem = GravarUploadDisco();
            }
            catch
            {
                LblMensagem.Text = "Ocorreu um erro ao salvar a mensagem!";
            }

           
            try
            {
                var mensagemDeSucesso = "";

                if (EstaEmModoEdicao())
                {
                    jogo.Id = ObterIdDoJogo();
                    _jogosBo.AlterarJogo(jogo);
                    mensagemDeSucesso = "Jogo alterado com sucesso!";
                }
                else
                {
                    _jogosBo.InserirNovoJogo(jogo);
                    mensagemDeSucesso = "Jogo cadastrado com sucesso!";
                }

                LblMensagem.ForeColor = System.Drawing.Color.Blue;
                LblMensagem.Text = mensagemDeSucesso;

                btnGravar.Enabled = false;
            }
            catch
            {
                LblMensagem.ForeColor = System.Drawing.Color.Red;
                LblMensagem.Text = "Ocorreu um erro ao cadastrar o jogo!";
            }
        }

        private Jogo ObeterModeloPreechido()
        {
            var jogo = new Jogo();
            jogo.Titulo = TxtTitulo.Text;
            jogo.ValorPago = string.IsNullOrWhiteSpace(ValorPago.Text) ? (double?)null : Convert.ToDouble(ValorPago.Text);
            jogo.DataCompra = string.IsNullOrWhiteSpace(DataCompra.Text) ? (DateTime?)null : Convert.ToDateTime(DataCompra.Text);
            jogo.IdEditor = Convert.ToInt32(DdlEditor.SelectedValue);
            jogo.IdGenero = Convert.ToInt32(DdlGenero.SelectedValue);
           

            return jogo;
        }

        private string GravarUploadDisco()
        {
            if (FileUploadImage.HasFile)
            {
                try
                {
                    var caminho = $"{AppDomain.CurrentDomain.BaseDirectory}Content\\imagensJogo\\";
                    var fileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}_{FileUploadImage.FileName}";
                    FileUploadImage.SaveAs( $"{caminho}{fileName}");
                    return fileName;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return null;
            }
        }

        private void CarregarEditoresNoComboList()
        {
        _editorBo = new EditorBo();
        var editores = _editorBo.ObterTodosOsEditores();

        DdlEditor.DataSource = editores;
        DdlEditor.DataBind();
        }

        private void CarregarGenerosNoComboList()
        {
        _generoBo = new GeneroBo();
        var generos = _generoBo.ObterTodosOsGeneros();

        DdlGenero.DataSource = generos;
        DdlGenero.DataBind();
        }

        public void CarregarDadosParaEdicao()
        {
            _jogosBo = new JogosBo();

            var id = ObterIdDoJogo();

            var jogo = _jogosBo.ObterJogoPeloId(id);

            TxtTitulo.Text = jogo.Titulo;
            ValorPago.Text = jogo.ValorPago.ToString();
            DataCompra.Text = jogo.DataCompra.HasValue ? jogo.DataCompra.Value.ToString("yyyy-MM-dd") : string.Empty;
            DdlEditor.SelectedValue = jogo.IdEditor.ToString();
            DdlGenero.SelectedValue = jogo.IdGenero.ToString();
        }

        public int ObterIdDoJogo()
        {
            var id = 0;
            var idQueryString = Request.QueryString["id"];
            if (int.TryParse(idQueryString, out id))
            {
                if (id <= 0)
                {

                    throw new Exception("ID inválido");
                }
                return id;
            }
            else
            {
                throw new Exception("ID inválido");
            }

        }

        public bool EstaEmModoEdicao()
        {
            return Request.QueryString.AllKeys.Contains("id");
        }

        private Jogo ExcluirJogo()
        {
            var jogo = new Jogo();
            jogo.Id = ObterIdDoJogo();
            return jogo;
        }

        protected void BtnExcluir_click(object sender, EventArgs e)
        {
            _jogosBo = new JogosBo();


            var jogo = ExcluirJogo();


            try
            {
                _jogosBo.ExcluirJogo(jogo);

                LblMensagem.ForeColor = System.Drawing.Color.Blue;
                LblMensagem.Text = "Jogo excluído com Sucesso!";                
            }
            catch
            {
                LblMensagem.ForeColor = System.Drawing.Color.Red;
                LblMensagem.Text = "Ocorreu um erro ao excluir o jogo!";
            }

        }

        protected void BtnCatalogo_click(object sender, EventArgs e)
        {
           
        }

    }
}