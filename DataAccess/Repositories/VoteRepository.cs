using DataAccess.DataContext;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class VoteRepository
    {
        public PollDbContext _pollContext;

        public VoteRepository(PollDbContext pollContext)
        {
            _pollContext = pollContext;
        }

        public void CreateVote(Vote vote)
        {
            _pollContext.Votes.Add(vote);
            _pollContext.SaveChanges();
        }

        public bool HasVoted(string voterId, int pollId)
        {
            return _pollContext.Votes.Any(v => v.VoterId == voterId && v.PollId == pollId);
        }
    }
}
