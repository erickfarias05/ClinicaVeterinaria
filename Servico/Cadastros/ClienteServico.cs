using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Cadastros
{
    public class ClienteServico
    {
        private ClienteDAL ClienteDAL = new ClienteDAL();
        public IQueryable<Cliente> ObterClientesClassificadosPorCPF()
        {
            return ClienteDAL.ObterClientesClassificadosPorCPF();
        }

        public Cliente ObterClientePorId(long id)
        {
            return ClienteDAL.ObterClientePorId(id);
        }
        public void GravarCliente(Cliente cliente)
        {
            ClienteDAL.GravarCliente(cliente);
        }

        public Cliente EliminarClientePorId(long id)
        {
            Cliente cliente = ClienteDAL.ObterClientePorId(id);
            ClienteDAL.EliminarClientePorId(id);
            return cliente;
        }
    }
}
