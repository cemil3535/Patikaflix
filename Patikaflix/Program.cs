using Patikaflix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//List created
List<TVShows> tvSeriesList = new List<TVShows>();

while (true)
{
    TVShows tvSeries = new TVShows();     // object created


    Console.WriteLine("Lutfen dizi bilgilerinin giriniz: ");
    Console.Write("Adi: ");
    tvSeries.Name = Console.ReadLine();
    Console.Write("Yapim Yili: ");
    tvSeries.ProductionYear = int.Parse(Console.ReadLine());
    Console.Write("Turu: ");
    tvSeries.Kind = Console.ReadLine();
    Console.Write("Yayinlanmaya Baslama Yili: ");
    tvSeries.ReleaseYears = int.Parse(Console.ReadLine());
    Console.Write("Yonetmen: ");
    tvSeries.Director = Console.ReadLine();
    Console.Write("Yayainlandigi Platform: ");
    tvSeries.Platform = Console.ReadLine();

    // Adding data received from the user to the list
    tvSeriesList.Add(tvSeries);

    // Asking the user whether to make a new entry or not
    Console.Write("Baska bir dizi eklemek istiyor musunuz? (E/H): ");
    string userReply = Console.ReadLine().ToLower();
    if (userReply == "h")
        break;
}


// Creating a new list of comedy series
List<ComedySeries> tvComedySeriesList = tvSeriesList
    .Where(s => s.Kind.ToLower().Contains("komedi"))
    .Select(s => new ComedySeries
    {
        Name = s.Name,
        Kind = s.Kind,
        Director = s.Director,
    })
    .ToList();

//Sort and print comedy series
Console.WriteLine("Komedi Dizileri:");
foreach(var series in tvComedySeriesList.OrderBy(s => s.Name).ThenBy(s => s.Director))
{
    Console.WriteLine("Ad: " + series.Name +" Tur: " + series.Kind +" Yonetmen: " + series.Director);
}