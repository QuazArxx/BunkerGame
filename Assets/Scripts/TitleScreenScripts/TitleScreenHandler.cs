using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenHandler : MonoBehaviour
{
    public void OnMouseUp ()
    {
        switch (gameObject.tag)
        {
            case "StartGame":
                SceneManager.LoadScene("MultiplayerMenu", LoadSceneMode.Single);
                break;
            case "HowToPlay":
                SceneManager.LoadScene("HowToPlay", LoadSceneMode.Single);
                break;
            case "ExitGame":
                Application.Quit();
                break;
            default:
                Debug.Log("Something went wrong!");
                break;
        }
    }
}
