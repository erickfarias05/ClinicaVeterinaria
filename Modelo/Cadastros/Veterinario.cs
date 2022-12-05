using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Cadastros
{
    public class Veterinario
    {
        public long VeterinarioId { get; set; } 

        public string crmv { get; set; }
        public Usuario usuario { get; set; }
        public long? UsuarioId { get; set; }
    }
}
