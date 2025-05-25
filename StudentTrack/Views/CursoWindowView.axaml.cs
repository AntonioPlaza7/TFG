using System;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using StudentTrack.Models.Grupo;
using StudentTrack.ViewModels;

namespace StudentTrack.Views;

public partial class CursoWindowView : UserControl
{
    public CursoWindowView()
    {
        InitializeComponent();
    }

    private async void AbrirGrupoWindow(object? sender, RoutedEventArgs e)
    {
        if (sender is Button btn)
        {
            if (btn.Tag is int cursoId)
            {
                try
                {
                    var ventana = new GrupoWindow(cursoId);
                    var mainWindow = this.VisualRoot as Window;
                    var resultado = await ventana.ShowDialog<bool>(mainWindow);

                    if (resultado)
                    {
                        var vm = DataContext as CursoWindowViewModel;
                        vm?.RecargarCursos();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error al cerrar modal: " + ex.Message);
                }
            }

            if (btn.Tag is GrupoDTO grupo)
            {
                try
                {
                    var ventana = new GrupoWindow(grupo);
                    var mainWindow = this.VisualRoot as Window;
                    var resultado = await ventana.ShowDialog<bool>(mainWindow);

                    if (resultado)
                    {
                        var vm = DataContext as CursoWindowViewModel;
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
                    var ventana = new EliminarWindow("grupo", id);
                    var mainWindow = this.VisualRoot as Window;
                    var resultado = await ventana.ShowDialog<bool>(mainWindow);

                    if (resultado)
                    {
                        var vm = DataContext as CursoWindowViewModel;
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

    public void CargarAdminGrupoView(object? sender, PointerPressedEventArgs e)
    {
        var mainWindow = this.VisualRoot as MainWindow;

        if (mainWindow?.DataContext is MainWindowViewModel mainViewModel)
        {
            if (sender is Border border && border.DataContext is GrupoDTO grupo)
            {
                mainViewModel.NavigateToAdminGrupoCommand!.Execute(grupo);
            }
        }
    }
}