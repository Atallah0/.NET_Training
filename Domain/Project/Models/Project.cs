namespace Domain.Project.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Management { get; set; }
        public string? Sponsor { get; set; }
        public string? Manager { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
        public string? TeamName { get; set; }
        public string? TeamLocation { get; set; }
        public string? TeamLead { get; set; }
    }
}
