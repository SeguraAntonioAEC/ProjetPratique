using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    private bool m_isShowingMenu;
   [SerializeField] private GameObject m_pauseMenuCanvas;

    private void Start()
    {
        m_isShowingMenu = false;        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && m_isShowingMenu == false)
        {
            ShowMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && m_isShowingMenu == true)
        {
            ResumeGame();
        }
    }
    public void ResumeGame()
    {
        HideMenu();
        m_isShowingMenu = false;
        Time.timeScale = 1;
    }

    public void SaveGame()
    {

    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void HideMenu()
    {
        m_pauseMenuCanvas.gameObject.SetActive(false);
    }

    public void ShowMenu()
    {
        Time.timeScale = 0;
        m_isShowingMenu = true;
        m_pauseMenuCanvas.gameObject.SetActive(false);
    }   
}
