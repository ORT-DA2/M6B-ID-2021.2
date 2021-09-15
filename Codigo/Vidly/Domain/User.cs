namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rol { get; set; }
        
        public bool HasPermission(string rol)
        {
            return rol == this.Rol;
        }
    }
}