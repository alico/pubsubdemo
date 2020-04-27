using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PubSubDemo.EventProcessor.Data.Entity
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime LastModifyDate { get; set; }

    }
}
