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
        private const string _apiUrlBase = "http://localhost:8080/usuario";
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
            
            u = await _request.PostAsync(_apiUrlBase, u, string.Empty);

            return u;
        }

        public async Task<Usuario> PostAutenticarUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/autenticar";
            u = await _request.PostAsync(_apiUrlBase + urlComplementar, u, string.Empty);

            return u;
        }

        
    }
}
