using ApiVarejo.BLL;
using ApiVarejo.MOD;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoEstágioFiap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VarejoController : ControllerBase
    {
        //Propriedades readonly só podem ser mudadas no seu ínicio ou constructor
        private readonly VarejoBLL _VarejoBLL;
        public VarejoController() 
        {
            _VarejoBLL= new VarejoBLL();
        }
        [HttpPost("Cadastro")]
        public IActionResult Cadastrar([FromBody] Usuário usuario) 
        {
            try
            {
                return Ok(_VarejoBLL.Cadastrar(usuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Filtro")]
        public IActionResult Listar([FromQuery] Usuário usuario)
        {
            try
            {
                return Ok(_VarejoBLL.Listar(usuario));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Atualizamento")]
        public IActionResult Atualizar([FromBody] Usuário usuario)
        {
            try
            {
                return Ok(_VarejoBLL.Atualizar(usuario));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Exclusão")]
        public IActionResult Deletar([FromQuery] int id) 
        {
            try
            {
                return Ok(_VarejoBLL.Deletar(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}