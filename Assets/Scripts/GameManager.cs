﻿public class GameManager {
    public static int score = 0;
    public static int lifes = 3;
    public const int maxLifes = 3;
    public const float minSpeed = 5;
    public const float maxSpeed = 15;

    public static float currentSpeed;

    public static void restart()
    {
        score = 0;
        lifes = 3;
        currentSpeed = minSpeed;
    }
}
