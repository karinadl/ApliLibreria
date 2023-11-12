using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {

        private LibroDAO libroDAO = new LibroDAO();
        // EndPoint para recuperar todos los libros
        [HttpGet("libros")]
        public ActionResult<IEnumerable<Libro>> GetLibros()
        {
            var libros = libroDAO.seleccionarTodos();

            if (libros == null || libros.Count == 0)
            {
                return null;
            }

            return libros;
        }
        //EndPoint para recuperar un libro con base a su id
        [HttpGet("libro")]
        public Libro getlibro(int id)
        {
            return libroDAO.seleccionar(id);
        }

        //EndPoint para insertar un libro
        [HttpPost("libro")]
        public bool insertarlibro([FromBody] Libro libro, int id_asig)
        {
            return libroDAO.insertar(libro.Title, libro.Chapters, libro.Pages, libro.Price, libro.AuthorId);
        }

        //Endpoint para actualizar los datos del libro.
        [HttpPut("libro")]
        public bool insertarLibro([FromBody] Libro libro)
        {
            return libroDAO.actualizar(libro.Id, libro.Title, libro.Chapters, libro.Pages, libro.Price, libro.AuthorId);
        }

        //Endpoint para eliminar a un libro.
        [HttpDelete("libro")]
        public bool eliminarLibro(int id)
        {
            return libroDAO.eliminar(id);
        }


    }
}
