using System;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;
using StudentTrack.ViewModels;

namespace StudentTrack.Views;

public partial class MainWindow : Window
{
    public MainWindow()
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
                    var resultado = await ventana.ShowDialog<bool>(this);

                    if (resultado)
                    {
                        var vm = DataContext as MainWindowViewModel;
                        vm?.RecargarCursos();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error al cerrar modal: " + ex.Message);
                }
            }

            if (btn.Tag is Grupo grupo)
            {
                try
                {
                    var ventana = new GrupoWindow(grupo);
                    var resultado = await ventana.ShowDialog<bool>(this);

                    if (resultado)
                    {
                        var vm = DataContext as MainWindowViewModel;
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
                    var resultado = await ventana.ShowDialog<bool>(this);

                    if (resultado)
                    {
                        var vm = DataContext as MainWindowViewModel;
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
}