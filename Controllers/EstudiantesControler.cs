using Microsoft.AspNetCore.Mvc;
using Models;
using Aplication.Context;
using Microsoft.EntityFrameworkCore;

namespace Estudiantescontrollers{
    
    
    [ApiController]
    [Route("api")]
    public class EstudiantesController : ControllerBase
    {
        static DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        private readonly ApplicationDbContext? _dbContext=new ApplicationDbContext(optionsBuilder.Options);
        private static List<Estudiantes> estudiantes = new List<Estudiantes>();
        private Task existingEstudianteTask;

        [HttpGet("base")]
        public string baseGet(){
            return  "This is my <b>default</b> action..."; 
        }


        [HttpPost]
        [Route("GuardarEstudiantes")]
        public async Task<IActionResult> guardarEstudiante([FromBody] Estudiantes estudiante)
        {
            // Access the properties of the Estudiantes object
            int id = estudiante.Id;
            string nombre = estudiante.Nombre;
            string apellido = estudiante.Apellido;
            int idCurso = estudiante.IdCurso;
            Console.WriteLine("nombre");
            // Save the Estudiantes object to the database using Entity Framework Core
            _dbContext.Estudiantes.Add(estudiante);
            await _dbContext.SaveChangesAsync();

            return Ok("Estudiante guardado correctamente");
        }
        [HttpGet("{id}")]
        public ActionResult<Estudiantes> Get(int id)
        {
            var estudiante = _dbContext.Estudiantes.FirstOrDefault(e => e.Id == id);
            if (estudiante == null)
                return NotFound();
            
            return estudiante;
        }


        [HttpPut("put/{id}")]
        public async Task<IActionResult>  Put(int id,[FromBody] Estudiantes estudiante)
        {
            var existingEstudiante = await _dbContext.Estudiantes.FindAsync(id);
            if (existingEstudiante == null)
                return NotFound();
            
            existingEstudiante.Nombre = estudiante.Nombre;
            existingEstudiante.Apellido = estudiante.Apellido;
            existingEstudiante.IdCurso = estudiante.IdCurso;
            _dbContext.Estudiantes.Update(existingEstudiante);
            await  _dbContext.SaveChangesAsync();
            return Ok("Estudiante actualizado correctamente");
        }

        [HttpDelete]
        [Route("delete/{id}")] 
        public async Task<IActionResult> eliminarEstudiante(int id){
            var estudianteExistente = _dbContext.Estudiantes.FirstOrDefault(e => e.Id == id);
            if (estudianteExistente == null)
            {
                return NotFound("Estudiante no encontrado");
            }

            _dbContext.Estudiantes.Remove(estudianteExistente);
             await _dbContext.SaveChangesAsync();
            // Puedes retornar una respuesta HTTP exitosa (HTTP 200) o cualquier otro código de acuerdo a tus necesidades
            return Ok("Estudiante eliminado correctamente");
        }



    }
}
