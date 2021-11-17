using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class JoinHostManager : MonoBehaviour
{
    public Text joinOrHost;
    public GameObject[] playerPrefab;

    int players = 0;
    int playerLimit = 6;

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            StartButtons();
            joinOrHost.text = "Are you hosting or joining?";
        }
        else
        {
            StatusLabels();
            joinOrHost.text = "";
        }

        GUILayout.EndArea();
    }

    void StartButtons()
    {
        if (GUILayout.Button("Host"))
        {
            NetworkManager.Singleton.StartHost();
            SpawnPlayer();
        }

        if (GUILayout.Button("Join"))
        {
            NetworkManager.Singleton.StartClient();
            if (players < playerLimit)
            {
                SpawnPlayer();
            }
        }
    }

    void StatusLabels()
    {
        var mode = NetworkManager.Singleton.IsHost ?
            "Host" : NetworkManager.Singleton.IsServer ? "Server" : "Client";

        GUILayout.Label($"Transport: {NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name}");
        GUILayout.Label($"Mode: {mode}");
    }

    void SpawnPlayer()
    {
        NetworkManager.Instantiate(playerPrefab[Random.Range(0, playerPrefab.Length)]);
        players++;
    }
}
