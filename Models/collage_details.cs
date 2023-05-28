using Microsoft.EntityFrameworkCore;

namespace University.Models
{
	public class collage_details
	{
		public List<Student>? students { get; set; }
		public List<Departments>?	 departments { get; set; }
		public List<Assistant>? Assistant { get; set; }
		public List<proffessor>? proffessor { get; set; }
		public List<Course>? Course { get; set; }
	}
}
