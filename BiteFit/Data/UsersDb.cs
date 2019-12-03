using BiteFit.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BiteFit.Data
{
    public class UsersDb
    {
        public int ExisteUsuario(User user)
        {
            var usersList = GetUsers();
            foreach(var userOfList in usersList)
            {
                if(user.username == userOfList.username && user.password == userOfList.password)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
            
        }
        public List<User> GetUsers()
        {
            SqlHelper sqlHelper = new SqlHelper();
            var usersList = new List<User>();
            using (SqlConnection connection = new SqlConnection(sqlHelper.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("Select * From Usuario;", connection);
                connection.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usersList.Add(new User
                        {
                            username = Convert.ToString(dr["username"]),
                            password = Convert.ToString(dr["passwordUsuario"])
                        });
                    }
                }
            }
            return usersList;
        }
    }
}
