using System.Collections.Generic;
using System.Collections.ObjectModel;

public class AlumnoService
{
    public AlumnoCRUD AlumnoCRUD;

    public AlumnoService()
    {
        AlumnoCRUD = new AlumnoCRUD();
    }

    public List<Alumno> ListAlumnos(int Id)
    {
        List<Alumno> Alumnos = new List<Alumno>();
        foreach (var AlumnoEntity in AlumnoCRUD.ListAlumnos(Id))
        {
            Alumnos.Add(new Alumno(AlumnoEntity));
        }

        return Alumnos;
    }
}