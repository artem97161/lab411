using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class InternetTariff
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int DataLimitGB { get; set; }

    public InternetTariff(string name, double price, int dataLimitGB)
    {
        Name = name;
        Price = price;
        DataLimitGB = dataLimitGB;
    }

    public override string ToString()
    {
        return $"{Name}: Price - {Price}$, Data Limit - {DataLimitGB}GB";
    }
}

public class InternetProvider
{
    private List<InternetTariff> tariffs;

    public InternetProvider()
    {
        tariffs = new List<InternetTariff>();
    }

    public void AddTariff(InternetTariff tariff)
    {
        tariffs.Add(tariff);
    }

    public void PrintTariffs()
    {
        foreach (var tariff in tariffs)
        {
            Console.WriteLine(tariff);
        }
    }

    public int CountCustomersByTariff(InternetTariff tariff)
    {

        return 100; 
    }

    public List<InternetTariff> SortTariffsByDataLimit()
    {
        return tariffs.OrderBy(t => t.DataLimitGB).ToList();
    }

    public InternetTariff FindTariff(int dataLimitFrom, int dataLimitTo, double price)
    {
        return tariffs.FirstOrDefault(t => t.DataLimitGB >= dataLimitFrom && t.DataLimitGB <= dataLimitTo && t.Price <= price);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var provider = new InternetProvider();

        provider.AddTariff(new InternetTariff("Basic", 20, 50));
        provider.AddTariff(new InternetTariff("Standard", 30, 100));
        provider.AddTariff(new InternetTariff("Premium", 50, 200));
        Console.WriteLine("List of tariffs:");
        provider.PrintTariffs();

        foreach (var tariff in provider.SortTariffsByDataLimit())
        {
            Console.WriteLine($"Number of customers on {tariff.Name}: {provider.CountCustomersByTariff(tariff)}");
        }


        int dataLimitFrom = 50;
        int dataLimitTo = 150;
        double price = 40;
        var foundTariff = provider.FindTariff(dataLimitFrom, dataLimitTo, price);
        if (foundTariff != null)
        {
            Console.WriteLine($"Found tariff within specified range: {foundTariff}");
        }
        else
        {
            Console.WriteLine("No tariff found within specified range.");
        }
    }
}