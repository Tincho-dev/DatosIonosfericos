using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DatosIonosfericos.Data;

public class Record
{
    [Key]
    public string? dt { get; set; }
    public string? station { get; set; }
    public string? fromfile { get; set; }
    public string? producer { get; set; }
    public string? evaluated { get; set; }
    public string? fof2 { get; set; }
    public bool fof2_eval { get; set; }
    public string? muf3000f2 { get; set; }
    public bool muf3000f2_eval { get; set; }
    public string? m3000f2 { get; set; }
    public bool m3000f2_eval { get; set; }
    public string? fxi { get; set; }
    public bool fxi_eval { get; set; }
    public string? fof1 { get; set; }
    public bool fof1_eval { get; set; }
    public string? ftes { get; set; }
    public bool ftes_eval { get; set; }
    public string? h_es { get; set; }
    public bool h_es_eval { get; set; }
    public string? aip_hmf2 { get; set; }
    public string? aip_fof2 { get; set; }
    public string? aip_fof1 { get; set; }
    public string? aip_hmf1 { get; set; }
    public string? aip_d1 { get; set; }
    public string? aip_foe { get; set; }
    public string? aip_hme { get; set; }
    public string? aip_yme { get; set; }
    public string? aip_h_ve { get; set; }
    public string? aip_ewidth { get; set; }
    public string? aip_deln_ve { get; set; }
    public string? aip_b0 { get; set; }
    public string? aip_b1 { get; set; }
    public string? tec_bottom { get; set; }
    public string? tec_top { get; set; }
    public string? profile { get; set; }
    public string? trace { get; set; }
    public string? modified { get; set; }
    public string? fof2_med_27_days { get; set; }
}

public class Rootobject
{
    public Record[]? Records { get; set; }
}

public static class RecordExtensions
{
    public static Record[] NullifyData(this Record[] records)
    {
        if (records != null)
        {
            PropertyInfo[] properties = typeof(Record).GetProperties();
            foreach (var record in records)
            {
                properties
                    .Where(property => property.GetValue(record) == null && property.PropertyType != typeof(bool))
                    .ToList()
                    .ForEach(property => property.SetValue(record, "NULL"));
            }
        }
        return records;
    }
}

