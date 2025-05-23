using Microsoft.Data.Sqlite;
using System;
using System.IO;

public static class Connector
{
    public static void InitializeDatabase()
    {
        string baseDir = AppContext.BaseDirectory;

        string dbDir = Path.Combine(baseDir, "db");
        string dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "StudentTrack",
            "StudentTrack.db"
        );

        string scriptPath = Path.Combine(baseDir, "db", "scripts", "StudentTrack.sql");

        if (!Directory.Exists(dbDir))
            Directory.CreateDirectory(dbDir);

        bool dbExists = File.Exists(dbPath);

        using var connection = new SqliteConnection($"Data Source={dbPath}");
        connection.Open();

        if (!dbExists)
        {
            if (!File.Exists(scriptPath))
                throw new FileNotFoundException("Script SQL no encontrado en: " + scriptPath);

            string sqlScript = File.ReadAllText(scriptPath);

            using var command = connection.CreateCommand();
            command.CommandText = sqlScript;
            command.ExecuteNonQuery();
        }
    }

    public static SqliteConnection GetConnection()
    {
        string dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "StudentTrack",
            "StudentTrack.db"
        );

        var connection = new SqliteConnection($"Data Source={dbPath}");
        connection.Open();
        return connection;
    }

    public static void CloseConnection(SqliteConnection connection) {
        connection.Close();
    }
    
}