using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Technologies:Entity
    {
        public int ProgramingLanguageId { get; set; }
        public string Name { get; set; }
        public virtual ProgramingLanguage? ProgramingLanguage { get; set; }
        public Technologies()
        {

        }

        public Technologies(int id,int propramingLanguageId, string name)
        {
            Id = id;
            ProgramingLanguageId = propramingLanguageId;
            Name = name;
           
        }
    }
}
