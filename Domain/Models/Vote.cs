using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Vote
    {
        public Vote()
        {
            VotedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public string VoterId { get; set; }
        public int PollId { get; set; }
        public DateTime VotedAt { get; set; }
    }
}
