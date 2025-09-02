// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
    Televisao tv = new Televisao(55f);

    Console.WriteLine($"A TV tem o tamanho {tv.Tamanho}");

    tv.Volume = -35;
    Console.WriteLine($"Volume {tv.Volume}");

    tv.Volume = 120;
    Console.WriteLine($"Volume {tv.Volume}");