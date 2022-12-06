using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomSwitch : MonoBehaviour
{
    public static RoomSwitch Instance;
    public Collider col;
    public bool switchCaseReached = false; //this bool must be set true in the room's script when microgame is fin.

    //private string currentScene = SceneManager.GetActiveScene().buildIndex;

    private void Awake()
    {
        Instance = this; 
    }

    private void OnTriggerEnter(Collider other)
    {
        switchCaseReached = true;
    }

    private void Update()
    {
        if (switchCaseReached)
        {
            Switch();
        }

        if (Input.GetKeyDown(KeyCode.R)) //press r to reset current room
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }


    public void Switch()
    {

        int sceneToLoad = SceneManager.GetActiveScene().buildIndex + 1; //move to next scene
         
        if (sceneToLoad > SceneManager.sceneCountInBuildSettings - 1) //if you hit the last scene, go to title screen
            sceneToLoad = 0;

        SceneManager.LoadScene(sceneToLoad); //load the scene #
        switchCaseReached = false;
    }
}
