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

using BibliotecaClase;
using BibliotecaControlador;


using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para WpfCliente.xaml
    /// </summary>
    public partial class WpfCliente : MetroWindow
    {
        DaoCliente dao;

        public WpfCliente()
        {
            InitializeComponent();

            //llenar el combo box con los datos del enumerador
            cbActividad.ItemsSource = Enum.GetValues(typeof
                (ActividadEmpresa));
            cbActividad.SelectedIndex = 0;

            cbTipo.ItemsSource = Enum.GetValues(typeof
                (TipoEmpresa));
            cbTipo.SelectedIndex = 0;

            dao = new DaoCliente();
        }

        //-botón limpiar
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtRut.Clear();
            txtRazon.Clear();
            txtNombre.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            cbActividad.SelectedIndex = 0;
            cbTipo.SelectedIndex = 0;//Para que en el ComboBox no quede seleccionado nada
            txtRut.Focus();//Mover el cursor a la poscición Rut

        }

        //Botón '?'
        private void btnPregunta_Click(object sender, RoutedEventArgs e)
        {
            wpfListadoCliente lis = new wpfListadoCliente(this);
            lis.Show();

        }

        //Botón Cancelar/Cerrar
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Botón Guardar
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String rut = txtRut.Text;
                String razonSocial = txtRazon.Text;
                String nombreContacto = txtNombre.Text;
                String mail = txtEmail.Text;
                String direccion = txtDireccion.Text;
                int telefono = int.Parse(txtTelefono.Text);
                ActividadEmpresa actividad = (ActividadEmpresa)cbActividad.SelectedItem;
                TipoEmpresa empresa = (TipoEmpresa)cbTipo.SelectedItem;
                Cliente c = new Cliente()
                {
                    Rut = rut,
                    RazonSocial = razonSocial,
                    NombreContacto = nombreContacto,
                    Mail = mail,
                    Direccion = direccion,
                    Telefono = telefono,
                    Actividad = actividad,
                    Empresa = empresa

                };
                bool resp = dao.Agregar(c);
                MessageBox.Show(resp ? "Guardado" : "No Guardado");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de ingreso de datos");

            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
