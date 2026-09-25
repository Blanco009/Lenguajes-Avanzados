namespace EntityFrameworkClase3.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool isActive { get; set; } = true;
    }
}