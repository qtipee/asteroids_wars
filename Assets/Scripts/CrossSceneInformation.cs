using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Provides a way of passing some information between scenes.
public static class CrossSceneInformation
{
    public static int MAX_TIME_HARVEST = 15;

    public static bool isPlaying { get; set; }

    public static int nbAsteroids { get; set; }

    public static float sceneSize { get; set; }

    public static int score { get; set; }
}
