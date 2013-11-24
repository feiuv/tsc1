using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TestDemoPhoneApp1.Resources;

namespace TestDemoPhoneApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            try
            {
                 WebClient wc = new WebClient();
                 wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wcGetEstudianteCompletedDownload);
                 wc.DownloadStringAsync(new Uri("http://demotsci.azurewebsites.net/ServiceJSON.svc/GetEstudiantes"));

            }
            catch (Exception e){
                
            }
            // Código de ejemplo para traducir ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        void wcGetEstudianteCompletedDownload(object server, DownloadStringCompletedEventArgs e)
        {
            var root = Newtonsoft.Json.JsonConvert.DeserializeObject<Model.Estudiante[]>(e.Result);
            var est = root[0];
            txtNombre.Text = est.nombre;
        }

      
        // Código de ejemplo para compilar una ApplicationBar traducida
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Establecer ApplicationBar de la página en una nueva instancia de ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Crear un nuevo botón y establecer el valor de texto en la cadena traducida de AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Crear un nuevo elemento de menú con la cadena traducida de AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}