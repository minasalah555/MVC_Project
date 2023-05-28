using University.Controllers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
	[Table("Assistant")]
    public class Assistant
	{
		[Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
		public int assistant_id { get; set; }

        [Required(ErrorMessage = "you didnt entered your FName! ")]
        public string first_name { get; set; }


        [Required(ErrorMessage = "you didnt entered your LName! ")]
        public string last_name { get; set; }


        [Required(ErrorMessage = "you didnt entered your Age! ")]
        [Range(18, 80, ErrorMessage = "Please Enter a valid age -> 18:80!")]
        public int age { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9]+\.[a-zA-Z0-9.]+$",ErrorMessage = "The Email you entered is not valid! ]")]
        public string email { get; set; }


        [Required(ErrorMessage = "this field is required! ")]
        public string address { get; set; }


        [Required(ErrorMessage = "this field is required! ")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone number must be 11 digits.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be numeric.")]
        public String contact_number { get; set; }


        [Required(ErrorMessage = "this field is required! ")]
        [Display(Name = "Image")]
        [DefaultValue("default.png")]
        public string Assistant_Pic { get; set; }

        [Required(ErrorMessage = "this field is required! ")]
        [ForeignKey("Department")]
        public int department_id { get; set; }

        public virtual ICollection<assistant_course>? assistants_courses { get; set; }

        public virtual ICollection<assistant_proffessor>? assistants_proffessors { get; set; }
        public virtual ICollection<student_assistant>? students_assistants { get; set; }


        public virtual Departments? Department { get; set; }

    }
}
