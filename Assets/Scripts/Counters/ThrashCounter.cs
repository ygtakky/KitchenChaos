using System;
using UnityEngine;

public class ThrashCounter : BaseCounter
{
    public static EventHandler OnAnyObjectThrashed;
    
    public new static void ResetStaticData()
    {
        OnAnyObjectThrashed = null;
    }
    
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            player.GetKitchenObject().DestroySelf();
            
            OnAnyObjectThrashed?.Invoke(this, EventArgs.Empty);
        }
    }

}
