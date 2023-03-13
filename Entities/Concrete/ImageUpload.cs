using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class ImageUpload:IEntity
    {
        [Key]
        [Column(TypeName = "bigint")]
        public string Id { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string ImagePath { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime InsertedOn { get; set; }
    }
}
