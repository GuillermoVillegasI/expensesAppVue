using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vueJsBack.Conext;
using vueJsBack.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace vueJsBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoController : ControllerBase
    {

        private readonly AplicationDbContext _context;

        public GastoController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<Default>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listGastos = await _context.Gastos.ToListAsync();
                return Ok(listGastos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Gasto gasto)
        {
            try
            {
                _context.Gastos.Add(gasto);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Gasto agregado correctamente !" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {

            try
            { 
                var gasto = await _context.Gastos.FindAsync(id);
                if (gasto == null)
                {
                    return NotFound();
                }

                _context.Gastos.Remove(gasto);
                await _context.SaveChangesAsync();
                return Ok(new {message = "Gasto eliminado"});

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
