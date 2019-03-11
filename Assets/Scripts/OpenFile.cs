using UnityEngine;
using System.IO;
using SFB;

using UnityEngine.UI;
public class OpenFile : MonoBehaviour
{
    public Text info;
    public Text info2;
    public Text info3;
    public Text info4;
    public Text info5;
    public Text info6;
    public Text info7;
    public Text info8;

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

            info.text = options.GetCustomMessage();
            info2.text = dataAsString;
            info3.text = dataAsString;
            info4.text = dataAsString;
            info5.text = dataAsString;
            info6.text = dataAsString;
            info7.text = dataAsString;
            info8.text = dataAsString;
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
