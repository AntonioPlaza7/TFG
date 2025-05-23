using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

public class Grupo : ObservableObject
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int IdCurso { get; set; }
    public ObservableCollection<Alumno> Alumnos { get; set; } = [];

    public Grupo() {}
    public Grupo(string nombre, int idCurso)
    {
        Nombre = nombre;
        IdCurso = idCurso;
    }

    public Grupo(GrupoEntity grupoEntity)
    {
        Id = grupoEntity.Id;
        Nombre = grupoEntity.Nombre;
        IdCurso = grupoEntity.IdCurso;
        Alumnos = new ObservableCollection<Alumno>(
            new AlumnoService().ListAlumnos(Id)
        );
    }
}