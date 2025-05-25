using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentTrack.Models.Grupo;

namespace StudentTrack.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase _currentContentViewModel;

    public MainWindowViewModel()
    {
        _currentContentViewModel = new CursoWindowViewModel();
    }

    [RelayCommand]
    private void NavigateBack()
    {
        CurrentContentViewModel = new CursoWindowViewModel();
    }
    
    [RelayCommand]
    private void NavigateToAdminGrupo(GrupoDTO grupo)
    {
        if (grupo != null)
        {
            CurrentContentViewModel = new AdminGrupoWindowViewModel(grupo);
        }
    }
}
