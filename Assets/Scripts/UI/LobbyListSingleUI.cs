using System;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class LobbyListSingleUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI lobbyNameText;
    
    
    private Lobby lobby;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            KitchenGameLobby.Instance.JoinWithId(lobby.Id);
        });
    }

    public void SetLobby(Lobby lobby)
    {
        this.lobby = lobby;
        lobbyNameText.text = lobby.Name;
    }
}
