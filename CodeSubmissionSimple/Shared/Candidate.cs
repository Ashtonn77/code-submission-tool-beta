using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSubmissionSimple.Shared
{
    public class Candidate : AppUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int SubmissionId { get; set; }
        public Submission Submission { get; set; }
    }
}
