using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void NextScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
