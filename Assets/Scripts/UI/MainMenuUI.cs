using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    void Start()
    {
        
    }        
    void Update()
    {
        
    }

   public void QuitGame()
    {
        Application.Quit();
    }

    public void OnStartClicked()
    {
        SceneManager.LoadScene(1);
    }
    
}
