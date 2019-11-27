using BiteFit.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BiteFit.Data
{
    public class EstadoDb
    {
        public List<Estado> GetEstados()
        {
            SqlHelper sqlHelper = new SqlHelper();
            var estadoList = new List<Estado>();
            using (SqlConnection connection = new SqlConnection(sqlHelper.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Estado;", connection);
                connection.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        estadoList.Add(new Estado
                        {
                            id = Convert.ToInt16(dr["id"]),
                            nombre = Convert.ToString(dr["nombre"]),
                            idPais = Convert.ToInt16(dr["idPais"])
                        });
                    }
                }
            }
            return estadoList;
        }
    }
}
