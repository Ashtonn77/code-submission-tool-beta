using CodeSubmissionSimple.Server.Data;
using CodeSubmissionSimple.Server.IRepositories;
using CodeSubmissionSimple.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSubmissionSimple.Server.Repositories
{
    public class CandidateRepo : GenericRepository<Candidate>, ICandidateRepo
    {
        public CandidateRepo(ApplicationDbContext context)
          : base(context)
        {

        }

        public async Task<List<Candidate>> GetAllCandidatesWithID()
        {
            IQueryable<Candidate> query = _db;

            return await query.AsNoTracking().ToListAsync();
        }
    }
}
