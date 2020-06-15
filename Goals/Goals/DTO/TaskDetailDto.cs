using System;
using System.Collections.Generic;
using System.Text;

namespace Goals.DTO
{
    class TaskDetailDto 
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool Done { get; set; }  
    }
}
