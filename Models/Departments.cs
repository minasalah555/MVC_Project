using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    [Table("department")]
    public class Departments
    {
      /*  public enum DepartmentNameEnum
        {
            CS, IT, IS, MM, SE, AI
        }*/

        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public string description { get; set; }


        [Required(ErrorMessage = "This field is required!")]
        public string department_name { get; set; }


        [Required(ErrorMessage = "This field is required!")]
        [Display(Name = "Image")]
        [DefaultValue("default.png")]
        public string department_Pic { get; set; }

       
        public virtual ICollection<Assistant>? assistants { get; set; }
        public virtual ICollection<Course>? courses { get; set; }
        public virtual ICollection<Student>? students { get; set; }
        public virtual ICollection<proffessor>? proffessors { get; set; }

       //public DepartmentNameEnum department_name { get; set; }

        /*public string DepartmentNameString
        {
            get { return department_name.ToString(); }
        }*/
    }
}
