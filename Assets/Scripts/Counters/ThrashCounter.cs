using System;
using Unity.Netcode;
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
            KitchenObject.DestroyKitchenObject(player.GetKitchenObject());
            
            InteractLogicServerRpc();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void InteractLogicServerRpc()
    {
        InteractLogicClientRpc();
    }

    [ClientRpc]
    private void InteractLogicClientRpc()
    {
        OnAnyObjectThrashed?.Invoke(this, EventArgs.Empty);
    }
}
