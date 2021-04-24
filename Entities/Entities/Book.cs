﻿using Core.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class Book : RecordBase
    {

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public double UnitPrice { get; set; }

        public int StockAmount { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
