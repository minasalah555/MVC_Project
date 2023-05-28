using University.Controllers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    [Table("proffessor")]
    public class proffessor
	{
		[Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int doctor_id { get; set; }


        [Required(ErrorMessage = "this field is required! ")]
        public string first_name { get; set; }


        [Required(ErrorMessage = "this field is required! ")]
        public string last_name { get; set; }

        

        [Required(ErrorMessage = "you didnt entered your Age! ")]
        [Range(18, 80, ErrorMessage = "Please Enter a valid age -> 18:80!")]
        public int age { get; set; }


        [Required(ErrorMessage = "this field is required! ")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9]+\.[a-zA-Z0-9.]+$", ErrorMessage = "The Email you entered is not valid! ]")]
        public string email { get; set; }


        [Required(ErrorMessage = "this field is required! ")]
        public string address { get; set; }


        [Required(ErrorMessage = "this field is required! ")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone number must be 11 digits.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be numeric.")]
        public string contact_number { get; set; }



        [Required(ErrorMessage = "this field is required! ")]
        [Display(Name = "Image")]
        [DefaultValue("default.png")]
        public string doctor_Pic { get; set; }


        [ForeignKey("Department")]
        [Required(ErrorMessage = "this field is required! ")]
        public int department_id { get; set; }

        public virtual ICollection<student_proffessor>? student_proffessors { get; set; }
        public virtual ICollection<proffessor_course>? proffessor_courses { get; set; }
        public virtual ICollection<assistant_proffessor>? assistant_proffessors { get; set; }
        public virtual Departments? Department { get; set; }
    }
}
