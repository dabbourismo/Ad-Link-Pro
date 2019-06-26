namespace DataLibrary.Models
{
    public interface IServicesModel
    {
        int Id { get; set; }
        string ServiceName { get; set; }
        float ServicePrice { get; set; }
        int ServiceTime { get; set; }
        string ServiceType { get; set; }
    }
}