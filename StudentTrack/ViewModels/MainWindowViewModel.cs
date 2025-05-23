using System.Collections.ObjectModel;

namespace StudentTrack.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Curso> Cursos { get; set; } = [];

    public MainWindowViewModel()
    {
        Cursos = new ObservableCollection<Curso>(
            new CursoService().ListCursos()
        );
    }
    
}
