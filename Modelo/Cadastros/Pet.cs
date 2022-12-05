using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Cadastros
{
    public class Pet
    {
        public long PetId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }

        public Cliente cliente { get; set; }
        public int ClienteId { get; set; }
    }
}
