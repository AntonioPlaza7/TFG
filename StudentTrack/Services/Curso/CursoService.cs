using System.Collections.Generic;

public class CursoService
{
    public CursoCRUD CursoCRUD;

    public CursoService() {
        CursoCRUD = new CursoCRUD();
    }

    public List<Curso> ListCursos()
    {
        List<Curso> cursos = new List<Curso>();
        foreach (var cursoEntity in CursoCRUD.ListCursos())
        {
            cursos.Add(new Curso(cursoEntity));
        }

        return cursos;
    }
}