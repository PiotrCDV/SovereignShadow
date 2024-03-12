using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausemenu;
    public bool IsPaused;
    void Start()
    {
        pausemenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<Audio>().Stop();
            FindObjectOfType<Music>().Stop();
            if (IsPaused)
            {
                ResumeGame();
                FindObjectOfType<Music>().Play();
            }
            else 
            {
                PauseGame();
            }
        }
        
    }
    public void PauseGame()
    {
     pausemenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void ResumeGame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        FindObjectOfType<Music>().Play();
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("main_menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
