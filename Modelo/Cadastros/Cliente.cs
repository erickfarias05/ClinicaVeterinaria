using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Cadastros
{
    public class Cliente
    {

        public long ClienteId { get; set; }

        public string cpf { get; set; }
        public Usuario usuario { get; set; }
        public long? UsuarioId { get; set; }

        //public Pet pet { get; set; }
        //public int PetId { get; set; }

    }
}
