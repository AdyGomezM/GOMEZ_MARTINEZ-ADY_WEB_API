using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    // Esta es una clase genérica llamada "Response" que nos sirve para enviar respuestas estándar en nuestra aplicación.
    // La <T> significa que esta clase puede trabajar con cualquier tipo de dato (puede ser un usuario, una lista, un mensaje, etc.).
    public class Response<T>
    {
        // Constructor vacío. Este se ejecuta cuando se crea una respuesta sin datos específicos.
        public Response() { }

        // Constructor que recibe un dato (data) y un mensaje opcional.
        // Cuando se llama a este constructor, se asume que la operación fue exitosa.
        public Response(T data, string message = null)
        {
            Succeded = true;      // Indicamos que la respuesta fue exitosa.
            Message = message;    // Guardamos el mensaje recibido (puede ser nulo).
            Result = data;        // Guardamos el resultado que queremos devolver.
        }

        // Constructor que solo recibe un mensaje. Esto se usa cuando hubo un error o no hay datos que devolver.
        public Response(string message)
        {
            Succeded = false;     // Indicamos que la operación no fue exitosa.
            Message = message;    // Guardamos el mensaje de error o explicación.
        }

        // Propiedad booleana que indica si la respuesta fue exitosa (true) o fallida (false).
        public bool Succeded { get; set; }

        // Aquí se guarda un mensaje, que puede ser un mensaje de éxito, advertencia o error.
        public string Message { get; set; }

        // Aquí se guarda el dato o resultado que queremos devolver (de tipo T, que puede ser cualquier tipo).
        public T Result { get; set; }
    }
}