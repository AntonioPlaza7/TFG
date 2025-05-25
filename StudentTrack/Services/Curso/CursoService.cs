using System.Collections.Generic;
using StudentTrack.Models;
using StudentTrack.Models.Curso;

public class CursoService
{
    public CursoCRUD CursoCRUD;

    public CursoService() {
        CursoCRUD = new CursoCRUD();
    }

    public List<CursoDTO> ListCursos()
    {
        List<CursoDTO> cursos = new List<CursoDTO>();
        foreach (var cursoEntity in CursoCRUD.ListCursos())
        {
            cursos.Add(new CursoDTO(cursoEntity));
        }

        return cursos;
    }
}