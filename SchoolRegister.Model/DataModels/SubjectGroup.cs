using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Model.DataModels
{
    public class SubjectGroup
    {
        [Key]
        public int Id { get; set; } 
        
        [ForeignKey("GroupId")]
        public virtual Group? Group { get; set; }

        public int GroupId { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject? Subject { get; set; }

        public int SubjectId { get; set; }
    }
}