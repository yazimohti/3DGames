using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
   void Update()
    {
       if(Input.GetKeyUp(KeyCode.Escape))
       {
            Debug.Log("Quit the game");
            Application.Quit();
       } 
    }
}
