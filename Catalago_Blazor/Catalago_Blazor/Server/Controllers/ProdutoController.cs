using Catalago_Blazor.Client.Shared.Recursos;
using Catalago_Blazor.Server.Context;
using Catalago_Blazor.Server.Util;
using Catalago_Blazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalago_Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProdutoController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet("todos")]

        public async Task<ActionResult<List<Produto>>> Get()
        {
            return await context.Produtos.AsNoTracking().ToListAsync();
        }


        [HttpGet("categorias/{id:int}")]
        public async Task<ActionResult<List<Produto>>> GetProdutosCategoria(int id)
        {
            return await context.Produtos.Where(p => p.CategoriaId == id).ToListAsync();
        }


        [HttpGet("{id}", Name = "GetProduto")]

        public async Task<ActionResult<Produto>> Get(int id)
        {
            return await context.Produtos.FirstOrDefaultAsync(x => x.ProdutoId == id);
        }

        public async Task<ActionResult<List<Produto>>> Get([FromQuery] Paginacao paginacao, [FromQuery] string? nome)
        {
            var queryable = context.Produtos.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                queryable = queryable.Where(x => x.Nome.Contains(nome));
            }

            await HttpContext.InserirParametroEmPageResponde(queryable, paginacao.QuantidadePorPagina);
            return await queryable.Paginar(paginacao).ToListAsync();

        }


        [HttpPost]
        public async Task<ActionResult<Produto>> Post(Produto produto)
        {
            context.Add(produto);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpPut]
        public async Task<ActionResult<Produto>> Put(Produto produto)
        {
            context.Entry(produto).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> Delete(int id)
        {
            var produto = new Produto { ProdutoId = id };
            context.Remove(produto);
            await context.SaveChangesAsync();
            return Ok(produto);
        }
    }
}
