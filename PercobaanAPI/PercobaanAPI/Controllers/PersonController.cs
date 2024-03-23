using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PercobaanAPI.Models;
using System;

namespace PercobaanAPI.Controllers
{
    public class PersonControllers : Controller
    {
        private string __constr;
        public PersonControllers(IConfiguration configuration)
        {
            __constr = configuration.GetConnectionString("WebApiDataBase");
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("api/person")]
        public ActionResult<Person> ListPerson()
        {
            PersonContext context = new PersonContext(this.__constr);
            List<Person> ListPerson = context.ListPerson();
            return Ok(ListPerson);
        }

        [HttpPost("api/person")]
        public ActionResult<Person> CreatePerson(Person person)
        {
            PersonContext context = new PersonContext(this.__constr);
            bool success = context.CreatePerson(person);
            if (success)
            {
                return Ok("Person created successfully");
            }
            else
            {
                return BadRequest("Failed to create person");
            }
        }
        [HttpPut("api/person/{id}")]
        public ActionResult<Person> UpdatePerson(int id, Person updatedPerson)
        {
            PersonContext context = new PersonContext(this.__constr);
            bool success = context.UpdatePerson(id, updatedPerson);
            if (success)
            {
                return Ok("Person updated successfully");
            }
            else
            {
                return NotFound("Person not found");
            }
        }
        [HttpDelete("api/person/{id}")]
        public ActionResult<Person> DeletePerson(int id)
        {
            PersonContext context = new PersonContext(this.__constr);
            bool success = context.DeletePerson(id);
            if (success)
            {
                return Ok("Person deleted succesfully");
            }
            else
            {
                return NotFound("Person not found");
            }
        }
    }
}