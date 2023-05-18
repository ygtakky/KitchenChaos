using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;
    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // There is no kitchen object on this counter
            if (player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // Player not carrying a kitchen object
            }
        }
        else
        {
            // There is a kitchen object on this counter
            if (player.HasKitchenObject())
            {
                // Player is carrying a kitchen object
            }
            else
            {
                // Player not carrying a kitchen object
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
    
    public override void InteractAlternate()
    {
        if (HasKitchenObject())
        {
            // There is a kitchen object on this counter
            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);
        }
    }
}
