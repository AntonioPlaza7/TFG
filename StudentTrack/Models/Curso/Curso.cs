using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

public class Curso : ObservableObject
{public int Id { get; set; }
    public string Nombre { get; set; }
    public ObservableCollection<Grupo> Grupos { get; set; } = [];

    public Curso() {}

    public Curso(CursoEntity cursoEntity)
    {
        Id = cursoEntity.Id;
        Nombre = cursoEntity.Nombre;
        Grupos = new ObservableCollection<Grupo>(
            new GrupoService().ListGrupos(Id)
        );
    }
}