using UnityEngine;
using System.Collections;

public class MovingTarget : Target {

	[SerializeField]
	private float amplitude = 1f;

	[SerializeField]
	private float timePeriod = 1f;

	private Vector3 startPosition;

    private bool moving = true;

	// Use this for initialization
	protected override void Start () {

        base.Start();

		// Store the start position
		startPosition = transform.localPosition;

	}
	

	void LateUpdate () {

        if (moving)
        {
            // Calculate theta
            float theta = Mathf.Sin(Time.timeSinceLevelLoad / timePeriod);

            // Create the new delta position
            Vector3 deltaPosition = new Vector3(amplitude, 0f, 0f) * theta;

            // Update the position by adding the start position and delta position
            transform.localPosition = startPosition + deltaPosition;
        }
	}

    public override void DestroyTarget()
    {
        //Disable target movement
        moving = false;
        base.DestroyTarget();
    }

    public override void TargetReaction()
    {
        //Disable target movement
        moving = false; 

        base.TargetReaction();
    }
}
