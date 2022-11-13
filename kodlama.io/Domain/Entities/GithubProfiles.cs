using Core.Persistence.Repositories;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GithubProfile:Entity
    {
        public int UserId { get; set; }
        public string GithubUrl { get; set; }
        public virtual User? user { get; set; }
        public GithubProfile()
        {

        }

        public GithubProfile(int id,int userId, string githubUrl)
        {
            Id = id;
            UserId = userId;
            GithubUrl = githubUrl;
        }
    }
}
