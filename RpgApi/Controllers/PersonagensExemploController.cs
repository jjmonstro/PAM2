using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Enuns;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagensExemploController : ControllerBase
    {
        //Lista de Personagens
        private static List<Personagem> personagens = new List<Personagem>()
        {
            //Colar os objetos da lista do chat aqui
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };

        [HttpGet("Get")]
        public IActionResult GetFirst()
        {
            Personagem p = personagens[0];
            return Ok(p);
        }

        [HttpGet("Getall")]
        public IActionResult Get()
        {
            return Ok(personagens);
        }

        [HttpPost]
        public IActionResult AddPersonagem(Personagem novoPersonagem)
        {
            personagens.Add(novoPersonagem);
            return Ok(personagens);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            personagens.RemoveAll(pers => pers.Id == id);
            return Ok(personagens);
        }

        [HttpPut]
        public IActionResult UpdatePersonagem(Personagem p)
        {
            Personagem personagemAlterado = personagens.Find(pers => pers.Id == p.Id);
            personagemAlterado.Nome = p.Nome;
            personagemAlterado.PontosVida = p.PontosVida;
            personagemAlterado.Forca = p.Forca;
            personagemAlterado.Defesa = p.Defesa;
            personagemAlterado.Inteligencia = p.Inteligencia;
            personagemAlterado.Classe = p.Classe;

            return Ok(personagens);
        }


        [HttpGet("GetByEnum/{enumID}")]
        public IActionResult GetByEnum(int enumID)
        {
            ClasseEnum enumDigitado = (ClasseEnum)enumID;
            List<Personagem> listaBusca = personagens.FindAll(p => p.Classe == enumDigitado);
            return Ok(listaBusca);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(personagens.FirstOrDefault(pe => pe.Id == id));
        }

        [HttpGet("GetOrdenado")]
        public IActionResult GetOrdenado()
        {
            return Ok(personagens.OrderBy(p => p.Forca));
        }

        [HttpGet("GetQuantidade")]
        public IActionResult GetContagem()
        {
            return Ok(personagens.Count());
        }

        [HttpGet("GetDefesas")]
        public IActionResult GetDefesas()
        {
            return Ok(personagens.Sum(p => p.Defesa));
        }

        [HttpGet("GetCavaleiros")]
        public IActionResult GetCavaleiros()
        {
            return Ok(personagens.Find(p => p.Classe == ClasseEnum.Cavaleiro));
        }

        //EXERCIICOS---------------------------------------------------------------------------------

        //1
        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            Personagem personagem = personagens.Find(p => p.Nome.Contains(nome));
            if (personagem == null)
            {
                return NotFound("Personagem não encontrado");
            }
            else
            {
                return Ok(personagens.Find(p => p.Nome.Contains(nome)));
            }

        }

        //2
        [HttpGet("GetClerigoMago")]
        public IActionResult GetClerigoMago()
        {
            personagens.RemoveAll(p => p.Classe == ClasseEnum.Cavaleiro);
            return Ok(personagens.OrderByDescending(p => p.PontosVida));
        }

        //3
        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas()
        {
            return Ok(new
            {
                totalPersonagens = personagens.Count(),
                somaInteligencia = personagens.Sum(p => p.Inteligencia)
            });
        }

        //4
        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao(Personagem p)
        {
            if (p.Defesa < 10 || p.Inteligencia > 30)
            {
                return BadRequest("Um personagem não pode ter esses status");
            }
            personagens.Add(p);
            return Ok(personagens);
        }

        //5
        [HttpPost("PostValidacaoMago")]
        public IActionResult PostValidacaoMago(Personagem p)
        {
            if (p.Classe == ClasseEnum.Mago && p.Inteligencia < 35)
            {
                return BadRequest("Um personagem mago não pode ter esses status");
            }
            personagens.Add(p);
            return Ok(personagens);
        }

        //6
        [HttpGet("GetByClasse/{id}")]
        public IActionResult GetByClasse(int id)
        {
            return Ok(personagens.FindAll(p => (int)p.Classe == id));
        }
    }
}