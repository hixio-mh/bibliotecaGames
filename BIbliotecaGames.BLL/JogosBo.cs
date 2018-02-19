using BibliotecaGames.DAL;
using BibliotecaGames.Entities;
using BIbliotecaGames.BLL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIbliotecaGames.BLL
{
    public class JogosBo
    {
        private JogoDao _jogoDao;

        public List<Jogo> ObterTodosOsJogos()
        {
            _jogoDao = new JogoDao();
            return _jogoDao.ObterTodosOsJogos();
        }

        public Jogo ObterJogoPeloId(int id)
        {
            _jogoDao = new JogoDao();
            var jogo =_jogoDao.ObterJogoPeloId(id);

            if (jogo == null)
            {
                throw new JogoNaoEncontradoException();
            }
            return jogo;
        }

        public void InserirNovoJogo(Jogo jogo)
        {
            _jogoDao = new JogoDao();

            ValidarJogo(jogo);

            var linhasAfetadas = _jogoDao.InserirJogo(jogo);

            if (linhasAfetadas == 0)
            {
                throw new JogoNaoCadastradoException();
            }
        }

        public void AlterarJogo(Jogo jogo)
        {
            _jogoDao = new JogoDao();

            ValidarJogo(jogo);

            var linhasAfetadas = _jogoDao.AlterarJogo(jogo);

            if (linhasAfetadas == 0)
            {
                throw new JogoNaoAlteradoException();
            }
        }

        public void ValidarJogo(Jogo jogo)
        {
            if (string.IsNullOrWhiteSpace(jogo.Titulo) || 
                        jogo.IdEditor == 0 || 
                        jogo.IdGenero == 0  )  
            {
                throw new JogoInvalidoException();
            }
        }

        public void ExcluirJogo(Jogo jogo)
        {
            _jogoDao = new JogoDao();

            var linhasafetadas = _jogoDao.ExcluirJogo(jogo);

            if (linhasafetadas == 0)
            {
                throw new JogoNaoExcluidoException();
            }
        }
    }
}
