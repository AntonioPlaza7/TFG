using System.Collections.Generic;
using System.Collections.ObjectModel;
using StudentTrack.Models;
using StudentTrack.Models.Curso;
using StudentTrack.Models.Grupo;

namespace StudentTrack.ViewModels;

public partial class GrupoWindowViewModel : ViewModelBase
{
    public GrupoDTO Grupo { get; set; }
    public bool IsEdicion { get; set; }
    private CursoService cursoService = new();
    public ObservableCollection<CursoDTO> Cursos { get; } = [];
    public CursoDTO CursoSeleccionado { get; set; }

    public GrupoWindowViewModel(bool isEdicion, GrupoDTO grupo)
    {
        IsEdicion = isEdicion;
        Grupo = grupo;
        Cursos = Cursos = new ObservableCollection<CursoDTO>(
            new CursoService().ListCursos()
        );
        CursoSeleccionado = GetCursoSeleccionado(grupo.IdCurso);
    }

    private CursoDTO GetCursoSeleccionado(int idCurso)
    {
        var Curso = new CursoDTO();
        foreach (var curso in Cursos)
        {
            if (curso.Id.Equals(idCurso))
            {
                Curso = curso;
            }
        }
        return Curso;
    }
    
}
