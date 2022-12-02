﻿using Modelo.Cadastros;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Cadastros
{
    public class ClienteDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Cliente> ObterClientesClassificadosPorCPF()
        {
            return context.Clientes.OrderBy(b => b.cpf);
        }

        public Cliente ObterClientePorId(long id)
        {
            return context.Clientes.Where(p => p.ClienteId == id).Include(c => c.PetId).First();
        }

        public void GravarCliente(Cliente cliente)
        {
            if (cliente.ClienteId == 0)
            {
                context.Clientes.Add(cliente);
            }
            else
            {
                context.Entry(cliente).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Cliente EliminarClientePorId(long id)
        {
            Cliente cliente = ObterClientePorId(id);
            context.Clientes.Remove(cliente);
            context.SaveChanges();
            return cliente;
        }
    }
}
