using Microsoft.AspNetCore.Mvc;
using ProjetoA.Models;
using ProjetoA.Repository;
using ProjetoA.Services;
using System;
using System.Text.Json;

namespace ProjetoA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FolhaController : ControllerBase
    {
        private readonly FolhaRepository folhaRepository;
        private readonly FolhaService folhaService;

        public FolhaController(FolhaRepository folhaRepository, FolhaService folhaService)
        {
            this.folhaRepository = folhaRepository;
            this.folhaService = folhaService;

        }

        [HttpPost("cadastrar", Name = "Cadastrar")]
        public IActionResult Cadastrar([FromBody] Folha folha)
        {
            folha.bruto = folhaService.CalcularSalarioBruto(folha);
            folha.irrf = folhaService.CalcularIRRF(folha.bruto);
            folha.inss = folhaService.CalcularINSS(folha.bruto);
            folha.fgts = folhaService.CalcularFGTS(folha.bruto);
            folha.liquido = folhaService.CalcularSalarioLiquido(folha.bruto, folha.irrf, folha.inss);

            folhaRepository.Cadastrar(folha);

            try
            {
                string mensagem = JsonSerializer.Serialize(folha);
                folhaService.Enviar(mensagem);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return StatusCode(201, new
            {
                message = "Folha Cadastrada!",
                data = folha
            });
        }
    }
}