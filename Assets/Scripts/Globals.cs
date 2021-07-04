using UnityEngine;

public static class Globals
{
    public static bool canControl = true;       // If the player character can be controlled
    public static Vector2 curDashArrowVel;      // Current velocity from the last touched Dash Arrow
    public static GameObject curCamBound;
    public static int curCheckpoint = 0;        // Current checkpoint (start of level is 0)
    public static bool controllerOn = false;    // Keeps track on whether a controller is connected

    public static void Reset() {
        curCheckpoint = 0;
    }
}
