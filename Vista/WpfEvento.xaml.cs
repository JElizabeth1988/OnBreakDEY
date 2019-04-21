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
    /// Lógica de interacción para WpfEvento.xaml
    /// </summary>
    public partial class WpfEvento : MetroWindow
    {
        DaoEvento dao;
        public WpfEvento()
        {
            InitializeComponent();
            dao = new DaoEvento();
        }

        private async void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                String nombreTipoEvento = txtNombreTipoEvento.Text;
                int valorBase = int.Parse(txtValorBase.Text);
                int personalBase = int.Parse(txtPersonalBase.Text);

                Evento even = new Evento()
                {

                    NombreTipoEvento = nombreTipoEvento,
                    ValorBase = valorBase,
                    PersonalBase = personalBase,



                };

                //METODO AGREGAR DEVUELVE BOOLEAN POR ESO SE CREA VARIABLE BOOLEANA resp
                bool resp = dao.Agregar(even);
                await this.ShowMessageAsync("Mensaje:",
                      string.Format(resp ? "Guardado" : "No Guardado"));
                /*MessageBox.Show(resp ? "Guardado" : "No Guardado");*/


            }
            catch (ArgumentException exa) //catch excepciones hechas por el usuario
            {
                MessageBox.Show(exa.Message);
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error de Ingreso de datos"));
                /*MessageBox.Show("Error de ingreso de datos");*/
                Logger.Mensaje(ex.Message);
            }




        }
    }
}
