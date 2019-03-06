using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class OpenFile : MonoBehaviour
{
    AdsInterest data;
   [MenuItem("Example/Overwrite Texture")]
   public void OnClick()
   {
       Debug.Log("clicked");

       string path = EditorUtility.OpenFilePanel("Overwrite with json", "", "json");
       Debug.Log(path);
       if (path.Length != 0)
       {
           string fileContent = File.ReadAllText(path);
           Debug.Log(fileContent);

            //data = fileContent;
            data = JsonUtility.FromJson<AdsInterest>(fileContent);
            Debug.Log(data.toString());
       }
   }
    void OnGUI() {
        if(data != null)
        {
            GUI.Box(new Rect(100, 100, 300, int.MaxValue), data.toString());
        }
      }
}
