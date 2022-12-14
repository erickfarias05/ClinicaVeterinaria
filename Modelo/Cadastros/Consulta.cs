using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Cadastros
{
    public class Consulta
    {
        public long ConsultaId { get; set; }

        public DateTime Data_hora { get; set; }

        public string Sintomas { get; set; }

        public long? ExameId { get; set; }
        public Exame Exame { get; set; }
        public long? VeterinarioId { get; set; }
        public Veterinario veterinario { get; set; }
        public long? PetId { get; set; }
        public Pet pet { get; set; }
    }
}
