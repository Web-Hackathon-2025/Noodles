public class Review {
    public int Id { get; set; }
    public int ProviderId { get; set; }
    public string CustomerName { get; set; }
    public int Rating { get; set; } // 1-5
    public string Comment { get; set; }
}
