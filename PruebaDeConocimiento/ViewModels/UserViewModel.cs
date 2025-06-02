using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PruebaDeConocimiento.BD;
using PruebaDeConocimiento.Commands;
using PruebaDeConocimiento.Models;

namespace PruebaDeConocimiento.ViewModels
{
    internal class UserViewModel : ViewModelBase 
    {
        private readonly Bd bd;
        private ObservableCollection<UserModel> _users;
        private UserModel _user;
        private UserModel _selectedUser;

        public UserViewModel()
        {
            bd = new Bd();
            _user = new UserModel(); // Se inicializa vacio
            _users = bd.Get(); new ObservableCollection<UserModel>();
        }


        public UserModel User
        {
            get => _user;
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChange(nameof(User));
                }
            }
        }

        public ObservableCollection<UserModel> Users
        {
            get => _users;
            set
            {
                if (_users != value)
                {
                    _users = value;
                    OnPropertyChange(nameof(Users));
                }
            }
        }

        public UserModel SelectedUser
        {
            get => _selectedUser;
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    OnPropertyChange(nameof(SelectedUser));
                    if (_selectedUser != null)
                    {
                        User = new UserModel
                        {
                            Id = _selectedUser.Id,
                            Nombre = _selectedUser.Nombre,
                            Apellido = _selectedUser.Apellido,
                            Email = _selectedUser.Email,
                            Telefono = _selectedUser.Telefono,
                            Password = _selectedUser.Password
                        };
                    }
                }
            }
        }

        public ICommand AddCommand => new RelayCommand(AddExecute, AddCanExecute);
        public ICommand EditCommand => new RelayCommand(EditExecute, EditCanExecute);
        public ICommand DeleteCommand => new RelayCommand(DeleteExecute, DeleteCanExecute);

        private void AddExecute(object parameter)
        {
            // Verificar si ya existe un usuario con el mismo email
            bool usuarioExiste = Users.Any(u => u.Email == User.Email);

            if (usuarioExiste)
            {
                MessageBox.Show("El usuario que estás ingresando, ya se encuentra registrado.",
                                "Usuario Duplicado",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }

            bd.Add(User);
            Users = bd.Get();

            // Mostrar mensaje de éxito
            MessageBox.Show("Usuario registrado con éxito.",
                            "Registro Exitoso",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);

            // Limpiar el formulario después de agregar
            User = new UserModel();
        }

        private bool AddCanExecute(object parameter) => true;

        private void EditExecute(object parameter)
        {
            if (SelectedUser != null && User != null)
            {
                SelectedUser.Nombre = User.Nombre;
                SelectedUser.Apellido = User.Apellido;
                SelectedUser.Email = User.Email;
                SelectedUser.Telefono = User.Telefono;
                SelectedUser.Password = User.Password;

                bd.Update(SelectedUser);
                Users = bd.Get();
            }
            
        }

        private bool EditCanExecute(object parameter) => SelectedUser != null;

        private void DeleteExecute(object parameter)
        {
            if (SelectedUser != null)
            {
                bd.Delete(SelectedUser);
                Users = bd.Get();
            }
            
        }

        private bool DeleteCanExecute(object parameter) => SelectedUser != null;
    }
}
