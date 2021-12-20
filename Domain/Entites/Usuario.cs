namespace Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Idade { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
