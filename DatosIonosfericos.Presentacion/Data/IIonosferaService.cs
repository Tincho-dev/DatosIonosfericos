namespace DatosIonosfericos.Data;

public interface IIonosferaService
{
    Task SaveData();
    Task<IQueryable<Record>> Get(DateTime date);
}
