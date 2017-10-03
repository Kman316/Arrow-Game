using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleProp : MonoBehaviour, ITargetable {

    [SerializeField]
    protected GameObject impactParticles;

    [SerializeField]
    protected AudioClip impactSound;

    public void TargetReaction()
    {
        //play impact sound
        AudioSource.PlayClipAtPoint(impactSound, gameObject.transform.position);

        //Spawn Particles
        Instantiate(impactParticles, transform.position, impactParticles.transform.rotation);

        //Destroy this object instantly
        Destroy(gameObject);
    }
}
