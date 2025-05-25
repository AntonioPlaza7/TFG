using Avalonia.Controls;
using Avalonia.Interactivity;
using StudentTrack.Models.Alumno;
using StudentTrack.ViewModels;

namespace StudentTrack.Views;

public partial class AlumnoDataWindow : Window
{
    public AlumnoDataWindowViewModel ViewModel { get; private set; }

    public AlumnoDataWindow(AlumnoDTO alumno)
    {
        InitializeComponent();
        ViewModel = new AlumnoDataWindowViewModel(alumno);
        DataContext = ViewModel;
    }
}