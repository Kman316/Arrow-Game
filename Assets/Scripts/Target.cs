using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour, ITargetable {

    [SerializeField]
    protected GameObject impactParticles;

    protected AudioSource impactSounds;

	


   protected virtual void Start() {

        impactSounds = GetComponent<AudioSource>();

    }

    public virtual void DestroyTarget()
    {
        // Enable the rigidbody on the target to allow it to fall.
        GetComponent<Rigidbody>().isKinematic = false;

        // Turn off collisions to prevent double hits.
       GetComponent<Collider>().enabled = false;

        // Start to destroy this object.
        Destroy(gameObject, 1f);
    }

    public virtual void TargetReaction()
    {
        // Play an impact sound.
        impactSounds.Play();

        // Spawn hit particles.
        Instantiate(impactParticles, transform.position, Quaternion.identity);

        // Decrement the total number of targets.
        TargetSpawner.totalTargets--;

        // Add the target to the score.
        GameManager.score++;

        // Destroy the target
        DestroyTarget();
    }

}
