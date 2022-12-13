using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//FIND A WAY TO INTERACT WITH THE BUTTONS
//TIMED EVENT ????
//WIN STATE: MAKE THE PET HAPPY (SOME KIND OF BAR THAT GOES ALL THE WAY UP )

public class cameraKern : MonoBehaviour
{
    public Transform endPosition = null;

    [Header("Particle Systems")]
    public ParticleSystem foodParticleSystem;
    public ParticleSystem sleepParticleSystem;
    public ParticleSystem hygieneParticleSystem;
    public ParticleSystem gameParticleSystem;

    [Header("Audio Clips")]
    public AudioClip foodSound;
    public AudioClip sleepSound;
    public AudioClip hygieneSound;
    public AudioClip gameSound;

    public AudioClip successSound;


    bool canInteract = false;
    bool buttonsActive;

    /*public GameObject food;
    public GameObject sleep;
    public GameObject hygiene;
    public GameObject game;*/

    private int foodPressed = 0;
    private int sleepPressed = 0;
    private int hygienePressed = 0;
    private int gamePressed = 0;

    private bool allStatsActive = false; //whether or not all the 4 stats are active

    void Update()
    {
        if (!canInteract)
        {
            if (Input.anyKey)
            {
                canInteract = true; //PRESSING ANY KEY MAKES canInteract TRUE
            }
        }

        if (canInteract) // LERPS THE CAMERA TO THE POSITION
        {
            transform.position = Vector3.Lerp(transform.position, endPosition.position, Time.deltaTime*3);
            StartCoroutine(ButtonCoroutine());
        }

        if (foodPressed > 3 && sleepPressed > 3 && hygienePressed > 3 && gamePressed > 3)
        {
            allStatsActive = true;
        }
    }

    IEnumerator ButtonCoroutine()
    {
        AudioSource audio = GetComponent<AudioSource>();
        buttonsActive = false;
        yield return new WaitForSeconds(1);
        buttonsActive = true;
        if (buttonsActive)
        {
            if (Input.GetKeyDown(KeyCode.W)) //FOOD
            {
                foodParticleSystem.Play();

                audio.clip = foodSound;
                audio.Play();

                foodPressed += 1;
            }
            if (Input.GetKeyDown(KeyCode.A))//GAME
            {
                gameParticleSystem.Play();

                audio.clip = gameSound;
                audio.Play();

                gamePressed += 1;
            }
            if (Input.GetKeyDown(KeyCode.S))//HYGIENE
            {
                //hygiene.SetActive(true);
                hygieneParticleSystem.Play();

                audio.clip = hygieneSound;
                audio.Play();

                hygienePressed += 1;

            }
            if (Input.GetKeyDown(KeyCode.D))//SLEEP
            {
                //sleep.SetActive(true);
                sleepParticleSystem.Play();

                audio.clip = sleepSound;
                audio.Play();

                sleepPressed += 1;
            }
        }
        if (allStatsActive)
        {
            audio.clip = successSound;
            audio.Play();
            StartCoroutine(SceneEndCoroutine());
        }
    }
    IEnumerator SceneEndCoroutine() //ENDS THE SCENE IF ALL STATS ARE ACTIVE AND GOES TO NEXT ROOM
    {
        yield return new WaitForSeconds(2);
        int sceneToLoad = SceneManager.GetActiveScene().buildIndex + 1; //move to next scene

        if (sceneToLoad > SceneManager.sceneCountInBuildSettings - 1) //if you hit the last scene, go to title screen
            sceneToLoad = 0;

        SceneManager.LoadScene(sceneToLoad); //load the scene #

    }

}
