using AccesoDatos.Context;
using AccesoDatos.Models;

namespace AccesoDatos.Operaciones
{
    public class LibroDAO
    {
        //Creamos un objeto de contexto de BD
        public LibreriaContext libreria = new LibreriaContext();

        //Método para seleccionar todos los libros
        public List<Libro> seleccionarTodos()
        {
            var libros = libreria.Libros.ToList<Libro>();
            return libros;
        }
        //Método para seleccionar un libro en especifico por id
        public Libro seleccionar(int id)
        {
            var libro = libreria.Libros.Where(a => a.Id == id).FirstOrDefault();
            return libro;
        }
        //Método para seleccionar un libro en especifico por nombre
        public Libro seleccionarPorName(string title)
        {
            var libro = libreria.Libros.Where(a => a.Title.Equals(title)).FirstOrDefault();
            return libro;
        }

        //Método para insertar un libro a la bd
        public bool insertar(string title, int? chapters, int? pages, decimal? price, int? idAutor)
        {
            try
            {
                Libro libro = new Libro();
                libro.Title = title;
                libro.Chapters = chapters;
                libro.Pages = pages;
                libro.Price = price;
                libro.AuthorId = idAutor;

                libreria.Libros.Add(libro);
                libreria.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Método para actualizar los datos de un libro a la BD
        public bool actualizar(int id, string title, int? chapters, int? pages, decimal? price, int? idAutor)
        {
            try
            {
                //Seleccionamos al libro
                var libro = seleccionar(id);
                if (libro == null)
                {
                    return false;
                }
                else
                {

                    libro.Title = title;
                    libro.Chapters = chapters;
                    libro.Pages = pages;
                    libro.Price = price;
                    libro.AuthorId = idAutor;
                    libreria.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Método para eliminar a un libro de la BD con base a su id
        public bool eliminar(int id)
        {
            try
            {
                var libro = seleccionar(id);
                if (libro == null)
                {
                    return false;
                }
                else
                {
                    libreria.Libros.Remove(libro);
                    libreria.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
