using System;

public class ObstacleController : ObjectContact
{
    public static event Action Crashed = delegate { };

    public override void OnInteracted(PlayerController player)
    {
        Crashed();
    }
}
