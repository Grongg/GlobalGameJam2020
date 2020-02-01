using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    
    public void PlayGame() // Fonction that is attached to the PlayButton to load the game scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() // Fonction that is attached to QuitButton to quit game
    {
        Debug.Log("QUIT"); // log "Quit" to see that it's work in the unity creator
        Application.Quit(); // quit the game
    }

}
