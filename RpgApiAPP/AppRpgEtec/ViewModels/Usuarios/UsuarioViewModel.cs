using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppRpgEtec.Models;
using AppRpgEtec.Services.Usuarios;

namespace AppRpgEtec.ViewModels.Usuarios
{
    internal class UsuarioViewModel : BaseViewModel
    {
        private UsuariosService uService;
        public ICommand AutenticarCommand { get; set; }

        public UsuarioViewModel()
        {
            uService = new UsuariosService();
            InicializarCommands();
        }

        public void InicializarCommands() 
        {
            AutenticarCommand = new Command(async () => await AutenticarUsuario());
        }


        private string login = string.Empty;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }

        private string senha = string.Empty;
        private string mensagem;

        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                OnPropertyChanged();
            }

        }

        public async Task AutenticarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.Username = Login;
                u.PasswordString = Senha;

                Usuario uAutenticado = await uService.PostAutenticarUsuarioAsync(u);

                if (!string.IsNullOrEmpty(uAutenticado.token))
                {
                    string mesagem = $"Bem-vindo(a) {uAutenticado.Username}.";

                    Preferences.Set("UsuarioId", uAutenticado.Id);
                    Preferences.Set("UsuarioUsername", uAutenticado.Username);
                    Preferences.Set("UsuarioPerfil", uAutenticado.Perfil);
                    Preferences.Set("UsuarioToken", uAutenticado.token);

                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");

                    Application.Current.MainPage = new MainPage();
                }
                else 
                {
                    await Application.Current.MainPage.DisplayAlert("Informação", "Dados incorretos :(", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }



    }
}
