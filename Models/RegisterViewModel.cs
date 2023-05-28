using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace University.Models
{
    public class RegisterViewModel
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        
        [Required(ErrorMessage ="This field is required..!")]
        public string firstName { get; set; }
       
        
        [Required(ErrorMessage = "This field is required..!")]
        public string lastName { get; set; }
       
        
        [Required(ErrorMessage = "This field is required..!")]
        [EmailAddress]
        public string Email { get; set; }
       
        
        [Required(ErrorMessage = "This field is required..!")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "The password must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
        
        [Required(ErrorMessage = "This field is required..!")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="password not match..! ")]
        public string ConfirmPassword { get; set; }
    }
}
