using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartSchool.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno(){Id=1, Nome="Marcos", Sobrenome="Cintra"},
            new Aluno(){Id=2, Nome="Carlos", Sobrenome="Amaral"},
            new Aluno(){Id=3, Nome="Luis", Sobrenome="Cintra"}
        };
        

        [HttpGet] // Acessar todos All
        public ActionResult Get()
        {
            // acesso =======  http://localhost:5000/api/aluno
            return Ok(JsonConvert.SerializeObject(Alunos));

        }

        [HttpGet("byId/{id}")] // Acessar por Id
        // acesso ======= http://localhost:5000/api/aluno/byid/1
        public ActionResult GetById(int id)
        {
            var resultado = Alunos.FirstOrDefault(x => x.Id == id);

            if (resultado == null) return BadRequest("O Aluno não foi encontrado");
            
            return Ok(JsonConvert.SerializeObject(resultado));
        }

        //[HttpGet("nomeId/{nome}/sobrenomeId/{sobrenome}")]
        // acesso ======= http://localhost:5000/api/aluno/nomeid/Carlos/sobrenomeid/Amaral
        // ou
        [HttpGet("nomeId")] // Acessar por nome e Sobrenome ou somente nome
        // acesso ======= http://localhost:5000/api/aluno/nomeid?nome=carlos&sobrenome=amaral
        public ActionResult GetByName(string nome, string sobrenome)
        {

            //var resultado = Alunos.FirstOrDefault(x => x.Nome.ToUpper() == nome.ToUpper() && x.Sobrenome.ToUpper() == sobrenome.ToUpper());
            // ou
            var resultado = Alunos.FirstOrDefault(x => x.Nome.ToUpper().Contains(nome.ToUpper()) && x.Sobrenome.ToUpper().Contains(sobrenome.ToUpper()));

            if (resultado == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(JsonConvert.SerializeObject(resultado));
        }

        [HttpPost] // Incluir novo registro
        public ActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")] // Alterar todo registro
        public ActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPatch("{id}")] // Alterar parcialmente
        public ActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete] // Deletar registro
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
