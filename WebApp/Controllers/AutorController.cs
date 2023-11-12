using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private AutorDAO autorDAO = new AutorDAO();
        // EndPoint para recuperar todos los autores
        [HttpGet("autores")]
        public ActionResult<IEnumerable<Autor>> GetAutores()
        {
            var autor = autorDAO.seleccionarTodos();

            if (autor == null || autor.Count == 0)
            {
                return null;
            }

            return autor;
        }
        //EndPoint para recuperar a un autor con base a su id
        [HttpGet("autor")]
        public Autor getAutor(int id)
        {
            return autorDAO.seleccionar(id);
        }

        //EndPoint para insertar a un autor
        [HttpPost("autor")]
        public bool insertarAutor([FromBody] Autor autor, int id_asig)
        {
            return autorDAO.insertar(autor.Name);
        }

        //Endpoint para actualizar los datos del autor.
        [HttpPut("autor")]
        public bool actualizarAutor([FromBody] Autor autor)
        {
            return autorDAO.actualizar(autor.Id, autor.Name);
        }

        //Endpoint para eliminar a un autor.
        [HttpDelete("autor")]
        public bool eliminarAutor(int id)
        {
            return autorDAO.eliminar(id);
        }

    }
}
