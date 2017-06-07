using Ninject.Modules;
using ShoppingApp.DTOs;
using ShoppingApp.Models;
using ShoppingApp.Repositories;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.OData;

namespace ShoppingApp.Controllers
{
    public class GenericController<T, TDTO> : ApiController
        where T : IEntity
        where TDTO : IEntityDTO
    {
        private IUnitOfWork unitOfWork;

        private Repository<T> repository;

        private Func<T, TDTO> convertToDTO;

        public GenericController(IUnitOfWork unitOfWork, Func<T, TDTO> convertToDTO)
        {
            this.unitOfWork = unitOfWork;
            this.repository = new Repository<T>(unitOfWork);
            this.convertToDTO = convertToDTO;
        }

        [EnableQuery]
        public IQueryable<TDTO> Get()
        {
            return this.repository.GetAll().Select(e => convertToDTO(e));
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