using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenHandler : MonoBehaviour
{
    public void OnMouseUp ()
    {
        if (gameObject.tag == "StartGame")
        {
            SceneManager.LoadScene("MainBunkerScene", LoadSceneMode.Single);
        }
        else if (gameObject.tag == "ExitGame")
        {
            Application.Quit();
        }
    }
}
