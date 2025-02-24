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

<<<<<<< HEAD
        [HttpGet("Get")]        
=======
        [HttpGet("Get")]
>>>>>>> 77e5c1c74e71c7e641c43ed248fd220e723dda2a
        public IActionResult GetFirst()
        {
            Personagem p = personagens[0];
            return Ok(p);
        }

<<<<<<< HEAD
        [HttpGet("Getall")]
=======
        [HttpGet("GetAll")]
>>>>>>> 77e5c1c74e71c7e641c43ed248fd220e723dda2a
        public IActionResult Get()
        {
            return Ok(personagens);
        }

        [HttpPost]
<<<<<<< HEAD
        public IActionResult AddPersonagem(Personagem novoPersonagem)
        {
            personagens.Add(novoPersonagem);
            return Ok(personagens);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            personagens.RemoveAll(pers => pers.Id == id);
=======
        public IActionResult AddPersonagem(Personagem novopersonagem)
        {
            personagens.Add(novopersonagem);
>>>>>>> 77e5c1c74e71c7e641c43ed248fd220e723dda2a
            return Ok(personagens);
        }

        [HttpPut]
<<<<<<< HEAD
        public IActionResult UpdatePersonagem(Personagem p)
        {
            Personagem personagemAlterado = personagens.Find(pers => pers.Id == p.Id);
=======
        public IActionResult UpdatePersonagem(Personagem p){
            Personagem personagemAlterado = personagens.Find(pers=> pers.Id == p.Id);
>>>>>>> 77e5c1c74e71c7e641c43ed248fd220e723dda2a
            personagemAlterado.Nome = p.Nome;
            personagemAlterado.PontosVida = p.PontosVida;
            personagemAlterado.Forca = p.Forca;
            personagemAlterado.Defesa = p.Defesa;
            personagemAlterado.Inteligencia = p.Inteligencia;
            personagemAlterado.Classe = p.Classe;
<<<<<<< HEAD
            
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
        public IActionResult GetSingle(int id){
            return Ok(personagens.FirstOrDefault(pe => pe.Id == id));
        }

        
=======

            return Ok(personagens);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            personagens.RemoveAll(pers => pers.Id == id);
            return Ok(personagens);
        }

        [HttpGet("GetByEnum/{enumId}")]
        public IActionResult GetByEnum(int enumId){
            ClasseEnum enumDigitado = (ClasseEnum)enumId;

            List<Personagem> listaBusca = personagens.FindAll(p => p.Classe == enumDigitado);

            return Ok(listaBusca);
        }
>>>>>>> 77e5c1c74e71c7e641c43ed248fd220e723dda2a
    }
}