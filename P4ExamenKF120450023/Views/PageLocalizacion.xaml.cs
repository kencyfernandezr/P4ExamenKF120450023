using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;


namespace P4ExamenKF120450023.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLocalizacion : ContentPage
    {
        public PageLocalizacion()
        {
            InitializeComponent();
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            Location location=null;
            try
            {
                location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null && descripcion_corta.Text.Length != 0 && descripcion_larga.Text.Length != 0)
                {
                    Latitud.Text = Convert.ToString(location.Latitude);
                    Longitud.Text = Convert.ToString(location.Longitude);

                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");

                    if (App.Database.Savegeo())
                }
                else
                {
                    if (location == null)
                    {
                        await DisplayAlert("Error", "Error no esta activo el gps", "Ok");
                    }
                    else if (descripcion_corta.Text.Length == 0 )
                    {
                        await DisplayAlert("Error", "Error sin descripcion corta", "Ok");
                    }
                    else if (descripcion_larga.Text.Length == 0)
                    {
                        await DisplayAlert("Error", "Error sin descripcion larga", "Ok");
                    }
                }
            }
            catch (Exception)
            {
                if(location==null)
                {
                    await DisplayAlert("Error", "Error no esta activo el gps", "Ok");
                }
            }
        }

        private void btnver_Clicked(object sender, EventArgs e)
        {
           
        }
    }
}