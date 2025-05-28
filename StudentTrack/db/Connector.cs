using Microsoft.Data.Sqlite;
using System;
using System.IO;

public static class Connector
{
    public static void InitializeDatabase()
    {
        string baseDir = AppContext.BaseDirectory;
        string configBasePath;
        if (OperatingSystem.IsWindows())
        {
            configBasePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }
        else
        {
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            configBasePath = Path.Combine(userProfile, ".config");
        }

        string appSpecificDbDir = Path.Combine(configBasePath, "StudentTrack");
        string dbPath = Path.Combine(appSpecificDbDir, "StudentTrack.db");

        string scriptPath = Path.Combine(baseDir, "db", "scripts", "StudentTrack.sql");

        if (!Directory.Exists(appSpecificDbDir))
        {
            Directory.CreateDirectory(appSpecificDbDir);
            Console.WriteLine($"Directorio de configuración creado: {appSpecificDbDir}");
        }

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
            Console.WriteLine("Base de datos creada e inicializada con éxito.");
        }
        else
        {
            Console.WriteLine("La base de datos ya existe. No se requiere inicialización.");
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