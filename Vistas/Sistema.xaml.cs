using ProyectoFinal23AM.Entities;
using ProyectoFinal23AM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoFinal23AM.Vistas
{
    /// <summary>
    /// Lógica de interacción para Sistema.xaml
    /// </summary>
    public partial class Sistema : Window
    {
        public Sistema()
        {
            InitializeComponent();
            GetUsersTable();
            GetRoles();
        }
        UsuarioServices services = new UsuarioServices();
        public void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtPkUser.Text == "")
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = txtNombre.Text,
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text,
                    FkRol = int.Parse(SelectRol.SelectedValue.ToString())
                };
                
                services.AddUser(usuario);
                MessageBox.Show("REGISTRO EXITOSO");
                txtNombre.Clear();
                txtUserName.Clear();
                txtPassword.Clear();
                GetUsersTable();
            }
            else
            {
                int userId = Convert.ToInt32(txtPkUser.Text);

                Usuario usuario = new Usuario()
                {
                    PkUsuario = userId,
                    Nombre = txtNombre.Text,
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text,
                    FkRol = int.Parse(SelectRol.SelectedValue.ToString())
                };
                MessageBox.Show("REGISTRO ACTUALIZADO");
                services.UpdateUser(usuario);
                txtPkUser.Clear();
                txtNombre.Clear();
                txtUserName.Clear();
                txtPassword.Clear();
                //SelectRol.();
                GetUsersTable();
            }
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario = (sender as FrameworkElement).DataContext as Usuario;
            
            txtPkUser.Text = usuario.PkUsuario.ToString();
            txtNombre.Text = usuario.Nombre.ToString();
            txtUserName.Text = usuario.UserName.ToString();
            txtPassword.Text = usuario.Password.ToString();
            SelectRol.SelectedValue = usuario.FkRol.ToString(); 
        }
        public void DeleteItem(object sender, RoutedEventArgs e)
        {
            int userId = Convert.ToInt32(txtPkUser.Text);
            Usuario usuario = new Usuario();
            usuario.PkUsuario = userId;
            services.DeleteUser(userId);
            MessageBox.Show("REGISTRO ELIMINADO");
            txtPkUser.Clear();
            txtNombre.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            GetUsersTable();
        }
        public void GetUsersTable()
        {
            UserTable.ItemsSource = services.GetUsuarios();
        }
        public void GetRoles()
        {
            SelectRol.ItemsSource = services.GetRoles();
            SelectRol.DisplayMemberPath = "Nombre";
            SelectRol.SelectedValuePath = "PkRol";
        }
    }
}
