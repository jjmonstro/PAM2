using AppRpgEtec.ViewModels.Usuarios;

namespace AppRpgEtec.Views.Usuarios;

public partial class LoginView : ContentPage
{
	public LoginView()
	{
		InitializeComponent();

		UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
		BindingContext = usuarioViewModel;
	}
}