using System.Collections.ObjectModel;

namespace StudentTrack.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Curso> Cursos { get; } = [];
    public GrupoService grupoService = new();

    public MainWindowViewModel()
    {
        Cursos = new ObservableCollection<Curso>(
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
