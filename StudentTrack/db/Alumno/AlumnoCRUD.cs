using System.Collections.Generic;
using StudentTrack.db.Alumno;

public class AlumnoCRUD() {
    public void InsertAlumno(AlumnoEntity Alumno)
    {
        var connection = Connector.GetConnection();
        using var command = connection.CreateCommand();

        command.CommandText = "INSERT INTO ALUMNO (NOMBRE, APELLIDOS, EMAIL, TELEFONO, ID_GRUPO) VALUES (@nombre, @apellidos, @email, @telefono, @idGrupo)";
        command.Parameters.AddWithValue("@nombre", Alumno.Nombre);
        command.Parameters.AddWithValue("@apellidos", Alumno.Apellidos);
        command.Parameters.AddWithValue("@email", Alumno.Email);
        command.Parameters.AddWithValue("@telefono", Alumno.Telefono);
        command.Parameters.AddWithValue("@idGrupo", Alumno.IdGrupo);

        command.ExecuteNonQuery();
        
        Connector.CloseConnection(connection);
    }
    public void DeleteAlumno(int IdAlumno)
    {
        var connection = Connector.GetConnection();
        using var command = connection.CreateCommand();

        command.CommandText = "DELETE FROM ALUMNO WHERE ID = @id";
        command.Parameters.AddWithValue("@id", IdAlumno);

        command.ExecuteNonQuery();
        
        Connector.CloseConnection(connection);
        
    }
    public void UpdateAlumno(AlumnoEntity Alumno)
    {
        var connection = Connector.GetConnection();
        using var command = connection.CreateCommand();

        command.CommandText = "UPDATE ALUMNO SET NOMBRE = @nombre, APELLIDOS = @apellidos, EMAIL = @email, TELEFONO = @telefono, ID_GRUPO = @idGrupo WHERE ID = @id";
        command.Parameters.AddWithValue("@nombre", Alumno.Nombre);
        command.Parameters.AddWithValue("@apellidos", Alumno.Apellidos);
        command.Parameters.AddWithValue("@email", Alumno.Email);
        command.Parameters.AddWithValue("@telefono", Alumno.Telefono);
        command.Parameters.AddWithValue("@idGrupo", Alumno.IdGrupo);
        command.Parameters.AddWithValue("@id", Alumno.Id);

        command.ExecuteNonQuery();        

        Connector.CloseConnection(connection);
    }
    public List<AlumnoEntity> ListAlumnos()
    {
        List<AlumnoEntity> alumnosList = new List<AlumnoEntity>();
        var connection = Connector.GetConnection();
        using var command = connection.CreateCommand();
        
        command.CommandText = "SELECT * FROM ALUMNO";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            alumnosList.Add(new AlumnoEntity(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetString(4),
                reader.GetInt32(5)
            ));
        }

        Connector.CloseConnection(connection);

        return alumnosList;
    }
    public List<AlumnoEntity> ListAlumnos(int IdGrupo)
    {
        List<AlumnoEntity> alumnosList = new List<AlumnoEntity>();
        var connection = Connector.GetConnection();
        using var command = connection.CreateCommand();
        
        command.CommandText = "SELECT a.* FROM ALUMNO a, GRUPO g WHERE g.ID = a.ID_GRUPO AND a.ID_GRUPO = @idGrupo";
        command.Parameters.AddWithValue("@idGrupo", IdGrupo);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            alumnosList.Add(new AlumnoEntity(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetString(4),
                reader.GetInt32(5)
            ));
        }

        Connector.CloseConnection(connection);

        return alumnosList;
    }

    public AlumnoEntity? GetAlumno(int Id)
    {
        var connection = Connector.GetConnection();
        using var command = connection.CreateCommand();
        
        command.CommandText = "SELECT * FROM ALUMNO WHERE ID = @id";
        command.Parameters.AddWithValue("@id", Id);

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            var Alumno = new AlumnoEntity(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetString(4),
                reader.GetInt32(5)
            );

            Connector.CloseConnection(connection);

            return Alumno;
        }

        Connector.CloseConnection(connection);

        return null;
    }
}