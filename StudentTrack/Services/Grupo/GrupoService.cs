using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class GrupoService
{
    public GrupoCRUD GrupoCRUD;

    public GrupoService()
    {
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

    public bool InsertarGrupo(Grupo grupo)
    {
        var resultado = true;
        try
        {
            GrupoCRUD.InsertGrupo(new GrupoEntity(grupo));
        }
        catch (Exception)
        {
            resultado = false;
        }

        return resultado;
    }

    public bool EditarGrupo(Grupo grupo)
    {
        var resultado = true;
        try
        {
            GrupoCRUD.UpdateGrupo(new GrupoEntity(grupo));
        }
        catch (Exception)
        {
            resultado = false;
        }

        return resultado;
    }

    public bool EliminarGrupo(int idGrupo)
    {
        var resultado = true;
        try
        {
            GrupoCRUD.DeleteGrupo(idGrupo);
        }
        catch (Exception)
        {
            resultado = false;
        }

        return resultado;
    }
}