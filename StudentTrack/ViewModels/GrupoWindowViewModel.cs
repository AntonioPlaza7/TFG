using System.Collections.ObjectModel;

namespace StudentTrack.ViewModels;

public partial class GrupoWindowViewModel : ViewModelBase
{
    public Grupo Grupo { get; set; }
    public bool IsEdicion { get; set; }

    public GrupoWindowViewModel(bool isEdicion, Grupo grupo)
    {
        IsEdicion = isEdicion;
        Grupo = grupo;
    }
    
}
