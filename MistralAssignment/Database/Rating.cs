using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistralAssignment.Database
{
    public class Rating
    {
        public long RatingId { get; set; }

        //number from 1 to 5
        public byte Grade { get; set; }

        public long ShowId { get; set; }
        public Show Show { get; set; }
    }
}
