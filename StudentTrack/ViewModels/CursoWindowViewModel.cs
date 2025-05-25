using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using StudentTrack.Models.Curso;
using StudentTrack.Models.Grupo;

namespace StudentTrack.ViewModels;

public partial class CursoWindowViewModel : ViewModelBase
{
    public ObservableCollection<CursoDTO> Cursos { get; } = [];
    public GrupoService grupoService = new();

    public CursoWindowViewModel()
    {
        Cursos = new ObservableCollection<CursoDTO>(
            new CursoService().ListCursos()
        );
    }

    public void RecargarCursos()
    {
        var nuevosCursos = new CursoService().ListCursos();

        Cursos.Clear();
        foreach (var curso in nuevosCursos)
        {
            Cursos.Add(curso);
        }
    }
}
