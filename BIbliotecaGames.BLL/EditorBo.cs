using BibliotecaGames.DAL;
using BibliotecaGames.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIbliotecaGames.BLL
{
    public class EditorBo
    {
        private EditorDao _editorDao;

        public List<Editor> ObterTodosOsEditores()
        {
            _editorDao = new EditorDao();
            return _editorDao.ObterTodosOsEditores();
        }
    }
}
