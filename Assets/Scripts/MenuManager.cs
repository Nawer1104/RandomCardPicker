using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPage;
    
    
    public void PlayGame()
    {
        Application.LoadLevel("Random");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
