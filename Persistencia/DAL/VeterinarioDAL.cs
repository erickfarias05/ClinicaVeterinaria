using Modelo.Cadastros;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL
{
    public class VeterinarioDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Veterinario> ObterVeterinariosClassificadosPorCMV()
        {
            return context.Veterinarios.OrderBy(n => n.crmv);
        }

        public Veterinario ObterVeterinarioPorId(long id)
        {
            return context.Veterinarios.Where(p => p.VeterinarioId == id).First();
        }

        public void GravarVeterinario(Veterinario veterinario)
        {
            if (veterinario.VeterinarioId == 0)
            {
                context.Veterinarios.Add(veterinario);
            }
            else
            {
                context.Entry(veterinario).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Veterinario EliminarVeterinarioPorId(long id)
        {
            Veterinario veterinario = ObterVeterinarioPorId(id);
            context.Veterinarios.Remove(veterinario);
            context.SaveChanges();
            return veterinario;
        }

    }
}

