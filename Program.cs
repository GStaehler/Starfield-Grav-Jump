// Starfield Grav Jump Console Interface in C# - MIT License - Copyright (c) 2023 Gauthier Staehler

void Main()
{
    string[] phrases = { "CALIBRATING INFEROMETER", "PLANCK MAPPING", "REFERENCE LOCKED", "ENCODING PHASE SHIFT", "SYNCOIC PULL" };
    string[] searchingIcons = { " |", " /", " -", " \\" };

    int maxLength = phrases.Max(p => p.Length) + 10;

    Console.ForegroundColor = ConsoleColor.Red;
    Console.CursorVisible = false;

    foreach (var phrase in phrases)
    {
        for (int i = 0; i < 5; i++)
        {
            foreach (string icon in searchingIcons)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write($"\r{phrase.PadRight(maxLength)} {icon}");
                Thread.Sleep(100);
            }
        }
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Red;
        
        Console.Write($"\r{phrase.PadRight(maxLength)} OK");
        Thread.Sleep(100);
        Console.WriteLine();
        if (phrase == "REFERENCE LOCKED" || phrase == "ENCODING PHASE SHIFT")
        {
            Console.WriteLine();
        }
    }
}

void Status()
{
    string[] phrases = { "BOOTING NAV COMP", "LOADING DATA", "MODULATING", "SPOOLING DRIVE", "CALCULATING", "READY" };
    int line = Console.CursorTop;
    int maxLength = phrases.Max(p => p.Length) + 10;
    
    Console.ForegroundColor = ConsoleColor.Red;
    Console.CursorVisible = false;
    
    foreach (var phrase in phrases)
    {
        Console.SetCursorPosition(0, line);
        Console.Write($"\r{phrase.PadRight(maxLength)}");
        line = Console.CursorTop;
        Thread.Sleep(400);
    }
}

Console.WriteLine("GRAV JUMP PENDING");
Console.WriteLine("POWER UP GRAV DRIVE (PRESS X)");
string? readResult;
readResult = Console.ReadLine();
if (readResult != null)
{
    readResult = readResult.ToLower();
    if (readResult == "x")
    {
        Main();
        Status();
    }
}
