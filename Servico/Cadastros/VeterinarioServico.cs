using Modelo.Cadastros;
using Persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Cadastros
{
    public class VeterinarioServico
    {
        private VeterinarioDAL VeterinarioDAL = new VeterinarioDAL();
        public IQueryable<Veterinario> ObterVeterinariosClassificadosPorCMV()
        {
            return VeterinarioDAL.ObterVeterinariosClassificadosPorCMV();
        }

        public Veterinario ObterVeterinarioPorId(long id)
        {
            return VeterinarioDAL.ObterVeterinarioPorId(id);
        }
        public void GravarVeterinario(Veterinario veterinario)
        {
            VeterinarioDAL.GravarVeterinario(veterinario);
        }

        public Veterinario EliminarVeterinarioPorId(long id)
        {
            Veterinario veterinario = VeterinarioDAL.ObterVeterinarioPorId(id);
            VeterinarioDAL.EliminarVeterinarioPorId(id);
            return veterinario;
        }
    }
}
