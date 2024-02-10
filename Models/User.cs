namespace TinyUrlClone.Models
{
    public class User : BaseEntity
    {
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
