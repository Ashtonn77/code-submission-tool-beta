using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSubmissionSimple.Server.Models
{
    public class CandidateDto : AppUserDto
    {
        public CandidateDto(string email, string role, string passwordHash)
            : base(email, role, passwordHash)
        {
        }
        public string Name { get; set; }

        public string Surname { get; set; }

        public int SubmissionId { get; set; }
        public SubmissionDto Submission { get; set; }
    }
}
