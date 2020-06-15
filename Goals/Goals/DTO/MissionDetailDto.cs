using System;
using System.Collections.Generic;

namespace Goals.DTO
{
    class MissionDetailDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? Deadline { get; set; }

        public string Description { get; set; }

        public decimal TotalSum { get; set; }

        public decimal TotalTransactions { get; set; }

        public float Progress { get; set; }

        public float ProgressNum
        {
            get { return Progress / 100; }
        }

        public List<TaskDetailDto> Tasks { get; set; }
    }
}
