using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class exitToMainMenu : MonoBehaviour
{
   public void MainMenuExit() 
    {
      SceneManager.LoadSceneAsync("main menu");
    }
}
