using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;

namespace ButtonManufacture.Models
{
    public class Button
    {
        public int Id { get; set; }
        public string Type { get; set; }

        [DataType(DataType.Date)]
        public DateTime ManufacturingDate { get; set; }
        public string color { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int Review { get; set; }

    }
}
