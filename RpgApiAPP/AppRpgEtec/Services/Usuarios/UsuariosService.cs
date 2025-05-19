using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppRpgEtec.Models;

namespace AppRpgEtec.Services.Usuarios
{
    internal class UsuariosService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "https://rpgapi3ai2025.azurewebsites.net"; // <-- adicionar nosso azure depois

        public UsuariosService()
            {
                _request = new Request();
            }

        public async Task<Usuario> PostRegistarUsuarioAsync(Usuario u) 
        {
            string urlComplementar = "/Registrar";
            u.Id = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, u, string.Empty);

            return u;
        }

        public async Task<Usuario> PostAutenticarUsuarioAsync(Usuario u) 
        {
            string urlComplementar = "/Autenticar";
            u = await _request.PostAsync(apiUrlBase + urlComplementar, u, string.Empty);

            return u;  
        }
    }
}
