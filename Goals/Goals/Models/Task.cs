using System;
using System.Collections.Generic;
using System.Text;

namespace Goals.Models
{
    class Task
    {
        public int Id { get; set; }

        public int MissionId { get; set; }

        public string Text { get; set; }

        public bool Done { get; set; }
    }
}
