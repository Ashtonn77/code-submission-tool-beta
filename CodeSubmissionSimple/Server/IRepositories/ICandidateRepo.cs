using CodeSubmissionSimple.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CodeSubmissionSimple.Server.IRepositories
{
    public interface ICandidateRepo   : IGenericRepository<Candidate>
    {
        public Task<List<Candidate>> GetAllCandidatesWithID();
    }
}
