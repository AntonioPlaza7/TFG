using System;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using StudentTrack.Models.Alumno;
using StudentTrack.ViewModels;

namespace StudentTrack.Views;

public partial class AdminGrupoWindowView : UserControl
{
    public AdminGrupoWindowView()
    {
        InitializeComponent();
    }

    private async void AbrirAlumnoWindow(object? sender, RoutedEventArgs e)
    {
        if (sender is Button btn)
        {
            if (btn.Tag is int grupoId)
            {
                try
                {
                    var ventana = new AlumnoWindow(grupoId);
                    var mainWindow = this.VisualRoot as Window;
                    var resultado = await ventana.ShowDialog<bool>(mainWindow);

                    if (resultado)
                    {
                        var vm = DataContext as AdminGrupoWindowViewModel;
                        vm?.RecargarCursos();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error al cerrar modal: " + ex.Message);
                }
            }

            if (btn.Tag is AlumnoDTO alumno)
            {
                try
                {
                    var ventana = new AlumnoWindow(alumno);
                    var mainWindow = this.VisualRoot as Window;
                    var resultado = await ventana.ShowDialog<bool>(mainWindow);

                    if (resultado)
                    {
                        var vm = DataContext as AdminGrupoWindowViewModel;
                        vm?.RecargarCursos();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error al cerrar modal: " + ex.Message);
                }
            }
        }
    }

    private async void AbrirEliminarWindow(object? sender, RoutedEventArgs e)
    {
        if (sender is Button btn)
        {
            if (btn.Tag is int id)
            {
                try
                {
                    var ventana = new EliminarWindow("alumno", id);
                    var mainWindow = this.VisualRoot as Window;
                    var resultado = await ventana.ShowDialog<bool>(mainWindow);

                    if (resultado)
                    {
                        var vm = DataContext as AdminGrupoWindowViewModel;
                        vm?.RecargarCursos();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error al cerrar modal: " + ex.Message);
                }
            }
        }
    }

    public void NavigateBack_Click(object? sender, RoutedEventArgs e)
    {
        var mainWindow = this.VisualRoot as MainWindow;

        if (mainWindow?.DataContext is MainWindowViewModel mainViewModel)
        {
            mainViewModel.NavigateBackCommand!.Execute(null);
        }
    }

    private async void MostrarAlumnoWindow(object? sender, PointerPressedEventArgs e)
    {
        if (sender is Border border && border.DataContext is AlumnoDTO alumno)
        {
            try
            {
                var ventana = new AlumnoDataWindow(alumno);
                var mainWindow = this.VisualRoot as Window;
                var resultado = await ventana.ShowDialog<bool>(mainWindow);

                if (resultado)
                {
                    var vm = DataContext as AdminGrupoWindowViewModel;
                    vm?.RecargarCursos();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al cerrar modal: " + ex.Message);
            }
        }
    }
}