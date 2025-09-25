using System.Windows.Input;
using LoginLifit.Views; // Adicione o using para suas Views

namespace LoginLifit.ViewModels
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

        public ICommand LoginCommand { get; }
        public ICommand GoToRegisterCommand { get; }

        public LoginViewModel()
        {
            // Comando para navegar para a tela de sucesso
            LoginCommand = new Command(async () => await OnLoginClicked());

            // Comando para navegar para a tela de cadastro
            GoToRegisterCommand = new Command(async () => await OnGoToRegisterClicked());
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
    }
}