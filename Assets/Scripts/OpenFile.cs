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


        Debug.Log("clicked");
        string folderPath = _path;

        Debug.Log(folderPath);

        string filePath = Path.Combine(folderPath + "/ads/advertisers_who_uploaded_a_contact_list_with_your_information.json");


        Debug.Log(filePath);
        if (filePath != null && filePath.Length != 0)
        {
            string fileContent = File.ReadAllText(filePath);
            Debug.Log(fileContent);

            //data = fileContent;
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

    void OnGUI()
    {
        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        GUILayout.Space(20);
        GUILayout.BeginVertical();

        if (GUILayout.Button("Open File Directory") || Input.GetKeyDown("o"))
        {
            var paths = StandaloneFileBrowser.OpenFolderPanel("Select Folder", "", false);

            if (paths.Length == 0)
            {
                return;
            }
            _path = paths[0];
            OnClick();
        }

        GUILayout.EndVertical();
        GUILayout.Space(20);
        GUILayout.Label(_path);
        GUILayout.EndHorizontal();
    }
}
