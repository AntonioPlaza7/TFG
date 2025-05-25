using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using StudentTrack.db.Grupo;
using StudentTrack.Models.Alumno;
namespace StudentTrack.Models.Grupo;

public class GrupoDTO : ObservableObject
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int IdCurso { get; set; }
    public ObservableCollection<AlumnoDTO> Alumnos { get; set; } = [];

    public GrupoDTO() {}
    public GrupoDTO(string nombre, int idCurso)
    {
        Nombre = nombre;
        IdCurso = idCurso;
    }

    public GrupoDTO(GrupoEntity grupoEntity)
    {
        Id = grupoEntity.Id;
        Nombre = grupoEntity.Nombre;
        IdCurso = grupoEntity.IdCurso;
        Alumnos = new ObservableCollection<AlumnoDTO>(
            new AlumnoService().ListAlumnos(Id)
        );
    }
}