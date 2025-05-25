using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using StudentTrack.db.Curso;
using StudentTrack.Models.Grupo;
namespace StudentTrack.Models.Curso;

public class CursoDTO : ObservableObject
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public ObservableCollection<GrupoDTO> Grupos { get; set; } = [];

    public CursoDTO() {}

    public CursoDTO(CursoEntity cursoEntity)
    {
        Id = cursoEntity.Id;
        Nombre = cursoEntity.Nombre;
        Grupos = new ObservableCollection<GrupoDTO>(
            new GrupoService().ListGrupos(Id)
        );
    }
}