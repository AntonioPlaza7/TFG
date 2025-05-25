using System;
using System.Collections.Generic;
using StudentTrack.db.Alumno;
using StudentTrack.Models.Alumno;

public class AlumnoService
{
    public AlumnoCRUD AlumnoCRUD;

    public AlumnoService()
    {
        AlumnoCRUD = new AlumnoCRUD();
    }

    public List<AlumnoDTO> ListAlumnos(int Id)
    {
        List<AlumnoDTO> Alumnos = new List<AlumnoDTO>();
        foreach (var AlumnoEntity in AlumnoCRUD.ListAlumnos(Id))
        {
            Alumnos.Add(new AlumnoDTO(AlumnoEntity));
        }

        return Alumnos;
    }

    public bool InsertarAlumno(AlumnoDTO Alumno)
    {
        var resultado = true;
        try
        {
            AlumnoCRUD.InsertAlumno(new AlumnoEntity(Alumno));
        }
        catch (Exception ex)
        {
            resultado = false;
        }

        return resultado;
    }

    public bool EditarAlumno(AlumnoDTO Alumno)
    {
        var resultado = true;
        try
        {
            AlumnoCRUD.UpdateAlumno(new AlumnoEntity(Alumno));
        }
        catch (Exception)
        {
            resultado = false;
        }

        return resultado;
    }

    public bool EliminarAlumno(int idAlumno)
    {
        var resultado = true;
        try
        {
            AlumnoCRUD.DeleteAlumno(idAlumno);
        }
        catch (Exception)
        {
            resultado = false;
        }

        return resultado;
    }
}