using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PruebaDeConocimiento.Models;
using System.Data.SqlClient;
using System.Collections;

namespace PruebaDeConocimiento.BD
{
    internal class Bd
    {
        private readonly string _conexion;

        public string Conexion => _conexion;

        public Bd()
        {
            _conexion = @"server=DESKTOP-HRPVN4K\SQLEXPRESS; Database=BDUSERS; Trusted_Connection=true;";
        }

        internal ObservableCollection<UserModel> Get()
        {
            ObservableCollection<UserModel> lstResult = new ObservableCollection<UserModel>();
            string query = "SELECT * FROM usuarios";
            using (SqlConnection cn = new SqlConnection(Conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lstResult.Add(new UserModel()
                    {
                        Id = (int)reader["IDUSER"],
                        Nombre = (string)reader["NOMBRE"],
                        Apellido = (string)reader["APELLIDO"],
                        Email = (string)reader["EMAIL"],
                        Telefono = (string)reader["TELEFONO"],
                        Password = (string)reader["CONTRASEÑA"],
                    });
                }
                reader.Close();
                cn.Close();
            }
            return lstResult;
          
        }

        internal void Add(UserModel user)
        {
            string query = "INSERT INTO usuarios VALUES( @name, @lastname, @email, @telefono, @password);";
            using (SqlConnection cn = new SqlConnection(Conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@name", user.Nombre);
                cmd.Parameters.AddWithValue("@lastname", user.Apellido);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@telefono", user.Telefono);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        internal void Delete(UserModel user)
        {
            string query = "DELETE FROM usuarios WHERE IDUSER = @id";
            using (SqlConnection cn = new SqlConnection(Conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        internal void edit (UserModel user)
        {
            string query = " UPDATE usuarios SET Nombre=@name, Apellido=@lastname, EMAIL=@email, TELEFONO=@telefono, CONTRASEÑA=@password WHERE IDUSER=@id";
            using (SqlConnection cn = new SqlConnection(Conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.Parameters.AddWithValue("@name", user.Nombre);
                cmd.Parameters.AddWithValue("@lastname", user.Apellido);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@telefono", user.Telefono);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.ExecuteNonQuery();
                cn.Close();
            }

        }

        internal void Update(UserModel selectedUser)
        {
            string query = "UPDATE usuarios SET Nombre=@name, Apellido=@lastname, EMAIL=@email, TELEFONO=@telefono, CONTRASEÑA=@password WHERE IDUSER=@id";
            using (SqlConnection cn = new SqlConnection(Conexion))
        {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", selectedUser.Id);
                cmd.Parameters.AddWithValue("@name", selectedUser.Nombre);
                cmd.Parameters.AddWithValue("@lastname", selectedUser.Apellido);
                cmd.Parameters.AddWithValue("@email", selectedUser.Email);
                cmd.Parameters.AddWithValue("@telefono", selectedUser.Telefono);
                cmd.Parameters.AddWithValue("@password", selectedUser.Password);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    } 
        
}
