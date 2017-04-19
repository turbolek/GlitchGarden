using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	private StarsDisplay starsDisplay;
	public int starCost = 100;
	
	void Start () {
		starsDisplay = GameObject.FindObjectOfType<StarsDisplay>();
	}

	public void AddStars (int starsAmount) {
		starsDisplay.AddStars(starsAmount);
	}
}
