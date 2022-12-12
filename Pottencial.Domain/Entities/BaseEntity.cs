using System;
using System.ComponentModel.DataAnnotations;

namespace Pottencial.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateEntity { get; set; }
        public DateTime UpdateEntity { get; set; }
        public DateTime DeleteEntity { get; set; }

        public void GenerateDateCreate()
            => this.CreateEntity = DateTime.Now;

        public void GenerateDateUpdate()
            => this.UpdateEntity = DateTime.Now;

        public void GenerateDateDelete()
            => this.DeleteEntity = DateTime.Now;
    }
}