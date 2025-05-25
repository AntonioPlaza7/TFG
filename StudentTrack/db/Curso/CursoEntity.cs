namespace StudentTrack.db.Curso;

public class CursoEntity
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public CursoEntity(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }
}