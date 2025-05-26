using Avalonia.Controls;
using Avalonia.Interactivity;
using StudentTrack.Models;
using StudentTrack.Models.Grupo;
using StudentTrack.ViewModels;

namespace StudentTrack.Views;

public partial class GrupoWindow : Window
{
    private GrupoDTO _grupo;
    private int _cursoId;
    private GrupoService grupoService = new();
    public GrupoWindowViewModel ViewModel { get; private set; }

    public GrupoWindow()
    { 
        InitializeComponent();
    }

    public GrupoWindow(int cursoId)
    {
        InitializeComponent();
        _cursoId = cursoId;
        ViewModel = new GrupoWindowViewModel(false, new GrupoDTO());
        DataContext = ViewModel;
    }
    public GrupoWindow(GrupoDTO grupo)
    {
        InitializeComponent();
        _grupo = grupo;
        ViewModel = new GrupoWindowViewModel(true, grupo);
        DataContext = ViewModel;
    }

    private void OnInsertarClick(object? sender, RoutedEventArgs e)
    {
        var resultado = false;
        var NombreGrupo = this.FindControl<TextBox>("NombreGrupoTextBox");
        if (NombreGrupo != null)
        {
            resultado = grupoService.InsertarGrupo(new GrupoDTO(NombreGrupo.Text, _cursoId));
        }
        Close(resultado);
    }

    private void OnEditarClick(object? sender, RoutedEventArgs e)
    {
        var resultado = false;
        var NombreGrupo = this.FindControl<TextBox>("NombreGrupoTextBox");
        var CursoSeleccionado = ViewModel.CursoSeleccionado;
        if (NombreGrupo != null && CursoSeleccionado != null)
        {
            _grupo.Nombre = NombreGrupo.Text;
            _grupo.IdCurso = CursoSeleccionado.Id;
            resultado = grupoService.EditarGrupo(_grupo);
        }
        Close(resultado);
    }
}