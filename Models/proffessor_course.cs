using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace University.Models
{
    [PrimaryKey(nameof(professor_id), nameof(course_id))]
    public class proffessor_course
    {
            [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        [Required]
        public int professor_id { get; set; }
        [Required]
        public int course_id { get; set; }


            public virtual proffessor_course? proffessorCourse { get; set; }
      
        [ForeignKey("course_id")]
        public virtual Course? course { get; set; }
    
        [ForeignKey("professor_id")]
        public virtual proffessor? Proffessor { get; set; }
        }
}
