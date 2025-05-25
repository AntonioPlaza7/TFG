using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.ComponentModel;
using StudentTrack.Models.Grupo;

namespace StudentTrack.ViewModels;

public partial class AdminGrupoWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private GrupoDTO _selectedGrupo;

    public AdminGrupoWindowViewModel(GrupoDTO grupo)
    {
        SelectedGrupo = grupo;
    }

    public void RecargarCursos()
    {
        SelectedGrupo = new GrupoService().GetGrupo(SelectedGrupo.Id);
    }
    
}
