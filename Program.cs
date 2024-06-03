using System;
using System.Collections.Generic;

class Watch
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
}

class Program
{
    static List<Watch> watches = new List<Watch>();

    static void Main(string[] args)
    {
        // Shtoni disa orë të paravendosura
        watches.Add(new Watch { Id = 1, Brand = "Rolex", Model = "Submariner" });
        watches.Add(new Watch { Id = 2, Brand = "Omega", Model = "Speedmaster" });
        watches.Add(new Watch { Id = 3, Brand = "Cartier", Model = "Tank" });

        bool running = true;
        while (running)
        {
            Console.WriteLine("Zgjidhni një opsion:");
            Console.WriteLine("1. Shfaq");
            Console.WriteLine("2. Detaje");
            Console.WriteLine("3. Fshij");
            Console.WriteLine("4. Dil");

            int choice = GetIntInput();

            switch (choice)
            {
                case 1:
                    ShowWatches();
                    break;
                case 2:
                    ShowDetails();
                    break;
                case 3:
                    DeleteWatch();
                    break;
                case 4:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Zgjedhje e pavlefshme. Ju lutem provoni përsëri.");
                    break;
            }
        }
    }

    static void ShowWatches()
    {
        Console.WriteLine("Lista e orëve:");
        foreach (var watch in watches)
        {
            Console.WriteLine($"ID: {watch.Id}, Brand: {watch.Brand}, Model: {watch.Model}");
        }
    }

    static void ShowDetails()
    {
        Console.WriteLine("Jepni ID-në e orës për të cilën dëshironi të shihni detajet:");
        int id = GetIntInput();

        Watch watch = watches.Find(w => w.Id == id);
        if (watch != null)
        {
            Console.WriteLine($"ID: {watch.Id}");
            Console.WriteLine($"Brand: {watch.Brand}");
            Console.WriteLine($"Model: {watch.Model}");
        }
        else
        {
            Console.WriteLine("Nuk u gjet asnjë orë me atë ID.");
        }
    }

    static void DeleteWatch()
    {
        Console.WriteLine("Jepni ID-në e orës që dëshironi të fshini:");
        int id = GetIntInput();

        Watch watch = watches.Find(w => w.Id == id);
        if (watch != null)
        {
            watches.Remove(watch);
            Console.WriteLine("Ora u fshi me sukses.");
        }
        else
        {
            Console.WriteLine("Nuk u gjet asnjë orë me atë ID.");
        }
    }

    static int GetIntInput()
    {
        int value;
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Ju lutem jepni një numër të plotë.");
        }
        return value;
    }
}