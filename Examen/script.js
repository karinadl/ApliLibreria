// Elaborado por: De León Fuentes Karina Guadalupe
// Petición (fetch) de los datos.
document.addEventListener('DOMContentLoaded', function () {
    const apiUrlLibros = 'http://localhost:5216/api/Libro/libros';
    const apiUrlAutores = 'http://localhost:5216/api/Autor/autores'; 

    const tablaLibros = document.getElementById('tabla-libros');
    const inputBusqueda = document.getElementById('busqueda');
    const btnBuscar = document.getElementById('btnBuscar');

    let autoresMap = {}; // Mapa para almacenar los nombres de los autores por su ID

    // Obtener la lista de autores
    fetch(apiUrlAutores)
        .then(response => response.json())
        .then(autores => {
            // Crear un mapa para acceder fácilmente a los nombres de los autores por ID
            autores.forEach(autor => {
                autoresMap[autor.id] = autor.name;
            });

            // Obtener la lista de libros
            return fetch(apiUrlLibros);
        })
        .then(response => {
            if (!response.ok) {
                throw new Error(`Error de red: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            mostrarListaLibros(data);
            // Agregar evento para el campo de búsqueda
            btnBuscar.addEventListener('click', function () {
                // Limpiar la tabla antes de mostrar los resultados de la búsqueda
                limpiarTabla(tablaLibros);

                const terminoBusqueda = inputBusqueda.value.toLowerCase();
                const librosFiltrados = data.filter(libro =>
                    libro.title.toLowerCase().includes(terminoBusqueda)
                );
                mostrarListaLibros(librosFiltrados, tablaLibros);
            });
        })
        .catch(error => {
            console.error('Error al obtener datos:', error);
        });

    function mostrarListaLibros(libros) {
        if (libros.length === 0) {
            tablaLibros.innerHTML = '<p>No hay libros disponibles.</p>';
            return;
        }

        // Crear la fila de encabezados
        const encabezadosRow = document.createElement('tr');
        ['Title', 'Chapters', 'Pages', 'Price', 'AuthorName'].forEach(columna => {
            const th = document.createElement('th');
            th.textContent = columna;
            encabezadosRow.appendChild(th);
        });
        tablaLibros.appendChild(encabezadosRow);

        // Crear filas para cada libro
        libros.forEach(libro => {
            const libroRow = document.createElement('tr');
            ['title', 'chapters', 'pages', 'price', 'authorId'].forEach(columna => {
                const td = document.createElement('td');
                td.textContent = columna === 'authorId' ? autoresMap[libro[columna]] : libro[columna];
                if (columna === 'title') {
                    td.classList.add('columna-title');
                }
                libroRow.appendChild(td);
            });
            tablaLibros.appendChild(libroRow);
        });
    }

    function limpiarTabla(tabla) {
        // Limpiar la tabla eliminando todas las filas
        while (tabla.firstChild) {
            tabla.removeChild(tabla.firstChild);
        }
    }
});
