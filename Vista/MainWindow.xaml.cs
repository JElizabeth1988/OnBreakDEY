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

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
           
            InitializeComponent();

        }

        //Botón Menú
        private void Tile_Click_Menu(object sender, RoutedEventArgs e)
        {
            FlyoutMenu.IsOpen = true;
        }
        //Módulo Cliente
        private void Tile_Click_cliente(object sender, RoutedEventArgs e)
        {
            WpfCliente cliente = new WpfCliente();
            cliente.Show();

        }
        //Listar Cliente.......
        private void Tile_Click_L_cliente(object sender, RoutedEventArgs e)
        {
            wpfListadoCliente listCliente = new wpfListadoCliente();
            listCliente.Show();

        }
        //Módulo Contrato
        private void Tile_Click_Contrato(object sender, RoutedEventArgs e)
        {
            Crear_Contrato contrato = new Crear_Contrato();
            contrato.Show();

        }
        //Listado de Contratos
        private void Tile_Click_L_Contrato(object sender, RoutedEventArgs e)
        {
            ListarContrato listContrato = new ListarContrato();
            listContrato.Show();
        }


        /* private async void Tile_Click_6(object sender, RoutedEventArgs e)
         {
             var x =
             await this.ShowMessageAsync("Advertencia", "¿Desea cerrar sesión?", 
                     MessageDialogStyle.AffirmativeAndNegative);
             if (x == MessageDialogResult.Affirmative)
             {
                 Login log = new Login();
                 this.Close();
                 log.ShowDialog();
             }
             else
             {

             }

         }*/
    }

}
