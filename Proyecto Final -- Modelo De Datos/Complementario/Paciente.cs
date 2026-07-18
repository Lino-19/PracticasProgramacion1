namespace RegistroPacientes
{
    internal class Paciente
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int Edad { get; set; }

        public string Sexo { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public Paciente()
        {

        }

        public Paciente(int id, string nombre, string apellido, int edad, string sexo, string telefono, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Sexo = sexo;
            Telefono = telefono;
            Direccion = direccion;
        }
    }
}