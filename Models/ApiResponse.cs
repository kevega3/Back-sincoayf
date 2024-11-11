namespace Back_sincoayf.Models
{
    public class ApiResponse<T>
    {
            public bool Error { get; set; }
            public  string Ayuda { get; set; }
            public T Data { get; set; } 
    }
}
