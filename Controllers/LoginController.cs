using ApiLojaEletronicos.Entities;
using ApiLojaEletronicos.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLojaEletronicos.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginDbContext _context;
        public LoginController(LoginDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var login = _context.Login;
            if (login == null)
                return NotFound();

            return Ok(login);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            var login = _context.Login
              .SingleOrDefault(d => d.Id == id);
            if (login == null)
                return NotFound();

            return Ok(login);
        }

        [HttpPost]
        public ActionResult Post(Login login)
        {
            _context.Login.Add(login);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = login.Id }, login);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, Login logins)
        {
            var login = _context.Login.SingleOrDefault(d => d.Id == id);
            if (login == null)
                return NotFound();

            login.Update(logins.Usuario, logins.Senha, logins.Cpf, logins.Tipo,logins.DataNascimento);

            _context.Login.Update(login);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public ActionResult Delete(Guid id)
        {
            var login = _context.Login.SingleOrDefault(d => d.Id == id);
            if (login == null)
                return NotFound();

            login.Delete();

            _context.SaveChanges();
            return NoContent();
        }
    }
}
