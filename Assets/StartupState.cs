using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
