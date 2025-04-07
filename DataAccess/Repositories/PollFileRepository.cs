using Domain.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PollFileRepository : IPollRepository
    {
        private string _filename;
        public PollFileRepository(IConfiguration configuration)
        {
            // Retrieve the filename from appsettings.json
            _filename = configuration["PollsFileName"];
            if (string.IsNullOrEmpty(_filename))
            {
                throw new ArgumentException("Poll file path is not configured in appsettings.json.");
            }

            // Ensure the file exists
            if (!System.IO.File.Exists(_filename))
            {
                System.IO.File.Create(_filename).Close();
            }

        }

        public void CreatePoll(Poll poll)
        {
            var listOfExistentPolls = GetPolls().ToList();

            var lastPollId = listOfExistentPolls.Count > 0 ? listOfExistentPolls.Max(p => p.Id) : 0;

            poll.Id = lastPollId + 1;

            listOfExistentPolls.Add(poll);

            System.IO.File.WriteAllText(_filename, JsonConvert.SerializeObject(listOfExistentPolls));
        }

        public IQueryable<Poll> GetPolls() 
        {
            if(System.IO.File.Exists(_filename) == false)
            {
                return new List<Poll>().AsQueryable();
            }

            var json = System.IO.File.ReadAllText(_filename);

            var polls = JsonConvert.DeserializeObject<List<Poll>>(json);

            return polls.AsQueryable();
        }
    }
}
