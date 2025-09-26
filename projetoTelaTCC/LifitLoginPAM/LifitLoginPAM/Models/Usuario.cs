using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace LifitLoginPAM.Models
{
    public class Usuario
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("senha")]
        public string Senha { get; set; } = string.Empty;

        [JsonPropertyName("nomeUsuario")]
        public string NomeUsuario { get; set; } = string.Empty;
    }
}