using UnityEngine;

/* <summary>
///  Interface for kitchen objects that are parents of other kitchen objects
/// </summary>
 */
public interface IKitchenObjectParent
{ 
    public Transform GetKitchenObjectFollowTransform(); 
    public void SetKitchenObject(KitchenObject kitchenObject); 
    public KitchenObject GetKitchenObject(); 
    public void ClearKitchenObject(); 
    public bool HasKitchenObject();
}
