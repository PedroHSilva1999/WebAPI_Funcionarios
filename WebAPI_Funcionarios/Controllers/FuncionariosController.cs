using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Funcionarios.Models;
using WebAPI_Funcionarios.Service.FuncionariosService;

namespace WebAPI_Funcionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionariosService;
        public FuncionariosController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionariosService = funcionarioInterface;
        }
        [HttpGet]
        public async Task<IActionResult> GetFuncionarios()
        {
            return Ok(await _funcionariosService.GetFuncionarios());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFuncionarioByID(int id)
        {
            return Ok(await _funcionariosService.GetFuncionarioByID(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateFuncionario(FuncionarioModel funcionarioModel)
        {
            return Ok(await _funcionariosService.CreateFuncionario(funcionarioModel));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFuncionario(FuncionarioModel funcionarioModel)
        {
            return Ok(await _funcionariosService.UpdateFuncionario(funcionarioModel));
        }
        [HttpPut("InativaFuncionario")]
        public async Task<IActionResult> InativaFuncionario(int Id)
        {
            return Ok(await _funcionariosService.InativaFuncionario(Id));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFuncionario(int id)
        {
            return Ok(await _funcionariosService.DeleteFuncionario(id));
        }
    }
}
