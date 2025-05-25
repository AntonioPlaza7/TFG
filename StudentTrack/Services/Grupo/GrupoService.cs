using System;
using System.Collections.Generic;
using StudentTrack.db.Grupo;
using StudentTrack.Models.Grupo;

public class GrupoService
{
    public GrupoCRUD GrupoCRUD;

    public GrupoService()
    {
        GrupoCRUD = new GrupoCRUD();
    }

    public List<GrupoDTO> ListGrupos()
    {
        List<GrupoDTO> Grupos = new List<GrupoDTO>();
        foreach (var GrupoEntity in GrupoCRUD.ListGrupos())
        {
            Grupos.Add(new GrupoDTO(GrupoEntity));
        }

        return Grupos;
    }

    public GrupoDTO GetGrupo(int id)
    {
        var grupoEntity = GrupoCRUD.GetGrupo(id);
        return grupoEntity != null ? new GrupoDTO(grupoEntity) : new GrupoDTO();
    }

    public List<GrupoDTO> ListGrupos(int IdCurso)
    {
        List<GrupoDTO> Grupos = new List<GrupoDTO>();
        foreach (var GrupoEntity in GrupoCRUD.ListGrupos(IdCurso))
        {
            Grupos.Add(new GrupoDTO(GrupoEntity));
        }

        return Grupos;
    }

    public bool InsertarGrupo(GrupoDTO grupo)
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

    public bool EditarGrupo(GrupoDTO grupo)
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