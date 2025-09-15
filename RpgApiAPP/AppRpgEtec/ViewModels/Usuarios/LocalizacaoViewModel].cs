using System.Collections.ObjectModel;
using System.Runtime.InteropServices.Marshalling;
using AppRpgEtec.Models;
using AppRpgEtec.Services.Usuarios;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;
namespace AppRpgEtec.ViewModels.Usuarios;

public class LocalizacaoViewModel_ : ContentPage
{
	private Map meuMapa;
	public Map MeuMapa
	{
		get => meuMapa;
		set
		{
			if (value != null)
			{
				meuMapa = value;
				OnPropertyChanged();
			}
		}
	}

	public async void InicializarMapa()
	{
		try
		{
			Location location = new Location(-26.5200241d, -46.596498d);
			Pin pinEtec = new Pin() { 
			Type=PinType.Place,
			Label = "Etec Horácio",
			Address = "Rua alcântara, 113,Vila Guilherme",
			Location = location
			};

			Map map = new Map();
			MapSpan mapSpan = MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(5));
			map.Pins.Add(pinEtec);
			map.MoveToRegion(mapSpan);
			MeuMapa = map;
		}
		catch (Exception ex)
		{
			await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
		}
	}

	private UsuarioService uService;
	public LocalizacaoViewModel_()
	{
		string token = Preferences.Get("UsuarioToken", string.Empty);
		uService = new UsuarioService();
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}

    public async void ExibirUsuariosNoMapa()
    {
        try
        {
            //using AppRpgEtec.Models
            ObservableCollection<Usuario> ocUsuarios = await uService.GetUsuariosAsync();
            List<Usuario> listaUsuarios = new List<Usuario>(ocUsuarios);
            Map map = new Map();
            foreach (Usuario u in listaUsuarios)
            {
                if (u.Latitude != null && u.Longitude != null)
                {
                    double latitude = (double)u.Latitude;
                    double logitude = (double)u.Longitude;
                    Location location = new Location(latitude, logitude);
                    Pin pinAtual = new Pin()
					{
					Type = PinType.Place,
					Label = u. Username,
					Address = $"E-mail: {u.Email}",
					Location = location
					};
                    map.Pins.Add(pinAtual);
                }
            }
            MeuMapa = map;
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}