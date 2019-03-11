using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SFB;

using UnityEngine.UI;
public class OpenFile : MonoBehaviour
{
    public Text info;
    AdsContactList dataAsJson;
    string dataAsString;
    private string _path;

    public void OnClick()
    {
        Debug.Log(_path);
        string filePath = Path.Combine(_path + "/ads/advertisers_who_uploaded_a_contact_list_with_your_information.json");

        Debug.Log(filePath);
        if (string.IsNullOrEmpty(filePath) && filePath.Length != 0)
        {
            string fileContent = File.ReadAllText(filePath);
            Debug.Log(fileContent);

            dataAsJson = JsonUtility.FromJson<AdsContactList>(fileContent);
            dataAsString = dataAsJson.toString();
            Debug.Log(dataAsString);
            dataAsString = dataAsJson.custom_audiences.Length + " businesses have your personal information.\n" + dataAsString;
            Debug.Log(dataAsJson.custom_audiences.Length);
            info.text = dataAsString;
        }
        else
        {
            dataAsString = "File not found! Please navigate to the right directory.";
            Debug.LogError(dataAsString);
        }
    }

    public void LoadAdsInterests()
    {
        string filePath = Path.Combine(_path + "/ads/ads_interests.json");

    }

    void OnGUI()
    {
        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        GUILayout.Space(20);
        GUILayout.BeginVertical();

        if (GUILayout.Button("Open Folder (O)") || Input.GetKeyDown("o"))
        {
            var paths = StandaloneFileBrowser.OpenFolderPanel("Select Folder", "", false);

            if (paths.Length == 0)
            {
                return;
            }
            _path = paths[0];
            OnClick();
        }

        if (!string.IsNullOrEmpty(_path) && GUILayout.Button("Ads Interests (I)") || Input.GetKeyDown("i"))
        {
            Debug.Log("This pres the button");
        }

        GUILayout.EndVertical();
        GUILayout.Space(20);
        GUILayout.Label(_path);
        GUILayout.EndHorizontal();
    }
}
