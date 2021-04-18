using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistralAssignment.Database
{
    public class Actor
    {
        public Actor()
        {
            ActorShows = new HashSet<ShowActor>();
        }
        public long ActorId { get; set; }
        public string Name { get; set; }

        public ICollection<ShowActor> ActorShows { get; set; }
    }
}
