using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRepositoryDemo.Model
{
    public class SellRecord
    {
        [Key]
        public int BookId { get; set; }

        public double Qty { get; set; }

        public DateTime date { get; set; }

    }
}
