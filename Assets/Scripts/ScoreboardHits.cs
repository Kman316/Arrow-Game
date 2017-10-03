using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardHits : MonoBehaviour, ITargetable {

    [SerializeField]
    private AudioClip impactSound;

    [SerializeField]
    private AudioClip destructionSound;

    [SerializeField]
    private GameObject destructionParticles;

    private int arrowHits = 0;


    public void TargetReaction()
    {
        //Play an impact sound
        AudioSource.PlayClipAtPoint(impactSound, gameObject.transform.position);

        //Increment arrow hits counter by 1 each time the target is hit
        arrowHits++;

        //If the scoreboard has been hit 3 times or more..
        if(arrowHits >= 3)
        {
            //Play a destruction sound
            AudioSource.PlayClipAtPoint(destructionSound, gameObject.transform.position);

            //Spawn Particles
            Instantiate(destructionParticles, transform.position, destructionParticles.transform.rotation);

            //Reset the arrow hits counter
            arrowHits = 0;
        }
    }
}
