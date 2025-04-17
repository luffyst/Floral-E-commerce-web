namespace Project.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string f_name { get; set; }
        public string l_name { get; set; }
        public DateOnly dob { get; set; }
        public char gender { get; set; }
        public string p_no { get; set; }
        public String address { get; set; }
        public string email { get; set; }
        public String password { get; set; }

        public string? role { get; set; }

    }
}
