using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StudentTrack.ViewModels;

public partial class GrupoWindowViewModel : ViewModelBase
{
    public Grupo Grupo { get; set; }
    public bool IsEdicion { get; set; }
    private CursoService cursoService = new();
    public ObservableCollection<Curso> Cursos { get; } = [];
    public Curso CursoSeleccionado { get; set; }

    public GrupoWindowViewModel(bool isEdicion, Grupo grupo)
    {
        IsEdicion = isEdicion;
        Grupo = grupo;
        Cursos = Cursos = new ObservableCollection<Curso>(
            new CursoService().ListCursos()
        );
        CursoSeleccionado = GetCursoSeleccionado(grupo.IdCurso);
    }

    private Curso GetCursoSeleccionado(int idCurso)
    {
        var Curso = new Curso();
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
