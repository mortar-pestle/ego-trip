using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class OpenFile : MonoBehaviour
{
    string data = "JSON goes here";
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
           data = fileContent;
        //    data = JsonUtility.FromJson<string>(fileContent);
        //    Debug.Log(data);
       }
   }
    void OnGUI() {
        GUI.Box(new Rect(100, 100, 300, int.MaxValue), data);
      }
}
