using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}