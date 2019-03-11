using UnityEngine;
using System.IO;
using SFB;

using UnityEngine.UI;
public class OpenFile : MonoBehaviour
{
    public Text info;
    public Text info_Number;
    public Text info2;
    public Text info3;

    string dataAsString;
    private string _path;

    public void LoadFile(int option, string file)
    {
        Debug.Log(_path);
        string filePath = Path.Combine(_path + file);

        Debug.Log(filePath);
        if (!string.IsNullOrEmpty(filePath) && filePath.Length != 0)
        {
            string fileContent = File.ReadAllText(filePath);
            Debug.Log(fileContent);
            LoadOptions options = new LoadOptions(option);

            dataAsString = options.GetData(fileContent);
            Debug.Log(dataAsString);

            string[] message = options.GetCustomMessage();
            info_Number.text = message[0];
            info.text = message[1];
            info2.text = dataAsString;
            info3.text = dataAsString;
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

        if (GUILayout.Button("Open Folder (O)") || Input.GetKeyDown("o"))
        {
            var paths = StandaloneFileBrowser.OpenFolderPanel("Select Folder", "", false);
            Debug.Log(paths.Length);
            Debug.Log(paths[0]);
            Debug.Log("ends");
            if (paths.Length <= 0 || string.IsNullOrEmpty(paths[0]))
            {
                return;
            }
            _path = paths[0];
            LoadFile(LoadOptions.ADS_CONTACT_LIST, "/ads/advertisers_who_uploaded_a_contact_list_with_your_information.json");
        }

        if (!string.IsNullOrEmpty(_path) && GUILayout.Button("Ads Contact List (A)") || Input.GetKeyDown("a"))
        {
            LoadFile(LoadOptions.ADS_CONTACT_LIST, "/ads/advertisers_who_uploaded_a_contact_list_with_your_information.json");
        }

        if (!string.IsNullOrEmpty(_path) && GUILayout.Button("Ads Interests (I)") || Input.GetKeyDown("i"))
        {
            LoadFile(LoadOptions.ADS_INTERESTS, "/ads/ads_interests.json");
        }

        GUILayout.EndVertical();
        GUILayout.Space(20);
        GUILayout.Label(_path);
        GUILayout.EndHorizontal();
    }
}
