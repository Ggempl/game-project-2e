using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource ButtonSound;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }
    public void PlayCredits()
    {
        SceneManager.LoadSceneAsync("credits");
    }
    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
    public void PlaySoundButton()
    {
        ButtonSound.Play();

    }
    public void CreditsSoundButton()
    {
        ButtonSound.Play();
    }
}