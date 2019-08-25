using CRUD.Models.EntityModel;
using CRUD.Models.EntityModel.Persons;
using CRUD.Models.ServiceModel;
using CRUD.Models.ViewModel.Persons;
using CRUD.Results.Persons;
using Net451.Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace CRUD.Controllers
{
    [RoutePrefix("api/v1/crud")]
    public class PersonsController : ApiController
    {

        public PersonsController() { }

        [HttpGet, Route("")]
        public async Task<ActionResult> List(ListPersonsModel model)
        {
            using (ApiDbContext dbContext = new ApiDbContext())
            {
                var query = dbContext.Persons
                    .WhereTaxDocument(model.TaxDocument);

                var persons = await query
                    .OrderByName()
                    .Skip(model.Index.Value)
                    .Take(model.Length.Value)
                    .ToListAsync();

                var count = query.LongCount();

                return new PersonListJson(persons, count);
            }
        }

        [HttpPost, Route("")]
        public async Task<ActionResult> Create([FromBody] PersonModel model)
        {
            PersonManagement personManagement = new PersonManagement();

            if (!await personManagement.Create(model.Map()))
            {
                return new PersonErrorJson(personManagement);
            }

            return new PersonJson(personManagement.Person);
        }

        [HttpPut, Route("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody]UpdatePersonModel model)
        {
            PersonManagement personManagement = new PersonManagement();
            await personManagement.Find(id);
            model.Map(personManagement.Person);

            if (!await personManagement.Update())
            {
                return new PersonErrorJson(personManagement);
            }

            return new HttpStatusCodeResult(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            PersonManagement personManagement = new PersonManagement();

            await personManagement.Find(id);
            if (!await personManagement.Delete())
            {
                return new PersonErrorJson(personManagement);
            }

            return new HttpStatusCodeResult(HttpStatusCode.NoContent);
        }
    }
}