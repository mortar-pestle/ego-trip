using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System.Text;

public class OpenFile : MonoBehaviour
{
    AdsInterest dataAsJson;
    string dataAsString;
   [MenuItem("Example/Overwrite Texture")]
   public void OnClick()
   {
       Debug.Log("clicked");

       string folderPath = EditorUtility.OpenFolderPanel("Load Facebook data", "", "");

        Debug.Log(folderPath);

       string filePath = Path.Combine(folderPath + "/ads/advertisers_who_uploaded_a_contact_list_with_your_information.json");


       Debug.Log(filePath);
       if (filePath != null && filePath.Length != 0)
       {
           string fileContent = File.ReadAllText(filePath);
           Debug.Log(fileContent);

            //data = fileContent;
            dataAsJson = JsonUtility.FromJson<AdsInterest>(fileContent);
            dataAsString = dataAsJson.toString();
            Debug.Log(dataAsString);
       }
        else
        {
            dataAsString = "File not found! Please navigate to the right directory.";
            Debug.LogError(dataAsString);
        }
    }
    void OnGUI() {
        if(dataAsString != null)
        {
            GUI.Box(new Rect(100, 100, 300, int.MaxValue), dataAsString);
        }
      }
}
