using University.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace University.Models
    {
 
   
    [Table("Course")]
	public class Course
	{
		[Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int course_id { get; set; }


        [Required(ErrorMessage = "this field is required! ")]
        public string course_name { get; set; }


        [Required(ErrorMessage = "this field is required! ")]
        public String course_code { get; set; }


        [Required(ErrorMessage = "this field is required! ")]
        public int semester { get; set; }



       //[Required(ErrorMessage = "this field is required! ")]
       //public string? grade { get; set; }


  
       [Required(ErrorMessage = "this field is required! ")]
        [Range(1, 4, ErrorMessage = "Please Enter a valid number -> 1:4!")]
        public int course_credits { get; set; }



        //[Required(ErrorMessage = "this field is required! ")]
       // [Range(0, 4, ErrorMessage = "Please Enter a valid GPA -> 0:4!")]
        //public double? gpa { get; set; }



        [Required(ErrorMessage = "this field is required! ")]
        public String course_description { get; set; }


        [Required(ErrorMessage = "this field is required! ")]
        public String Instructor { get; set; }


        [ForeignKey("Department")]
        [Required(ErrorMessage = "this field is required! ")]
        public int department_id { get; set; }


        [Required(ErrorMessage = "this field is required! ")]
        [Display(Name = "Image")]
        [DefaultValue("default.png")]
        public string Course_Pic { get; set; }

        public virtual ICollection<assistant_course>? assistants_courses { get; set; }
        public virtual ICollection<proffessor_course>? proffessors_courses { get; set; }
        public virtual ICollection<student_course>? students_courses { get; set; }

        public virtual Departments? Department { get; set; }
    }
}
