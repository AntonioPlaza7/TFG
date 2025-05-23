using System.Collections.Generic;

public class GrupoCRUD() {
    public void InsertGrupo(GrupoEntity Grupo) {
        var connection = Connector.GetConnection();
        using var command = connection.CreateCommand();

        command.CommandText = "INSERT INTO GRUPO (NOMBRE, ID_CURSO) VALUES (@nombre, @idCurso)";

        command.Parameters.AddWithValue("@nombre", Grupo.Nombre);
        command.Parameters.AddWithValue("@idCurso", Grupo.IdCurso);

        command.ExecuteNonQuery();

        Connector.CloseConnection(connection);
    }
    public void DeleteGrupo(int IdGrupo) {
        var connection = Connector.GetConnection();
        using var command = connection.CreateCommand();

        command.CommandText = "DELETE FROM GRUPO WHERE ID = @id";
        command.Parameters.AddWithValue("@id", IdGrupo);

        command.ExecuteNonQuery();
        
        Connector.CloseConnection(connection);
    }
    public void UpdateGrupo(GrupoEntity Grupo)
    {
        using var connection = Connector.GetConnection();
        using var command = connection.CreateCommand();

        command.CommandText = "UPDATE GRUPO SET NOMBRE = @nombre, ID_CURSO = @id_curso WHERE ID = @id";
        command.Parameters.AddWithValue("@nombre", Grupo.Nombre);
        command.Parameters.AddWithValue("@id_curso", Grupo.IdCurso);
        command.Parameters.AddWithValue("@id", Grupo.Id);

        command.ExecuteNonQuery();
        
        Connector.CloseConnection(connection);

    }
    public List<GrupoEntity> ListGrupos()
    {
        var Grupos = new List<GrupoEntity>();
        using var connection = Connector.GetConnection();
        using var command = connection.CreateCommand();

        command.CommandText = "SELECT * FROM Grupo";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            Grupos.Add(new GrupoEntity(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetInt32(2)
            ));
        }

        Connector.CloseConnection(connection);

        return Grupos;
        
    }

    public List<GrupoEntity> ListGrupos(int IdCurso)
    {
        var Grupos = new List<GrupoEntity>();
        using var connection = Connector.GetConnection();
        using var command = connection.CreateCommand();

        command.CommandText = "SELECT g.* FROM GRUPO g, CURSO c WHERE c.ID = g.ID_CURSO AND g.ID_CURSO = @idCurso";
        command.Parameters.AddWithValue("@idCurso", IdCurso);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            Grupos.Add(new GrupoEntity(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetInt32(2)
            ));
        }

        Connector.CloseConnection(connection);

        return Grupos;
        
    }

    public GrupoEntity? GetGrupo(int Id)
    {
        using var connection = Connector.GetConnection();
        using var command = connection.CreateCommand();

        command.CommandText = "SELECT * FROM Grupo WHERE Id = @id";
        command.Parameters.AddWithValue("@id", Id);

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            var Grupo = new GrupoEntity(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetInt32(2)
            );

            Connector.CloseConnection(connection);

            return Grupo;
        }

        Connector.CloseConnection(connection);

        return null;
    }
}