using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker
{
    public class JobApp
    {
        public int id { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string Location { get; set; }
        public string Link { get; set; }

        public string FullInfo
        {
            get
            {
                // Format for displaying job app info that is searched for by the user
                return $"{ Company } / { Position } / { Location } ({ Link })";
            }
        }
    }
}
