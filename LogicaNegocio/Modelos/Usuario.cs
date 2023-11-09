namespace LogicaNegocio.Modelos
{
    public class Usuario
    {
        public long Nuip { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contrasenia  { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public Genero Genero { get; set; }
        public Documento Documento { get; set; }
        public Ciudad Ciudad { get; set; }
        public Rol Rol { get; set; }

        
    }
}
