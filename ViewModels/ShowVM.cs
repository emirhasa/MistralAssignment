using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public class ShowVM
    {
        public long ShowId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte[] ShowImage { get; set; }

        public decimal AverageRating { get; set; }
        public int NumberOfRatings { get; set; }

        public ICollection<ShowActorVM> Cast { get; set; }
    }
}
