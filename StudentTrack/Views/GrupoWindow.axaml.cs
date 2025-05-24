using Avalonia.Controls;
using Avalonia.Interactivity;
using StudentTrack.ViewModels;

namespace StudentTrack.Views;

public partial class GrupoWindow : Window
{
    private Grupo _grupo;
    private int _cursoId;
    private GrupoService grupoService = new();
    public GrupoWindowViewModel ViewModel { get; private set; }

    public GrupoWindow(int cursoId)
    {
        InitializeComponent();
        _cursoId = cursoId;
        ViewModel = new GrupoWindowViewModel(false, new Grupo());
        DataContext = ViewModel;
    }
    public GrupoWindow(Grupo grupo)
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
            resultado = grupoService.InsertarGrupo(new Grupo(NombreGrupo.Text, _cursoId));
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