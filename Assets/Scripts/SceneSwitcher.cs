using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoMenuScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GotoMainScene()
    {
        SceneManager.LoadScene("TestScene");
    }
}