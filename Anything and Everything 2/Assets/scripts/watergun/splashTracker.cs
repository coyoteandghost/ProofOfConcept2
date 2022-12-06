using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splashTracker : MonoBehaviour
{
    [SerializeField] GameObject rat1;
    [SerializeField] GameObject rat2;
    [SerializeField] GameObject rat3;
    public GameObject sceneMan;

    void Update()
    {
        

        bool rat1Hit = rat1.GetComponent<neighbor>().hitTrack;
        bool rat2Hit = rat2.GetComponent<neighbor>().hitTrack;
        bool rat3Hit = rat3.GetComponent<neighbor>().hitTrack;

        if(rat1Hit && rat2Hit && rat3Hit)
        {
            sceneMan.GetComponent<RoomSwitch>().Switch();
        }
    }
}
