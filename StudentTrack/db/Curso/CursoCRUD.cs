using System.Collections.Generic;
using StudentTrack.db.Curso;

public class CursoCRUD() {
    public List<CursoEntity> ListCursos() {
        var cursos = new List<CursoEntity>();
        using var connection = Connector.GetConnection();
        using var command = connection.CreateCommand();

        command.CommandText = "SELECT * FROM CURSO";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            cursos.Add(new CursoEntity(
                reader.GetInt32(0),
                reader.GetString(1)
            ));
        }
        Connector.CloseConnection(connection);
        return cursos;
    }
    public CursoEntity? GetCurso(int Id) {
        using var connection = Connector.GetConnection();
        using var command = connection.CreateCommand();

        command.CommandText = "SELECT * FROM CURSO WHERE Id = @id";
        command.Parameters.AddWithValue("@id", Id);

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            var cursoEntity = new CursoEntity(
                reader.GetInt32(0),
                reader.GetString(1)
            );
            
            Connector.CloseConnection(connection);

            return cursoEntity;
        }
        Connector.CloseConnection(connection);  
        return null;
    }
}