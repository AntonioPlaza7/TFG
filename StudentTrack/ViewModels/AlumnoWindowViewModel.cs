using System.Collections.ObjectModel;
using StudentTrack.Models.Alumno;
using StudentTrack.Models.Grupo;

namespace StudentTrack.ViewModels;

public partial class AlumnoWindowViewModel : ViewModelBase
{
    public AlumnoDTO Alumno { get; set; }
    public bool IsEdicion { get; set; }
    private GrupoService grupoService = new();
    public ObservableCollection<GrupoDTO> Grupos { get; } = [];
    public GrupoDTO GrupoSeleccionado { get; set; }

    public AlumnoWindowViewModel(bool isEdicion, AlumnoDTO alumno)
    {
        IsEdicion = isEdicion;
        Alumno = alumno;
        Grupos = new ObservableCollection<GrupoDTO>(
            new GrupoService().ListGrupos()
        );
        GrupoSeleccionado = GetGrupoSeleccionado(alumno.IdGrupo);
    }

    private GrupoDTO GetGrupoSeleccionado(int idGrupo)
    {
        var Grupo = new GrupoDTO();
        foreach (var grupo in Grupos)
        {
            if (grupo.Id.Equals(idGrupo))
            {
                Grupo = grupo;
            }
        }
        return Grupo;
    }
    
}
