using Catalago_Blazor.Client.Shared.Recursos;
using Catalago_Blazor.Server.Context;
using Catalago_Blazor.Server.Util;
using Catalago_Blazor.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Catalago_Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext context;

        public CategoriaController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet("todas")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            return await context.Categorias.AsNoTracking().ToListAsync();
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get([FromQuery] Paginacao paginacao, [FromQuery] string? nome)
        {
            var queryable = context.Categorias.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                queryable = queryable.Where(x => x.Nome.Contains(nome));
            }

            await HttpContext.InserirParametroEmPageResponde(queryable, paginacao.QuantidadePorPagina);
            return await queryable.Paginar(paginacao).ToListAsync();

        }
        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetCategoria")]

        public async Task<ActionResult<Categoria>> Get(int id)
        {
            return await context.Categorias.FirstOrDefaultAsync(x => x.CategoriaId == id);
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            context.Add(categoria);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetCategoria", new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut]
        public async Task<ActionResult<Categoria>> Put(Categoria categoria)
        {
            context.Entry(categoria).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            var categoria = new Categoria { CategoriaId = id };
            context.Remove(categoria);
            await context.SaveChangesAsync();
            return Ok(categoria);
        }


    }
}
