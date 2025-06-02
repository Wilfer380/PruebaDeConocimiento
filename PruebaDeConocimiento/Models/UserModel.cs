using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDeConocimiento.Models
{
     public class UserModel
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _email;
        private string _telefono;
        private string _password;

        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                }
            }
        }

        public string Nombre
        { 
            get => _nombre;
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                }
            }
        }
        public string Apellido 

        {   get => _apellido;
            set
            {
                if (_apellido != value)
                {
                    _apellido = value;
                }
            }
        }
        public string Email
        { 
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                }
            }
        }
        public string Telefono
        {
            get => _telefono;
            set
            {
                if (_telefono != value)
                {
                    _telefono = value;
                }
            }
        }
        public string Password
        { 
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                }
            }
        }
     }
 }

