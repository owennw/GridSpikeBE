using ShoppingApp.Models;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.DTOs
{
    interface IEntityDTO
    {
        [Key]
        int Id { get; }
    }

    public class EntityDTO : IEntityDTO
    {
        public EntityDTO(IEntity entity)
        {
            this.Id = entity.Id;
        }

        [Key]
        public int Id { get; private set; }
    }
}