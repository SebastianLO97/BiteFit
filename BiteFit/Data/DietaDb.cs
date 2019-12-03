using BiteFit.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BiteFit.Data
{
    public class DietaDb
    {
        public void PostNumeroDieta(int dietaNumero)
        {
            SqlHelper sqlHelper = new SqlHelper();
            using (SqlConnection connection = new SqlConnection(sqlHelper.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarDietaNumeros", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dieta", SqlDbType.Int).Value = dietaNumero;
                cmd.ExecuteNonQuery();
            }
        }
        public List<Dieta> GetDietas()
        {
            SqlHelper sqlHelper = new SqlHelper();
            var dietasList = new List<Dieta>();
            using (SqlConnection connection = new SqlConnection(sqlHelper.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("Select * From Dietas;", connection);
                connection.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dietasList.Add(new Dieta
                        {
                            id = Convert.ToInt32(dr["id"]),
                            dieta = Convert.ToString(dr["dieta"]),
                            calorias = Convert.ToInt32(dr["calorias"])
                        });
                    }
                }
            }
            return dietasList;
        }
        public Dieta GetDieta()
        {
            int topDieta = 0;
            var dieta = new Dieta();
            SqlHelper sqlHelper = new SqlHelper();
            using (SqlConnection connection = new SqlConnection(sqlHelper.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("Select Top 1 dieta From DietaNumero Order By id Desc;", connection);
                connection.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        topDieta = Convert.ToInt16(dr["dieta"]);
                    }
                }
            }
            using (SqlConnection connection = new SqlConnection(sqlHelper.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerDietaById", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDieta", SqlDbType.Int).Value = topDieta;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dieta.id = Convert.ToInt16(dr["id"]);
                        dieta.dieta = Convert.ToString(dr["dieta"]);
                        dieta.calorias = Convert.ToInt32(dr["calorias"]);
                    }
                }
            }
            return dieta;
        }
    }
}
