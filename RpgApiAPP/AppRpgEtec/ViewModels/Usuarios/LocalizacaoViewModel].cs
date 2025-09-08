using System.Runtime.InteropServices.Marshalling;
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

	public LocalizacaoViewModel_()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}
}