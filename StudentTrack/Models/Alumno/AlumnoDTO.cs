using CommunityToolkit.Mvvm.ComponentModel;
using StudentTrack.db.Alumno;
namespace StudentTrack.Models.Alumno;

public class AlumnoDTO : ObservableObject
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public int IdGrupo { get; set; }

    public AlumnoDTO() {}
    public AlumnoDTO(string nombre, string apellidos, string email, string telefono, int idGrupo)
    {
        Nombre = nombre;
        Apellidos = apellidos;
        Email = email;
        Telefono = telefono;
        IdGrupo = idGrupo;
    }
 
    public AlumnoDTO(AlumnoEntity alumnoEntity)
    {
        Id = alumnoEntity.Id;
        Nombre = alumnoEntity.Nombre;
        Apellidos = alumnoEntity.Apellidos;
        Email = alumnoEntity.Email;
        Telefono = alumnoEntity.Telefono;
        IdGrupo = alumnoEntity.IdGrupo;
    }
}