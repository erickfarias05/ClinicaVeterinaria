using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Cadastros
{
    public class UsuarioServico
    {
        private UsuarioDAL usuarioDAL = new UsuarioDAL();
        public IQueryable<Usuario> ObterUsuariosClassificadosPorNome()
        {
            return usuarioDAL.ObterUsuariosClassificadosPorNome();
        }

        public Usuario ObterUsuarioPorId(long id)
        {
            return usuarioDAL.ObterUsuarioPorId(id);
        }
        public void GravarUsuario(Usuario usuario)
        {
            usuarioDAL.GravarUsuario(usuario);
        }

        public Usuario EliminarUsuarioPorId(long id)
        {
            Usuario usuario = usuarioDAL.ObterUsuarioPorId(id);
            usuarioDAL.EliminarUsuarioPorId(id);
            return usuario;
        }

    }
}
