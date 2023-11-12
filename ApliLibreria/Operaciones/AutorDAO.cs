using AccesoDatos.Context;
using AccesoDatos.Models;

namespace AccesoDatos.Operaciones
{
    public class AutorDAO
    {

        //Creamos un objeto de contexto de BD
        public LibreriaContext libreria = new LibreriaContext();
        //Método para seleccionar a todos los autores
        public List<Autor> seleccionarTodos()
        {
            var autores = libreria.Autors.ToList<Autor>();
            return autores;
        }
        //Método para seleccionar un autor en especifico por id
        public Autor seleccionar(int id)
        {
            var autor = libreria.Autors.Where(a => a.Id == id).FirstOrDefault();
            return autor;
        }
        //Método para seleccionar un autor en especifico por nombre
        public Autor seleccionarPorName(string name)
        {
            var autor = libreria.Autors.Where(a => a.Name.Equals(name)).FirstOrDefault();
            return autor;
        }

        //Método para insertar un autor a la BD
        public bool insertar(string name)
        {
            try
            {
                Autor autor = new Autor();
                autor.Name = name;

                libreria.Autors.Add(autor);
                libreria.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //Método para actuaizar los datos de un autor a la BD
        public bool actualizar(int id, string name)
        {
            try
            {
                //Seleccionamos al autor
                var autor = seleccionar(id);
                if (autor == null)
                {
                    return false;
                }
                else
                {

                    autor.Name = name;
                    libreria.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Método para eliminar a un autor de la BD con base a su id
        public bool eliminar(int id)
        {
            try
            {
                var autor = seleccionar(id);
                if (autor == null)
                {
                    return false;
                }
                else
                {
                    libreria.Autors.Remove(autor);
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
