using Raylib_cs;

Console.WriteLine("Hello, World!");
Console.WriteLine("May I say cube-world!");

Engine e;

Setup();
Draw();

void Setup()
{
    Raylib.InitWindow(800, 800, "Cubed");
    e = new();
}

void Draw()
{
    e.Run();
}