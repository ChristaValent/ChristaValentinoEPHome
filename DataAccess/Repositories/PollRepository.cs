using DataAccess.DataContext;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PollRepository
    {
        private PollDbContext _pollContext;

        public PollRepository(PollDbContext pollContext)
        {
            _pollContext = pollContext;
        }

        public void CreatePoll(Poll poll)
        {
            poll.CreatedAt = DateTime.Now;
            _pollContext.Polls.Add(poll);
            _pollContext.SaveChanges();
        }

        public Poll? GetPoll(int id)
        {
            return _pollContext.Polls.FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<Poll> GetPolls()
        {
            return _pollContext.Polls;
        }

    }
}
