using System;

public class Obstacle : ObjectContact
{
    public static event Action Crashed = delegate { };

    public override void OnInteracted(PlayerController player)
    {
        Crashed();
    }
}
