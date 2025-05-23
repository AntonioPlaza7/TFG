using Avalonia.Interactivity;

namespace StudentTrack.ViewModels;

public partial class EliminarWindowViewModel : ViewModelBase
{
    public string Texto { get; set; }

    public EliminarWindowViewModel(string accion)
    {
        Texto = "¿Seguro que quiere eliminar el " + accion + " seleccionado?";
    }
    
}
