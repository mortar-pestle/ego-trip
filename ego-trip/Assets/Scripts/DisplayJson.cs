using UnityEngine;
using System;
 
class DisplayJson : MonoBehaviour
{
  string data = "test";
  void OnGUI() {
        GUI.Box(new Rect(100, 100, 300, int.MaxValue), data);
      }
}