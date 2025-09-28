using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LifitLoginPAM.Models;
using LifitLoginPAM.Services.Usuarios;
using LifitLoginPAM.Views;
using System.Net.Http.Headers;

namespace LifitLoginPAM.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _emailOrUsername;
        public string EmailOrUsername
        {
            get => _emailOrUsername;
            set
            {
                _emailOrUsername = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        
        public ICommand GoToRegisterCommand { get; }

        public ICommand LoginCommand { get; set; }
        

        private UsuarioService _uService;
        public LoginViewModel()
        {
            _uService = new UsuarioService();
            // Comando para navegar para a tela de sucesso
            

            // Comando para navegar para a tela de cadastro
            GoToRegisterCommand = new Command(async () => await OnGoToRegisterClicked());
            LoginCommand = new Command(async () => await AutenticarUsuario());
          
        }

        private async Task OnLoginClicked()
        {
            // Lógica de autenticação viria aqui
            
            // Navegando para a HomePage
            await Shell.Current.GoToAsync(nameof(HomePage));
        }

        private async Task OnGoToRegisterClicked()
        {
            // Navegando para a RegisterPage
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }

       


       

        public async Task AutenticarUsuario()
        {

            Usuario u = new Usuario();
            u.NomeUsuario = _emailOrUsername;
            u.Senha = _password;
            Usuario uAutenticado = await _uService.PostAutenticarUsuarioAsync(u);
            if (uAutenticado == null)
            {
                await Application.Current.MainPage
                        .DisplayAlert("Informação", "Dados incorretos :(", "Ok");
            }
            else { 
                
                        await Shell.Current.GoToAsync(nameof(HomePage));
                    
            }
            
        }

        
    }
}
