using System.Numerics;
using Raylib_cs;

public class Engine
{
    Camera3D camera = new(new(10, 0, 0), new(0, 0, 0), new(0, 1, 0), 60f, CameraProjection.CAMERA_PERSPECTIVE);

    List<Cube> cubes;

    public Engine()
    {
        Raylib.SetCameraMode(camera, CameraMode.CAMERA_THIRD_PERSON);
        Raylib.SetCameraMoveControls(
            KeyboardKey.KEY_W,
            KeyboardKey.KEY_S,
            KeyboardKey.KEY_D,
            KeyboardKey.KEY_A,
            KeyboardKey.KEY_O,
            KeyboardKey.KEY_I
        );

        cubes = new();
        for (int i = 0; i < 200; i += 20)
        {
            for (int j = 0; j < 200; j += 20)
            {
                for (int k = 0; k < 200; k += 20)
                {
                    cubes.Add(new(new(i, j, k), true));
                }
            }
        }
    }

    public void Run()
    {
        while (!Raylib.WindowShouldClose())
        {
            BeginContext();

            MainWork();

            EndContext();
        }
    }

    private void MainWork()
    {
        Raylib.DrawCircle3D(new(0, 0, 0), 1, new(0, 0, 0), 0f, Color.RED);

        foreach (Cube c in cubes)
        {
            c.Draw();
        }
    }

    private void EndContext()
    {
        Raylib.EndMode3D();
        Raylib.EndDrawing();
    }

    private void BeginContext()
    {
        Raylib.UpdateCamera(ref camera);

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);

        Raylib.BeginMode3D(camera);
    }
}
