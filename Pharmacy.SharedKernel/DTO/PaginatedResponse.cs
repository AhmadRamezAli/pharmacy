namespace Pharmacy.SharedKernel.DTO;

public class PaginatedResponse<T>
{
    public int Count { get; set; }
    public List<T> PayLoad { get; set; } = new List<T>();
}
