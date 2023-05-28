using University.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class assistant_course
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "this field is required! ")]
        public int course_id { get; set; }
        [Required(ErrorMessage = "this field is required! ")]
        public int assistant_id { get; set; }
        


        public assistant_course? assistantCourse { get; set; }

        [ForeignKey("assistant_id")]

        public virtual Assistant? assistant { get; set; }

        [ForeignKey("course_id")]
        public virtual Course? course { get; set; }

    }
}
