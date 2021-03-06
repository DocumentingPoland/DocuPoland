using System;

namespace API.Entities
{
    public class Submission
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Links { get; set; }
        public DateTime EventDate { get; set; }
        public string City { get; set; }

        public string State { get; set; }

        public bool Confirmed { get; set; }


    }
}