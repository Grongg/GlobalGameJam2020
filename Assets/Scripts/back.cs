using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{

    // Update is called once per frame
    public void GoBack()
    {
        Debug.Log("QUIT"); // log "Quit" to see that it's work in the unity creator
        Application.Quit(); // quit the game
    }
}
