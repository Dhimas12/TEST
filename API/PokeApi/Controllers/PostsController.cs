using Microsoft.AspNetCore.Mvc;
using PokeApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using System.IO;


namespace PokeApi.Controllers
{
    [ApiController]
    [Route("api/pokemon")]
    public class PostsController : ControllerBase
    {
        private readonly string filepath;

        public PostsController(string filepath)
        {
            this.filepath = filepath;
        }

        readonly HttpClient client = new HttpClient();
        [HttpGet("{pokemon}")]
        public async Task<IActionResult> GetPoKemon(string pokemon)
        {
            HttpResponseMessage response = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{pokemon}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return Ok(responseBody);

        }
        [HttpGet]
        public async Task<IActionResult> Getalpokemon()
        {
            HttpResponseMessage response = await client.GetAsync("https://pokeapi.co/api/v2/pokemon?offset=0}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return Ok(responseBody);



        }



        [HttpGet]

        [Route("api/Download/{nombre}")]
        public FileContentResult Get(string nombre)
        {
            

            string path = @"c:\temp\Pokemon.txt";
            System.IO.File.WriteAllText(path, "Detalles del pokemon: " + nombre);
            return File(System.IO.File.ReadAllBytes(path), "application/octet-stream", "Pokemon.txt");






        } 


       




        //[HttpGet("filtro")]
        //public Task<IActionResult> Filtro(List<Root> root)
        //{
        //    HttpResponseMessage response = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{pokemon}");
        //    response.EnsureSuccessStatusCode();
        //    string responseBody = await response.Content.ReadAsStringAsync();
        //    return Ok(responseBody);

        //     root = new List<Root> { new Root
        //     {

        //     } }

        //}








    }



    
}
