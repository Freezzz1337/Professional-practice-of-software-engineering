using System.Dynamic;
using Lab_5;
using Lab_5.DTO;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Show method GET:");
        SportApi sportApi = new SportApi();
        Task<EnterJson> enterJson = sportApi.getTeamList();
        Console.WriteLine("gender:" + enterJson.Result.Data[0].Gender +
                          " name:" + enterJson.Result.Data[0].Name +
                          " country:" + enterJson.Result.Data[0].Country);
        
        Console.WriteLine("------------------");

        Console.WriteLine("Show method POST:");
        enterJson = sportApi.serachTeamByName();
        Console.WriteLine("gender:" + enterJson.Result.Data[0].Gender + 
                          " name:" + enterJson.Result.Data[0].Name +
                          " country:" + enterJson.Result.Data[0].Country);
    }
}