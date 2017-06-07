using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingApp.Repositories
{
    public static class UnitOfWorkFactory
    {
        private static IList<IUnitOfWork> existingUnitOfWorks = new List<IUnitOfWork>();

        public static IUnitOfWork Create()
        {
            var unitOfWork = new UnitOfWork();
            existingUnitOfWorks.Add(unitOfWork);

            return unitOfWork;
        }

        public static void Dispose()
        {
            foreach (var unitOfWork in existingUnitOfWorks)
            {
                unitOfWork.Dispose();
            }

            existingUnitOfWorks = new List<IUnitOfWork>(); 
        }
    }
}