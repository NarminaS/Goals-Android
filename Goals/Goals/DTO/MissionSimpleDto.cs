namespace Goals.DTO
{
    public class MissionSimpleDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Progress { get; set; }

        public float ProgressNum
        {
            get { return Progress / 100; }
        }
    }
}
