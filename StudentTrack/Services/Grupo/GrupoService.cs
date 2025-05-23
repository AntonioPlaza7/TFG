using System.Collections.Generic;
using System.Collections.ObjectModel;

public class GrupoService
{
    public GrupoCRUD GrupoCRUD;

    public GrupoService() {
        GrupoCRUD = new GrupoCRUD();
    }

    public List<Grupo> ListGrupos(int IdCurso)
    {
        List<Grupo> Grupos = new List<Grupo>();
        foreach (var GrupoEntity in GrupoCRUD.ListGrupos(IdCurso))
        {
            Grupos.Add(new Grupo(GrupoEntity));
        }

        return Grupos;
    }
}