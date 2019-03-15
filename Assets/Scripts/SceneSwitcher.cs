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
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");
        OpenFile openFile = new OpenFile();
        openFile.OnSceneChanged();

        while (asyncLoad.isDone)
        {
            // string[] paths = StandaloneFileBrowser.OpenFolderPanel("Select Folder", "", false);
            // if (paths.Length <= 0 || string.IsNullOrEmpty(paths[0]))
            // {
            //     return;
            // }
            // else
            // {
            //     _path = paths[0];
            //     LoadFile(LoadOptions.ADS_CONTACT_LIST, "/ads/advertisers_who_uploaded_a_contact_list_with_your_information.json");
            // }
            // string filePath = Path.Combine(paths[0] + "/ads/advertisers_who_uploaded_a_contact_list_with_your_information.json");
            // Debug.Log("AHAHA");
            // Debug.Log(filePath);
            // Debug.Log("AHAHA");

        }
    }

}