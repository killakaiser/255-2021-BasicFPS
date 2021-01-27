using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform doorArt;

    

    //The angle of the door in degrees.
    private float doorAngle = 0;

    public float animLength = .5f;
    private float animTimer = 0;
    private bool animIsPlaying = false;

    private bool isClosed = true;


    void Start()
    {
       
    }


    void Update()
    {

        
        

        // play the animation
        if (animIsPlaying) {
            if (!isClosed)
                animTimer += Time.deltaTime; // playing the animation
            else
                animTimer -= Time.deltaTime;

            float percent = animTimer / animLength;

            if (percent < 0 && isClosed) {
                percent = 0;
                animIsPlaying = false;
            }
            if (percent > 1 && !isClosed) {
                percent = 1;
                animIsPlaying = false;
            }

            doorArt.localRotation = Quaternion.Euler(0, doorAngle * percent, 0); // set the angle of doorArtS

        }

    }

    public void PlayerInteract(Vector3 position)
    {
        if(animIsPlaying) return; // do nothing

        if (!Inventory.main.hasKey == false) return; //do nothing

        Vector3 disToPlayer = position - transform.position;
        disToPlayer = disToPlayer.normalized;

        bool playerOnOtherSide = (Vector3.Dot(disToPlayer, transform.forward) > 0f);

        isClosed = !isClosed; // toggles state

        if (!isClosed)
        {
            doorAngle = 90;
            if (playerOnOtherSide) doorAngle = -90;
        }
        animIsPlaying = true;

        //sets playhead to end (or beginning)
        if (isClosed) animTimer = animLength;
        else animTimer = 0;
    }

}
