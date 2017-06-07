using ShoppingApp.Models;
using ShoppingApp.Repositories;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.OData;

namespace ShoppingApp.Controllers
{
    public class GenericController<T> : ApiController
        where T : IEntity
    {
        private IUnitOfWork unitOfWork;

        public GenericController()
        {
            this.unitOfWork = new UnitOfWork();
        }

        [EnableQuery]
        public IQueryable<T> Get()
        {
            var repo = new Repository<T>(this.unitOfWork);
            return repo.GetAll();
        }

        public IHttpActionResult GetById(int id)
        {
            var repo = new Repository<T>(this.unitOfWork);

            var entity = repo.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [AcceptVerbs("POST", "PUT")]
        public IHttpActionResult Add(T entity)
        {
            try
            {
                var repo = new Repository<T>(this.unitOfWork);

                repo.Add(entity);

                return Ok(entity);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public IHttpActionResult Delete(T entity)
        {
            try
            {
                var repo = new Repository<T>(this.unitOfWork);

                repo.Delete(entity);

                return Ok(entity);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                this.unitOfWork.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}