using System;
using UnityEngine;

public class ThrashCounter : BaseCounter
{
    public static EventHandler OnAnyObjectThrashed;
    
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            player.GetKitchenObject().DestroySelf();
            
            OnAnyObjectThrashed?.Invoke(this, EventArgs.Empty);
        }
    }

}
