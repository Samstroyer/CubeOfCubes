using System.Numerics;
using Raylib_cs;

public class Cube
{
    static Random r = new();

    List<Cube> cubes;

    Color c;

    Vector3 position;

    public Cube(Vector3 pos, bool spawnMore)
    {
        if (spawnMore)
        {
            cubes = new();
            for (int i = 0; i < 10; i += 5)
            {
                for (int j = 0; j < 10; j += 5)
                {
                    for (int k = 0; k < 10; k += 5)
                    {
                        cubes.Add(new(new Vector3(i, j, k) + pos, false));
                    }
                }
            }
        }

        position = pos;

        if (r.NextSingle() > 0.5f)
            c = Color.BLUE;
        else
            c = Color.GREEN;
    }

    public void Draw()
    {
        if (cubes is not null)
        {
            foreach (Cube c in cubes)
            {
                c.Draw();
            }
        }
        else
        {
            Raylib.DrawCube(position, 3, 3, 3, c);
        }
    }
}
