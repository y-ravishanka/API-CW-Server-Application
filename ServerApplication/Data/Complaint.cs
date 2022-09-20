namespace ServerApplication.Data
{
    public class Complaint
    {
        public int id { get; set; }
        public string? nic { get; set; }
        public string? complaint { get; set; }
	    public string? reply { get; set; }
	    public int staffid { get; set; }
    }
}
