using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.Net;
using System.Reflection;
using static System.Net.WebRequestMethods;

namespace DatosIonosfericos.Data;

public class IonosferaService : IIonosferaService
{
    private readonly IonosferaContext _context;
    private readonly string baseUrl = "http://ws-eswua.rm.ingv.it/ais.php/records/";

    public IonosferaService(IonosferaContext context)
    {
        _context = context;
    }

    //private async Task SaveRecord(Record record)
    //{
    //    if (_context.Records.Any(r => r.dt == record.dt)) return;
    //    await _context.Records.AddAsync(record);
    //    _context.SaveChanges();
    //}
    private async Task SaveRecord(Record[] records)
    {
        if (_context.Records.Any(r => r.dt == records.First().dt)) return;
        await _context.Records.AddRangeAsync(records);
        _context.SaveChanges();
    }
    private async Task<Rootobject> RequestData(string url)
    {
        Rootobject respuesta = new();
        var client = new RestClient(url);
        var request = new RestRequest();
        var response = client.Execute(request);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            string rawResponse = response.Content;
            respuesta = JsonConvert.DeserializeObject<Rootobject>(rawResponse);

            if (!respuesta.Records.Any())
            {
                Console.WriteLine($"No hay datos para {url}");
                return respuesta;
            }
            await SaveRecord(respuesta.Records);
            Console.WriteLine($"Guardados {respuesta.Records.Length} de la url {url}");
        }
        return respuesta;
    }
    public async Task SaveData()
    {
        string station = "tuj2o";
        for (int año = 2010; año <= 2023; año++)
        {
            for (int mes = 1; mes <= 12; mes++)
            {
                string since_date = $"{año}-{mes}-01";//YYYY-MM-DD
                string until_date = $"{año}-{mes+1}-01";
                string url = $"{baseUrl}{station}_auto?filter=dt,bt,{since_date}%2000:00:00,{until_date}%2023:50:00&include+dt,{station}&order=dt";
                    
                await RequestData(url);
            }
        }
    }
}