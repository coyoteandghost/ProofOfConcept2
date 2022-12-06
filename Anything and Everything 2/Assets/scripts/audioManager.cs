using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    
    public AudioSource bgMusic;

    private static audioManager instance = null;
    public static audioManager Instance
    {
        get
        {
            return instance;
        }
    }


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }        

        DontDestroyOnLoad(gameObject);

    }

    void Update()
    {
        
    }
}
