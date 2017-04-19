using UnityEngine;
using System.Collections;

public class LoseTrigger : MonoBehaviour {

	private LevelManager levelManager;
	private AudioSource audioSource;
	private GameObject loseLabel;
	private bool gameOver;

	void Start () {
		gameOver = false;
		levelManager = FindObjectOfType<LevelManager>();
		audioSource = GetComponent<AudioSource>();
		loseLabel = GameObject.Find("You Lose");
		loseLabel.SetActive(false);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.GetComponent<Attacker>() && !gameOver) {
			gameOver = true;
			Lose();
		}
		Destroy (collider.gameObject);
	}
	
	private void Lose() {
		audioSource.Play ();
		loseLabel.SetActive(true);
		Invoke ("LoadLoseLevel", audioSource.clip.length);
	}
	
	void LoadLoseLevel() {
		levelManager.LoadLevel("03b Lose");
	}
}
