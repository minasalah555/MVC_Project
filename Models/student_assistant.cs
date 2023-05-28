using University.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace University.Models
{
    [PrimaryKey(nameof(student_id), nameof(assistant_id))]
    public class student_assistant
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        [Required]
        public int student_id { get; set; }
        [Required]
        public int assistant_id { get; set; }


        public student_assistant? studentAssistant { get; set;}

        [ForeignKey("student_id")]
        public virtual Student? Student { get; set; }
        [ForeignKey("assistant_id")]

        public virtual Assistant? assistant { get; set; }

    }
}
