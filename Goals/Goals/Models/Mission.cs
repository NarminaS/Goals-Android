using System;
using System.Collections.Generic;
using System.Text;

namespace Goals.Models
{
    class Mission
    {
        public Mission()
        {
            Tasks = new List<Task>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Added { get; set; } = DateTime.Now;

        public DateTime? Deadline { get; set; }

        public string Description { get; set; }

        public decimal TotalSum { get; set; }

        public List<Task> Tasks { get; set; }   
    }
}
