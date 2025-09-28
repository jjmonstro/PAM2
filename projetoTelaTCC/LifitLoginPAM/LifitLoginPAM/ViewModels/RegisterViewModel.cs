using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LifitLoginPAM.Models;
using LifitLoginPAM.Services.Usuarios;

namespace LifitLoginPAM.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private UsuarioService _uService;
        // Propriedades para cada campo do formulário
        private string _fullName;
        public string FullName { get => _fullName; set { _fullName = value; OnPropertyChanged(); } }

        private string _email;
        public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }

        private string _password;
        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }

        private string _confirmPassword;
        public string ConfirmPassword { get => _confirmPassword; set { _confirmPassword = value; OnPropertyChanged(); } }

        private string _username;
        public string Username { get => _username; set { _username = value; OnPropertyChanged(); } }

        private string _biography;
        public string Biography { get => _biography; set { _biography = value; OnPropertyChanged(); } }

        public ICommand CreateAccountCommand { get; }

        public RegisterViewModel()
        {
            CreateAccountCommand = new Command(async () => await OnCreateAccount());
            _uService = new UsuarioService();
        }

        private async Task OnCreateAccount()
        {
            try
            {
                Usuario u = new();
                u.NomeUsuario = _username;
                u.Senha = _password;
                u.Nome = _fullName;
                u.Biografia = _biography;
                u.Email = _email;

                if (_password!= _confirmPassword)
                    {
                        await Application.Current.MainPage.DisplayAlert("Erro","Confirmação de senha e senha diferentes","Ok");
                        return;
                    }
                
                Usuario uRegistrado = await _uService.PostRegistrarUsuarioAsync(u);

                if (uRegistrado.NomeUsuario != null)
                {
                    string mensagem = $"Usuário {uRegistrado.NomeUsuario} registrado com sucesso.";
                    await Application.Current.MainPage.DisplayAlert("Parabéns", mensagem, "Ok");

                    await Application.Current.MainPage
                        .Navigation.PopAsync();//Remove a página da pilha de visualização
                }
            }catch(Exception ex)
            {
                if (!_email.Contains("@"))
                {
                    await Application.Current.MainPage.DisplayAlert("ERRO", "Dados inválidos\nconfira seu email", "Ok");

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("ERRO", "Nome de usuário ou email já existentes", "Ok");
                }
                
                
            }
                
            
            
            
        }
    }
}
