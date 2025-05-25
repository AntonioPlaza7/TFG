using CommunityToolkit.Mvvm.ComponentModel;
using StudentTrack.Models.Alumno;

namespace StudentTrack.ViewModels;

public partial class AlumnoDataWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private AlumnoDTO _alumno;

    public AlumnoDataWindowViewModel(AlumnoDTO alumno)
    {
        Alumno = alumno;
    }
    
}
