using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCanvas : MonoBehaviour
{
    public GameObject Panel;
    public void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Panel.SetActive (false);
            Debug.Log("False");
        } 
        else if (Input.GetKeyDown(KeyCode.B)){
            Panel.SetActive (true);
            Debug.Log("True");
        }
    }
}
