using ApiLojaEletronicos.Entities;
using ApiLojaEletronicos.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLojaEletronicos.Controllers
{
    [Route("api/Produtos")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutosDbContext _context;
        public ProdutosController(ProdutosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var produtos = _context.Produto.Where(d => !d.isDelete).ToList();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            var produtos = _context.Produto
              .SingleOrDefault(d => d.Id == id);
            if (produtos == null)
                return NotFound();

            return Ok(produtos);
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            _context.Produto.Add(produto);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, Produto produtos)
        {
            var produto = _context.Produto.SingleOrDefault(d => d.Id == id);
            if (produto == null)
                return NotFound();

            produto.Update(produtos.Nome, produtos.Valor, produtos.Quantidade, produtos.Marca);

            _context.Produto.Update(produto);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public ActionResult Delete(Guid id)
        {
            var produto = _context.Produto.SingleOrDefault(d => d.Id == id);
            if (produto == null)
                return NotFound();

            produto.Delete();

            _context.SaveChanges();
            return NoContent();
        }
    }
}
