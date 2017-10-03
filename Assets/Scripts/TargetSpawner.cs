using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour {

	[SerializeField]
	private Vector3 spawnArea = new Vector3(1, 1, 1);

	[SerializeField]
	private int targetsToSpawn = 3;

	public static int totalTargets;

    [SerializeField]
    private float chanceOfMovement = 0.5f;

	[SerializeField]
	private GameObject movingTargetPrefab;

    [SerializeField]
    private GameObject stationaryTargetPrefab;

	// Update is called once per frame
	void Update () {
	
		// If the game has started AND there are zero targets...
		if (GameManager.gameStarted && totalTargets == 0) {

			// ...spawn new targets
			SpawnTargets();

		}


		// If the game has not started AND there are more than 0 targets...
		if (!GameManager.gameStarted && totalTargets > 0) {

			// ...destroy all targets.
			DestroyTargets();

		}

	}


	private void SpawnTargets() {

		if (totalTargets == 0) {

			float xMin = transform.position.x - spawnArea.x / 2f;
			float yMin = transform.position.y - spawnArea.y / 2f;
			float zMin = transform.position.z - spawnArea.z / 2f;
			float xMax = transform.position.x + spawnArea.x / 2f;
			float yMax = transform.position.y + spawnArea.y / 2f;
			float zMax = transform.position.z + spawnArea.z / 2f;

			for (int i = 0; i < targetsToSpawn; i++) {

				float positionX = Random.Range(xMin, xMax);
				float positionY = Random.Range(yMin, yMax);
				float positionZ = Random.Range(zMin, zMax);

                //Randomly spawn a stationary target or a moving target

                GameObject targetPrefab = (Random.Range(0f, 1f) >= chanceOfMovement) ? stationaryTargetPrefab : movingTargetPrefab;

				GameObject targetInstance = Instantiate(targetPrefab, new Vector3(positionX, positionY, positionZ), Quaternion.identity) as GameObject;

				totalTargets++;

			}

		}

	}


	private void DestroyTargets() {

		totalTargets = 0;

		GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
		for (int i = 0; i < targets.Length; i++) {

        //This will call the most overridden version of DestroyTarget()
		targets[i].GetComponent<Target>().DestroyTarget();

		}

	}


	void OnDrawGizmos() {

		Gizmos.color = Color.cyan;
		Gizmos.DrawWireCube(transform.position, spawnArea);

	}


}
