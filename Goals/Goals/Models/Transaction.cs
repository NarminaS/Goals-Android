using System;
using System.Collections.Generic;
using System.Text;

namespace Goals.Models
{
    class Transaction
    {
        public int Id { get; set; }

        public int TaskId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
