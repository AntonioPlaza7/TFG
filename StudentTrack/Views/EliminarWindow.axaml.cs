using Avalonia.Controls;
using Avalonia.Interactivity;
using StudentTrack.ViewModels;

namespace StudentTrack.Views;

public partial class EliminarWindow : Window
{
    private string _accion;
    private int _id;
    private GrupoService grupoService = new();
    private AlumnoService alumnoService = new();

    public EliminarWindow() 
    { 
        InitializeComponent();
    }

    public EliminarWindow(string accion, int id)
    {
        InitializeComponent();
        _accion = accion;
        _id = id;
        DataContext = new EliminarWindowViewModel(accion);
    }

    private void OnEliminarClick(object? sender, RoutedEventArgs e)
    {
        var resultado = false;
        if (_accion.Equals("grupo"))
        {
            resultado = grupoService.EliminarGrupo(_id);
        } else if (_accion.Equals("alumno")) {
            resultado = alumnoService.EliminarAlumno(_id);
        }
        Close(resultado);
    }

    private void OnCancelarClick(object? sender, RoutedEventArgs e)
    {
        Close(false);
    }
}