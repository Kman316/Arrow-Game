using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollision : MonoBehaviour {

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<ITargetable>() != null)
        {

            //Call TargetReaction() on the component that implements the ITargetable interface
            other.gameObject.GetComponent<ITargetable>().TargetReaction();

            //Stop the arrow from moving 
            GetComponent<Rigidbody>().isKinematic = true;

            //Parent the arrow to the target so that it's stuck on the target
            gameObject.transform.parent = other.transform;
        }
    }
}
