using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AttackerSpawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;
	private GameTimer gameTimer;
	private float spawnRateMultiplier = 1f;

	// Use this for initialization
	void Start () {
		gameTimer = GameObject.FindObjectOfType<GameTimer>();
		
	}
	
	// Update is called once per frame
	void Update () {
		spawnRateMultiplier = getSpawnRateMultiplier();
		foreach (GameObject thisAttacker in attackerPrefabArray) {
			if (isTimeToSpawn(thisAttacker)) {
				Spawn(thisAttacker);
			}
		}
	}
	
	void Spawn (GameObject attacker) {
		GameObject newAttacker = Instantiate(attacker, this.transform.position, Quaternion.identity) as GameObject;
		newAttacker.transform.parent = transform;
	}
	
	bool isTimeToSpawn (GameObject attacker) {	 
		float spawnRatio = attacker.GetComponent<Attacker>().spawnRatio;
		float treshold = spawnRatio * spawnRateMultiplier * Time.deltaTime;
		if (Random.value < treshold) {
			return true;
		} else {
			return false;
		}
	}
	
	float getSpawnRateMultiplier () {
		float currentTime = gameTimer.GetComponent<Slider>().value;
		return (1 + Mathf.Pow(PlayerPrefsManager.GetDifficulty() * currentTime/120f, PlayerPrefsManager.GetDifficulty()/2f));
	}
}
