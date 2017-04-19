using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarsDisplay : MonoBehaviour {

	private Text displayText;	
	private int currentStars = 100;
	public enum Status {SUCCESS, FAILURE};
	// Use this for initialization
	void Start () {
		displayText = GetComponent<Text>();
		UpdateDisplay();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void AddStars (int starsAmount) {
		currentStars += starsAmount;
		UpdateDisplay();
	}
	
	public Status UseStars (int starsAmount) {
		if (currentStars >= starsAmount) {
			currentStars -= starsAmount;
			UpdateDisplay();
			return Status.SUCCESS;
		} else {
			return Status.FAILURE;
		}
	}
	
	private void UpdateDisplay() {
		displayText.text = currentStars.ToString();
	}
}
