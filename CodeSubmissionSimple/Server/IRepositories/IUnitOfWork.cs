using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSubmissionSimple.Shared;

namespace CodeSubmissionSimple.Server.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {

        ISubmissionRepository Submissions { get; }

        IGenericRepository<Question> Questions { get; }

        ICandidateRepo Candidates { get; }

        IGenericRepository<TestStatus> TestStatuses { get; }
        IGenericRepository<User> Users { get; }

        IGenericRepository<AppUser> AppUsers { get; }

        Task Save();

    }
}
