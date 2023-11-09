namespace AccesoDatos
{
    public  class Parametro
    {
        public string Nombre { get; set; }
        public object Valor { get; set; }

        public Parametro(String Nombre, object Valor)
        {
            this.Nombre = Nombre;
            this.Valor = Valor;
        }

    }
}
