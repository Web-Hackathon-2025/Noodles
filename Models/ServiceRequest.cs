public class ServiceRequest {
    public int Id { get; set; }
    public string CustomerId { get; set; }
    public int ProviderId { get; set; }
    public string ServiceDescription { get; set; }
    public DateTime RequestedDate { get; set; } = DateTime.Now;
    public string Status { get; set; } = "Pending"; // Pending, Confirmed, Completed, Cancelled
    public virtual ServiceProviderProfile Provider { get; set; }
    public virtual ApplicationUser Customer { get; set; }
}
