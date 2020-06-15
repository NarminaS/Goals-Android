using System;

namespace Goals.DTO
{
    class MissionCreateDto
    {
        public string Name { get; set; }

        public DateTime? Deadline { get; set; }

        public string Description { get; set; }

        public decimal TotalSum { get; set; }
    }
}
