using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using SFB;
using System.Collections;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    static string _path;

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void GotoMainScene()
    {
        OpenFile openFile = new OpenFile();
        bool isNull = openFile.OnSceneChanged();
        if (isNull)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

}