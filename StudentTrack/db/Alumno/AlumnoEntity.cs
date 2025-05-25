using System;
using StudentTrack.Models.Alumno;
namespace StudentTrack.db.Alumno;

public class AlumnoEntity
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public int IdGrupo { get; set; }

    public AlumnoEntity(string nombre, string apellidos, string email, string telefono, int idGrupo)
    {
        Nombre = nombre;
        Apellidos = apellidos;
        Email = email;
        Telefono = telefono;
        IdGrupo = idGrupo;
    }

    public AlumnoEntity(int id, string nombre, string apellidos, string email, string telefono, int idGrupo)
    {
        Id = id;
        Nombre = nombre;
        Apellidos = apellidos;
        Email = email;
        Telefono = telefono;
        IdGrupo = idGrupo;

    }
    
    public AlumnoEntity(AlumnoDTO alumno)
    {
        Id = alumno.Id;
        Nombre = alumno.Nombre;
        Apellidos = alumno.Apellidos;
        Email = alumno.Email;
        Telefono = alumno.Telefono;
        IdGrupo = alumno.IdGrupo;
    }

    public override String ToString()
    {
        return "Id: " + Id + ", Nombre: " + Nombre + ", Apellidos: " + Apellidos + ", Email: " + Email;
    }
}