using DataAccess.DataContext;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PollRepository : IPollRepository
    {
        private PollDbContext _pollContext;

        public PollRepository(PollDbContext pollContext)
        {
            _pollContext = pollContext;
        }

        public void CreatePoll(Poll poll)
        {
            poll.DateCreated = DateTime.Now;
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

        public bool Vote(int pollId, int option)
        {
            var poll = GetPoll(pollId);

            if (poll != null)
            {
                switch (option)
                {
                    case 1:
                        poll.Option1VotesCount++;
                        break;
                    case 2:
                        poll.Option2VotesCount++;
                        break;
                    case 3:
                        poll.Option3VotesCount++;
                        break;
                }
                _pollContext.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
