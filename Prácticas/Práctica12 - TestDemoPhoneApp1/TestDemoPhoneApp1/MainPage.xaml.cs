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
            ServiceJson.ServiceJSONClient client = new ServiceJson.ServiceJSONClient();
            client.GetEstudianteAsync("1", 2);
            client.GetEstudianteCompleted += new EventHandler<ServiceJson.GetEstudianteCompletedEventArgs>(GetEstudianteCompletedDownload);
            
            // Código de ejemplo para traducir ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        void GetEstudianteCompletedDownload(object sender, ServiceJson.GetEstudianteCompletedEventArgs e)
        {
            var est = e.Result;
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