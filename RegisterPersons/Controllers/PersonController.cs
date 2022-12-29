using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RegisterPersons.Models;
using RegisterPersons.Rules.Contracts;
using RegisterPersons.Util;
using RegisterPersons.Util.Request;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace RegisterPersons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IValidator<PersonRequest> PersonValidator;
        private readonly Lazy<IPersonService> LazyPersonService;
        private IPersonService PersonService => LazyPersonService.Value;

        public PersonController(IValidator<PersonRequest> personValidator,Lazy<IPersonService> lazyPersonService)
        {
            this.PersonValidator= personValidator;
            this.LazyPersonService= lazyPersonService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets all persons", Description = "Gets all persons")]
        [SwaggerResponse(200, Description = "Person list", Type = typeof(ICollection<Person>))]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.PersonService.GetAll());
            }
            catch (Exception ex)
            {
                return Helper.GetExectionResponse(ex);
            }
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a person by id", Description = "Gets a person by id")]
        [SwaggerResponse(200, Description = "Person information", Type = typeof(Person))]
        public IActionResult Get(string id)
        {
            try
            {
                return Ok(this.PersonService.GetById(id));
            }
            catch (Exception ex)
            {
                return Helper.GetExectionResponse(ex);
            }
        }

        // POST api/<PersonController>
        [HttpPost]
        [SwaggerOperation(Summary = "Create a person", Description = "Create a person")]
        [SwaggerResponse(200, Description = "Person created", Type = typeof(Person))]
        public IActionResult Post([FromBody] PersonRequest personRequest)
        {
            try
            {
                Helper.CheckValidation(PersonValidator.Validate(personRequest));
                return Ok(this.PersonService.Create(personRequest));
            }
            catch (Exception ex)
            {
                return Helper.GetExectionResponse(ex);
            }
        }
    }
}
