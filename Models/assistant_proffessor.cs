using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class assistant_proffessor
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        [Required]
        public int professor_id { get; set; }
        [Required]
        public int assistant_id { get; set; }
       

      
        public virtual assistant_proffessor? assistantProffessor { get; set; }
        
        
        [ForeignKey("assistant_id")]
        public virtual Assistant? assistant { get; set; }


        [ForeignKey("professor_id")]
        public virtual proffessor? Proffessor { get; set; }

    }
}
