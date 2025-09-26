using LifitLoginPAM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifitLoginPAM.Services.Usuarios
{
    public class UsuarioService : Request
    {
        private readonly Request _request;
        private const string _apiUrlBase = "https://lifit-augfbubbgtcydahz.brazilsouth-01.azurewebsites.net/usuario";
        //Azure: https://lifit-augfbubbgtcydahz.brazilsouth-01.azurewebsites.net/


        public UsuarioService()
        {
            _request = new Request();
        }

        private string _token; 

        public UsuarioService(string token)
        {
            _request = new Request();
            _token = token;
        }

        public async Task<Usuario> PostRegistrarUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/Registrar";
            u.Id = await _request.PostReturnIntAsync(_apiUrlBase + urlComplementar, u, string.Empty);

            return u;
        }

        public async Task<Usuario> GetAutenticarUsuarioAsync(Usuario u, string nome, string senha)
        {
            string urlComplementar = "/" + nome + "/" + senha;
            u = await _request.GetAsync<Usuario>(_apiUrlBase + urlComplementar, string.Empty);

            return u;
        }

        public async Task<int> PutAtualizarLocalizacaoAsync(Usuario u)
        {
            string urlComplementar = "/AtualizarLocalizacao";
            var result = await _request.PutAsync(_apiUrlBase + urlComplementar, u, _token);
            return result;
        }
        //using System.Collections.ObjectModel
        public async Task<ObservableCollection<Usuario>> GetUsuariosAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Models.Usuario> listaUsuarios = await
            _request.GetAsync<ObservableCollection<Models.Usuario>>(_apiUrlBase + urlComplementar,
            _token);
            return listaUsuarios;
        }
    }
}
