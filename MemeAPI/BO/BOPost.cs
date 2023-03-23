using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeAPI.BO
{
    public class BOPost
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Image { get; set; }

        public int AutherId { get; set; }

        public int Upvotes { get; set; }

        public List<BOComment> Comments { get; set; }
    }
}
