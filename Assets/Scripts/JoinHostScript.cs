using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JoinHostScript : MonoBehaviour
{
    public void OnMouseUp()
    {
        if (gameObject.tag == "Host Button")
        {
            SceneManager.LoadScene("MultiplayerLobby", LoadSceneMode.Single);
        }
    }
}
