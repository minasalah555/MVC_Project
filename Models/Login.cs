using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace University.Models
{
    public class Login
    {

        [DefaultValue(0)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "please Enter your Email..!")]
        [EmailAddress(ErrorMessage = "please Enter a valid Email..!")]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "please enter your password..!")]
        [DataType(DataType.Password)]
       // [StringLength(50, MinimumLength = 8, ErrorMessage = "")]
        public string Password { get; set; }



    }
}

