using BancoAPI.Entities;
using BancoAPI.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BancoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly DBcontext _context;

        public ContaController(DBcontext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetContas()
        {
            var contas = _context.Contas.Where(x => !x.IsDeleted).ToList();
            return Ok(contas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetContaID(int id)
        {
            var conta = _context.Contas.SingleOrDefault(x => x.Id == id);
            if (conta == null)
            {
                return NotFound();
            }
            return Ok(conta);
        }

        [HttpPost("Poupanca")]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public IActionResult CriarContaPoupanca(Poupanca poupanca)
        {
            _context.Contas.Add(poupanca);
            return CreatedAtAction("GetContaID", new { id = poupanca.Id }, poupanca);
        }

        [HttpPost("Corrente")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CriarContaCorrente(Corrente corrente)
        {
            _context.Contas.Add(corrente);
            return CreatedAtAction("GetContaID", new { id = corrente.Id }, corrente);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Put(int id, Conta input)
        {
            var userReturned = _context.Contas.SingleOrDefault(d => d.Id == id);

            if (userReturned == null)
            {
                return NotFound();
            }

            userReturned.Update(input.Saldo);

            //_context.Users.Update(userReturned);
            //_context.SaveChanges();

            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            var userRet = _context.Contas.SingleOrDefault(d => d.Id == id);

            if (userRet == null)
            {
                return NotFound();
            }

            userRet.Delete();
            //_context.SaveChanges();

            return NoContent();
        }

    }
}
