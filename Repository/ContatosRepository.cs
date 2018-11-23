using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Repository
{
    public class ContatosRepository
    {
        private NpgsqlConnection cn = null; 
        public IList<ContatosDomain> RetornaListaContatosRepository(int user_from_id)
        {
            var lista = new List<ContatosDomain>();
            try
            {
                cn = new NpgsqlConnection(StringConnection.ConnectionApp);
                var query = new StringBuilder();
                query.Append("SELECT DISTINCT ");
            }
            catch(NpgsqlException ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }
    }
}
