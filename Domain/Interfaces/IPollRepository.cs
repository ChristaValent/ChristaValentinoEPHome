using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IPollRepository
    {
        public void CreatePoll(Poll poll);
        public IQueryable<Poll> GetPolls();
    }
}
