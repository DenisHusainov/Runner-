using System;

public class ObstacleController : Detected
{
    public static event Action Crashed = delegate { };

    public override void DetectedObject(PlayerController player)
    {
        Crashed();
    }
}
