using University.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace University.Models
{

    [PrimaryKey(nameof(student_id), nameof(professor_id))]
    public class student_proffessor
    {


        // [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        // public int student_professor_id { get; set; }

        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        [Required]
        public int student_id { get; set; }
        [Required]
        public int professor_id { get; set; }


        public virtual student_proffessor? studentProffessor { get; set; }


        [ForeignKey("student_id")]
        public virtual Student? student { get; set; }

        [ForeignKey("professor_id")]
        public virtual proffessor? professor { get; set; }
    }
}
