using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Domain.Entities
{
    public class Usuario : EntidadeBase
    {

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

    }
}
