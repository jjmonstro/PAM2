using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LifitLoginPAM.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
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

        public ICommand CreateAccountCommand { get; }

        public RegisterViewModel()
        {
            CreateAccountCommand = new Command(async () => await OnCreateAccount());
        }

        private async Task OnCreateAccount()
        {
            // Lógica de validação e criação de conta viria aqui.
            // Por enquanto, apenas exibimos um alerta e voltamos para a tela de login.
            await Application.Current.MainPage.DisplayAlert("Sucesso", "Conta criada!", "OK");

            // Navega de volta para a página anterior (Login)
            await Shell.Current.GoToAsync("..");
        }
    }
}
