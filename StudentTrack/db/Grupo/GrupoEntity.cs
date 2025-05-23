public class GrupoEntity
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int IdCurso { get; set; }

    public GrupoEntity(int id, string nombre, int idCurso)
    {
        Id = id;
        Nombre = nombre;
        IdCurso = idCurso;
    }

    public GrupoEntity(string nombre, int idCurso)
    {
        Nombre = nombre;
        IdCurso = idCurso;
    }
    
    public GrupoEntity(Grupo grupo)
    {
        Id = grupo.Id;
        Nombre = grupo.Nombre;
        IdCurso = grupo.IdCurso;
    }
}