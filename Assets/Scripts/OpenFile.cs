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

            string[] message = options.GetCustomMessage();
            info_Number.text = message[0];
            info.text = message[1];
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

    void OnGUI()
    {
        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        GUILayout.Space(20);
        GUILayout.BeginVertical();

        if (GUILayout.Button("Open Folder (O)"))
        {
            ExecuteFunctions(1);
        }

        if (!string.IsNullOrEmpty(_path) && GUILayout.Button("Ads Contact List (A)"))
        {
            ExecuteFunctions(2);
        }

        if (!string.IsNullOrEmpty(_path) && GUILayout.Button("Ads Interests (I)") || Input.GetKeyUp("i"))
        {
            ExecuteFunctions(3);
        }

        GUILayout.EndVertical();
        GUILayout.Space(20);
        GUILayout.Label(_path);
        GUILayout.EndHorizontal();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.O))
        {
            ExecuteFunctions(1);
        }

        if (!string.IsNullOrEmpty(_path) && Input.GetKeyUp(KeyCode.A))
        {
            ExecuteFunctions(2);
        }

        if (!string.IsNullOrEmpty(_path) && Input.GetKeyUp(KeyCode.I))
        {
            ExecuteFunctions(3);
        }
    }

    private void ExecuteFunctions(int function)
    {
        switch (function)
        {
            case 1:
                string[] paths = StandaloneFileBrowser.OpenFolderPanel("Select Folder", "", false);
                if (paths.Length <= 0 || string.IsNullOrEmpty(paths[0]))
                {
                    return;
                }
                _path = paths[0];
                LoadFile(LoadOptions.ADS_CONTACT_LIST, "/ads/advertisers_who_uploaded_a_contact_list_with_your_information.json");
                break;
            case 2:
                LoadFile(LoadOptions.ADS_CONTACT_LIST, "/ads/advertisers_who_uploaded_a_contact_list_with_your_information.json");
                break;
            case 3:
                LoadFile(LoadOptions.ADS_INTERESTS, "/ads/ads_interests.json");
                break;
            default:
                break;
        }
    }
}
