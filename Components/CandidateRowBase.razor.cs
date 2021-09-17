using CodeSubmissionSimple.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    public class CandidateRowBase : ComponentBase
    {
        [Parameter]
        public Candidate Candidate { get; set; }

        public bool Toggle { get; set; } = false;
    }
}
