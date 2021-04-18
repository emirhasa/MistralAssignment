using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistralAssignment.Database
{
    public class ShowActor
    {
        public long ShowId { get; set; }
        public Show Show { get; set; }
        public long ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
