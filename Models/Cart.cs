namespace University.Models
{
    public class Cart
    {


        public int CartId { get; set; }

        public int student_id { get; set; }
        public Student? Student { get; set; }

        public List<CartItem> Items { get; set; }
    }
}
