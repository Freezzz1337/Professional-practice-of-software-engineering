using System.Net;
using System.Xml.Linq;

namespace Lab_5.DTO;

public class EnterJson
{
    public List<Team> Data { get; set; }
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    
}