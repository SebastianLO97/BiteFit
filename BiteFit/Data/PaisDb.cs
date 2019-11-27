using BiteFit.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BiteFit.Data
{
    public class PaisDb
    {
        public List<Pais> GetPaises()
        {
            SqlHelper sqlHelper = new SqlHelper();
            var paisesList = new List<Pais>();
            using (SqlConnection connection = new SqlConnection(sqlHelper.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Pais;", connection);
                connection.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        paisesList.Add(new Pais
                        {
                            id = Convert.ToInt16(dr["id"]),
                            nombre = Convert.ToString(dr["nombre"])
                        });
                    }
                }
            }
            return paisesList;
        }
    }
}
