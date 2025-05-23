using Avalonia.Controls;
using Avalonia.Interactivity;
using StudentTrack.ViewModels;

namespace StudentTrack.Views;

public partial class GrupoWindow : Window
{
    private Grupo _grupo;
    private int _cursoId;
    private GrupoService grupoService = new();

    public GrupoWindow(int cursoId)
    {
        InitializeComponent();
        _cursoId = cursoId;
        DataContext = new GrupoWindowViewModel(false, new Grupo());
    }
    public GrupoWindow(Grupo grupo)
    {
        InitializeComponent();
        _grupo = grupo;
        DataContext = new GrupoWindowViewModel(true, grupo);
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
        if (NombreGrupo != null)
        {
            resultado = grupoService.EditarGrupo(_grupo);
        }
        Close(resultado);
    }
}