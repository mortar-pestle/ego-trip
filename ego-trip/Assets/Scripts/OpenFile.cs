using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class OpenFile : MonoBehaviour
{
   [MenuItem("Example/Overwrite Texture")]
   public void OnClick()
   {
       Debug.Log("clicked");

       string path = EditorUtility.OpenFilePanel("Overwrite with json", "", "json");
       Debug.Log(path);
       if (path.Length != 0)
       {
           var fileContent = File.ReadAllText(path);
           Debug.Log(fileContent);
           Debug.Log(JsonUtility.FromJson<string>(fileContent));
       }

   }
}