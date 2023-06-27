using System;
using Unity.Netcode;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;
    
    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;
    
    private float spawnPlateTimer;
    private float spawnPlaterTimerMax = 4f;
    private int platesSpawnedAmount;
    private int plateSpawnAmountMax = 4;

    private void Update()
    {
        if (!IsServer) return;
        
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlaterTimerMax)
        {
            spawnPlateTimer = 0f;
            
            if (KitchenGameManager.Instance.IsGamePlaying() && platesSpawnedAmount < plateSpawnAmountMax)
            {
                SpawnPlateServerRpc();
            }
        }
    }

    [ServerRpc]
    private void SpawnPlateServerRpc()
    {
        SpawnPlateClientRpc();
    }
    
    [ClientRpc]
    private void SpawnPlateClientRpc()
    {
        platesSpawnedAmount++;
                
        OnPlateSpawned?.Invoke(this, EventArgs.Empty);
    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            // Player is empty handed
            if (platesSpawnedAmount > 0)
            {
                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);
                
                InteractLogicServerRpc();
            }
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
        platesSpawnedAmount--;
        
        OnPlateRemoved?.Invoke(this, EventArgs.Empty);
    }
}
