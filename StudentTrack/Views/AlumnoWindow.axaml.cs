using Avalonia.Controls;
using Avalonia.Interactivity;
using StudentTrack.Models.Alumno;
using StudentTrack.ViewModels;

namespace StudentTrack.Views;

public partial class AlumnoWindow : Window
{
    private AlumnoDTO _Alumno;
    private int _grupoId;
    private AlumnoService AlumnoService = new();
    public AlumnoWindowViewModel ViewModel { get; private set; }

    public AlumnoWindow(int grupoId)
    {
        InitializeComponent();
        _grupoId = grupoId;
        ViewModel = new AlumnoWindowViewModel(false, new AlumnoDTO());
        DataContext = ViewModel;
    }
    public AlumnoWindow(AlumnoDTO Alumno)
    {
        InitializeComponent();
        _Alumno = Alumno;
        ViewModel = new AlumnoWindowViewModel(true, Alumno);
        DataContext = ViewModel;
    }

    private void OnInsertarClick(object? sender, RoutedEventArgs e)
    {
        var resultado = false;
        var NombreAlumno = this.FindControl<TextBox>("NombreAlumnoTextBox");
        var ApellidosAlumno = this.FindControl<TextBox>("ApellidosAlumnoTextBox");
        var EmailAlumno = this.FindControl<TextBox>("EmailAlumnoTextBox");
        var TelefonoAlumno = this.FindControl<TextBox>("TelefonoAlumnoTextBox");
        if (NombreAlumno != null && ApellidosAlumno != null && EmailAlumno != null && TelefonoAlumno != null)
        {
            resultado = AlumnoService.InsertarAlumno(new AlumnoDTO(NombreAlumno.Text, ApellidosAlumno.Text, EmailAlumno.Text, TelefonoAlumno.Text, _grupoId));
        }
        Close(resultado);
    }

    private void OnEditarClick(object? sender, RoutedEventArgs e)
    {
        var resultado = false;
        var NombreAlumno = this.FindControl<TextBox>("NombreAlumnoTextBox");
        var GrupoSeleccionado = ViewModel.GrupoSeleccionado;
        if (NombreAlumno != null && GrupoSeleccionado != null)
        {
            _Alumno.Nombre = NombreAlumno.Text;
            _Alumno.IdGrupo = GrupoSeleccionado.Id;
            resultado = AlumnoService.EditarAlumno(_Alumno);
        }
        Close(resultado);
    }
}