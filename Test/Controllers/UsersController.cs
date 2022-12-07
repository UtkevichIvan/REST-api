using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Test.Controllers;

[ApiController]
[Route("api/v1/users")]
[Produces("application/json")]
public class UsersController : ControllerBase
{
    UsersContext db;
    public UsersController(UsersContext context)
    {
        db = context;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Client>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<Client>>> Get(int head, int tail)
    {
        if (!Request.QueryString.HasValue)
        {
            return await db.Clients.ToListAsync();
        }
        else
        {
            var clients = db.Clients.ToList();
            if (head <= 0 || tail <= 0 || head > clients.Count || tail > clients.Count)
            {
                return NotFound();
            }

            List<Client> result;
            if (head < tail)
            {
                result = clients.Skip(head - 1).Take(tail - head + 1).ToList();
            }
            else
            {
                result = new List<Client>();
                for (int i = head - 1; i >= tail - 1; i--)
                {
                    result.Add(clients[i]);
                }
            }

            return new ObjectResult(result);
        }
    }
}
