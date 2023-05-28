using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace University.Models
{


    [PrimaryKey(nameof(student_id),nameof(course_id))]
    public class student_course
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        [Required]
        public int student_id { get; set; }
        [Required]
        public int course_id { get; set; }

        public string grade { get; set; } = string.Empty;

        public virtual student_course? studentsCourse { get; set; }

        [ForeignKey("course_id")]
        public virtual Course? course { get; set; }

        [ForeignKey("student_id")]
        public virtual Student? Student { get; set; }

    }
}

