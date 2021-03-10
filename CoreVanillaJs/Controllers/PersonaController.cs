using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreVanillaJs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        // GET api/values
        /// <summary>
        /// Metodo que consulta todos los datos de la base de datos
        /// </summary>
        /// <returns>
        /// La lista de los datos de la bbdd
        /// </returns>
        [HttpGet]
        public ActionResult Get()
        {
            using (Models.CrudVanelaContext db = new Models.CrudVanelaContext())
            {
                var lst = (from d in db.Persona select d).ToList();
                return Ok(lst);
            }
            // return new string[] { "value1", "value2" };
        }
        /// <summary>
        /// Metodo que crea datos en la base de datos 
        /// </summary>
        /// <param name="model"></param> en la carpeta Models Persona 
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] Models.Persona model)
        {
            using (Models.CrudVanelaContext db = new Models.CrudVanelaContext())
            {
                Models.Persona oPersona = new Models.Persona();
                oPersona.Nombre = model.Nombre;
                oPersona.Edad = model.Edad;
                db.Persona.Add(oPersona);
                db.SaveChanges();
            }
            return Ok();
        }
        
    }
}
