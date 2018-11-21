using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Repository
{
    public class LoginRepository
    {
        private NpgsqlConnection cn;
        
        public UsuarioDomain ValidaUsuarioRepository(UsuarioDomain usuario)
        {
            var usuarioLogado = new UsuarioDomain();
            try
            {
                cn = new NpgsqlConnection(StringConnection.ConnectionApp);
                var query = new StringBuilder("");
                query.Append("SELECT id, name, username, email, password_digest, photo, description, client_id, supervisor_id, phone_number, created_at, updated_at, reset_token, active, confirm_token, plan ");
                query.Append("FROM users WHERE email = @email AND password_digest = @password;");
                var cmd = new NpgsqlCommand(query.ToString(), cn) { CommandType = System.Data.CommandType.Text };
                cmd.Parameters.Add(new NpgsqlParameter("@email", usuario.Email));
                cmd.Parameters.Add(new NpgsqlParameter("@password", usuario.Password_digest));
                cn.Open();
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                        usuarioLogado.Id = Convert.ToInt32(dr[0]);
                    if (!dr.IsDBNull(1))
                        usuarioLogado.Name = Convert.ToString(dr[1]);
                    if (!dr.IsDBNull(2))
                        usuarioLogado.Username = Convert.ToString(dr[2]);
                    if (!dr.IsDBNull(3))
                        usuarioLogado.Email = Convert.ToString(dr[3]);
                    if (!dr.IsDBNull(4))
                        usuarioLogado.Password_digest = Convert.ToString(dr[4]);
                    if (!dr.IsDBNull(5))
                        usuarioLogado.Photo = Convert.ToString(dr[5]);
                    if (!dr.IsDBNull(6))
                        usuarioLogado.Description = Convert.ToString(dr[6]);
                    if (!dr.IsDBNull(7))
                        usuarioLogado.Client_id = Convert.ToInt32(dr[7]);
                    if (!dr.IsDBNull(8))
                        usuarioLogado.Supervisor_id = Convert.ToInt32(dr[8]);
                    if (!dr.IsDBNull(9))
                        usuarioLogado.Phone_number = Convert.ToString(dr[9]);
                    if (!dr.IsDBNull(10))
                        usuarioLogado.Created_at = Convert.ToDateTime(dr[10]);
                    if (!dr.IsDBNull(11))
                        usuarioLogado.Updated_at = Convert.ToDateTime(dr[11]);
                    if (!dr.IsDBNull(12))
                        usuarioLogado.Reset_token = Convert.ToString(dr[12]);
                    if (!dr.IsDBNull(13))
                        usuarioLogado.Active = Convert.ToBoolean(dr[13]);
                    if (!dr.IsDBNull(14))
                        usuarioLogado.Confirm_token = Convert.ToString(dr[14]);
                    if (!dr.IsDBNull(15))
                        usuarioLogado.Plan = Convert.ToString(dr[15]);
                }
                
            }
            catch (NpgsqlException ex) {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return usuarioLogado;
        }

        public bool AddUsuario(UsuarioDomain usuario)
        {
            var status = false;
            try
            {
                cn = new NpgsqlConnection(StringConnection.ConnectionApp);
                var query = new StringBuilder();
                query.Append("UPDATE users SET name=@name, username=@username, email=@email, password_digest=@password, photo=@photo, description=@description, client_id=@client_id, supervisor_id=@supervisor_id, phone_number=@phone_number, created_at=@created_at, updated_at=@updated_at, reset_token=@reset_token, active=@active, confirm_token=@confirm_token, plan=@plan ");
                query.Append("WHERE  id=@id;");
                var cmd = new NpgsqlCommand() { CommandType = System.Data.CommandType.Text };
                cmd.Parameters.AddWithValue("@id", usuario.Id);
                cmd.Parameters.AddWithValue("@name", usuario.Name);
                cmd.Parameters.AddWithValue("@username", usuario.Username);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@password", usuario.Password_digest);
                cmd.Parameters.AddWithValue("@photo", usuario.Photo);
                cmd.Parameters.AddWithValue("@description", usuario.Description);
                cmd.Parameters.AddWithValue("@client_id", usuario.Client_id);
                cmd.Parameters.AddWithValue("@supervisor_id", usuario.Supervisor_id);
                cmd.Parameters.AddWithValue("@phone_number", usuario.Phone_number);
                cmd.Parameters.AddWithValue("@created_at", usuario.Created_at);
                cmd.Parameters.AddWithValue("@updated_at", usuario.Updated_at);
                cmd.Parameters.AddWithValue("@reset_token", usuario.Reset_token);
                cmd.Parameters.AddWithValue("@active", usuario.Active);
                cmd.Parameters.AddWithValue("@confirm_token", usuario.Confirm_token);
                cmd.Parameters.AddWithValue("@plan", usuario.Plan);
                cn.Open();
                int codigo = cmd.ExecuteNonQuery();
                if(codigo == -1){
                    status = false;
                }
                else 
                {
                    status = true;
                }
            }
            catch(NpgsqlException ex)
            {
                throw ex;
            }
            return status;
        }

        public bool UpdUsuario(UsuarioDomain usuario)
        {
            var status = false;
            try
            {
                cn = new NpgsqlConnection(StringConnection.ConnectionApp);
                var query = new StringBuilder();
                query.Append("UPDATE users set ( id, name, username, email, password_digest, photo, description, client_id, supervisor_id, phone_number, created_at, updated_at, reset_token, active, confirm_token, plan) ");
                query.Append("values (@id, @name, @username, @email, @password, @photo, @description, @client_id, @supervisor_id, @phone_number, @created_at, @updated_at, @reset_token, @active, @confirm_token, @plan);");
                var cmd = new NpgsqlCommand() { CommandType = System.Data.CommandType.Text };
                cmd.Parameters.AddWithValue("@id", usuario.Id);
                cmd.Parameters.AddWithValue("@name", usuario.Name);
                cmd.Parameters.AddWithValue("@username", usuario.Username);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@password", usuario.Password_digest);
                cmd.Parameters.AddWithValue("@photo", usuario.Photo);
                cmd.Parameters.AddWithValue("@description", usuario.Description);
                cmd.Parameters.AddWithValue("@client_id", usuario.Client_id);
                cmd.Parameters.AddWithValue("@supervisor_id", usuario.Supervisor_id);
                cmd.Parameters.AddWithValue("@phone_number", usuario.Phone_number);
                cmd.Parameters.AddWithValue("@created_at", usuario.Created_at);
                cmd.Parameters.AddWithValue("@updated_at", usuario.Updated_at);
                cmd.Parameters.AddWithValue("@reset_token", usuario.Reset_token);
                cmd.Parameters.AddWithValue("@active", usuario.Active);
                cmd.Parameters.AddWithValue("@confirm_token", usuario.Confirm_token);
                cmd.Parameters.AddWithValue("@plan", usuario.Plan);
                cn.Open();
                int codigo = cmd.ExecuteNonQuery();
                if (codigo == -1)
                {
                    status = false;
                }
                else
                {
                    status = true;
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            return status;
        }

    }
}
