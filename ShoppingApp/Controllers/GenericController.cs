using Ninject.Modules;
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

        private Repository<T> repository;

        public GenericController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = new Repository<T>(unitOfWork);
        }

        [EnableQuery]
        public IQueryable<T> Get()
        {
            return this.repository.GetAll();
        }

        public IHttpActionResult GetById(int id)
        {
            var entity = this.repository.GetById(id);
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
                this.repository.Add(entity);

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
                this.repository.Delete(entity);

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