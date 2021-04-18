using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistralAssignment.Database
{
    public class Show
    {
        public Show()
        {
            Cast = new HashSet<ShowActor>();
            Ratings = new HashSet<Rating>();
        }

        public long ShowId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte[] ShowImage { get; set; }

        public short ShowTypeId { get; set; }
        public ShowType ShowType { get; set; }

        public decimal AverageRating { get; set; }
        public int NumberOfRatings { get; set; }

        public ICollection<ShowActor> Cast { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
