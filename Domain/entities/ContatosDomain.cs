using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class ContatosDomain
    {
        public int user_from_id { get; set; }
        public int user_to_id { get; set; }

        public List<MensagemDomain> mensagens { get; set; }
    }
}
