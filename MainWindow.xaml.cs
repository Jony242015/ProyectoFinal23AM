using ProyectoFinal23AM.Services;
using ProyectoFinal23AM.Vistas;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoFinal23AM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        UsuarioServices services = new UsuarioServices();
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUserName.Text;
            string password = txtPassword.Password;

            var respose = services.Login(user, password);
            //LO CORRECTO
            //Usuario respose = services.Login(user, password);
            if (txtUserName.Text != null && txtPassword.Password != null)
            {
                if (respose != null)
                {
                    if (respose.Roles.Nombre == "Sa")
                    {
                        Sistema sistema = new Sistema();
                        sistema.Show();
                        Close();
                    }
                    else
                    {
                        Sistema sistema = new Sistema();
                        sistema.Show();
                        Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("CAMPOS VACIOS");
            }
        }

    }
}
