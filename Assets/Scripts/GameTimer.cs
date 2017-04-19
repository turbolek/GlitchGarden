using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	private float timeLimit = 180;
	private float time = 0;
	private bool gameOver = false;
	private Slider slider;
	private LevelManager levelManager;
	private AudioSource audioSource;
	private GameObject winLabel;
	private AttackerSpawner[] spawners;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		slider = gameObject.GetComponent<Slider>();
		slider.value = 0;
		slider.maxValue = timeLimit;
		audioSource = GetComponent<AudioSource>();
		winLabel = GameObject.Find("You Win");
		winLabel.SetActive(false);
		spawners = GameObject.FindObjectsOfType<AttackerSpawner>();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		slider.value = time;
		if (time >= timeLimit && !gameOver) {
			Win ();
		}
	}
	
	void DestroySpawners () {
			for (int i = 0; i < spawners.Length; i++) {
					Destroy(spawners[i].gameObject);
			}
	}
		
	void Win () {
		gameOver = true;
		audioSource.Play();
		DestroySpawners();
		winLabel.SetActive(true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
	}
	
	void LoadNextLevel() {
		levelManager.LoadNextLevel();
	}
}
