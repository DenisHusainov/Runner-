using System;

public class Obstacle : PlayerTriggers
{
    public static event Action Crashed = delegate { };

    public override void OnInteracted(PlayerController player)
    {
        Crashed();
    }
}
