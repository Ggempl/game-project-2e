using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject PausePanel;
    public string objectTag = "Enemy";
    // Start is called before the first frame update
    void Start()
    {
        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        isPaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        isPaused = false;
    }
}
