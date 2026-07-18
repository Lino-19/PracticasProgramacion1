using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RegistroPacientes
{
    internal class PacienteDAO
    {
        Conexion conexion = new Conexion();

        // Registrar paciente
        public void RegistrarPaciente(Paciente paciente)
        {
            try
            {
                SqlConnection con = conexion.Conectar();
                con.Open();

                string sql = "INSERT INTO Pacientes(Nombre,Apellido,Edad,Sexo,Telefono,Direccion) VALUES(@Nombre,@Apellido,@Edad,@Sexo,@Telefono,@Direccion)";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", paciente.Apellido);
                cmd.Parameters.AddWithValue("@Edad", paciente.Edad);
                cmd.Parameters.AddWithValue("@Sexo", paciente.Sexo);
                cmd.Parameters.AddWithValue("@Telefono", paciente.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", paciente.Direccion);

                cmd.ExecuteNonQuery();

                con.Close();

                Console.WriteLine("Paciente registrado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Buscar paciente
        public void BuscarPaciente(int id)
        {
            try
            {
                SqlConnection con = conexion.Conectar();
                con.Open();

                string sql = "SELECT * FROM Pacientes WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader leer = cmd.ExecuteReader();

                if (leer.Read())
                {
                    Console.WriteLine("Id: " + leer["Id"]);
                    Console.WriteLine("Nombre: " + leer["Nombre"]);
                    Console.WriteLine("Apellido: " + leer["Apellido"]);
                    Console.WriteLine("Edad: " + leer["Edad"]);
                    Console.WriteLine("Sexo: " + leer["Sexo"]);
                    Console.WriteLine("Telefono: " + leer["Telefono"]);
                    Console.WriteLine("Direccion: " + leer["Direccion"]);
                }
                else
                {
                    Console.WriteLine("Paciente no encontrado.");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Mostrar todos los pacientes
        public void MostrarPacientes()
        {
            try
            {
                SqlConnection con = conexion.Conectar();
                con.Open();

                string sql = "SELECT * FROM Pacientes";

                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataReader leer = cmd.ExecuteReader();

                while (leer.Read())
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Id: " + leer["Id"]);
                    Console.WriteLine("Nombre: " + leer["Nombre"]);
                    Console.WriteLine("Apellido: " + leer["Apellido"]);
                    Console.WriteLine("Edad: " + leer["Edad"]);
                    Console.WriteLine("Sexo: " + leer["Sexo"]);
                    Console.WriteLine("Telefono: " + leer["Telefono"]);
                    Console.WriteLine("Direccion: " + leer["Direccion"]);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Modificar paciente
        public void ModificarPaciente(Paciente paciente)
        {
            try
            {
                SqlConnection con = conexion.Conectar();
                con.Open();

                string sql = "UPDATE Pacientes SET Nombre=@Nombre,Apellido=@Apellido,Edad=@Edad,Sexo=@Sexo,Telefono=@Telefono,Direccion=@Direccion WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Id", paciente.Id);
                cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", paciente.Apellido);
                cmd.Parameters.AddWithValue("@Edad", paciente.Edad);
                cmd.Parameters.AddWithValue("@Sexo", paciente.Sexo);
                cmd.Parameters.AddWithValue("@Telefono", paciente.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", paciente.Direccion);

                cmd.ExecuteNonQuery();

                con.Close();

                Console.WriteLine("Paciente modificado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Eliminar paciente
        public void EliminarPaciente(int id)
        {
            try
            {
                SqlConnection con = conexion.Conectar();
                con.Open();

                string sql = "DELETE FROM Pacientes WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();

                con.Close();

                Console.WriteLine("Paciente eliminado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}