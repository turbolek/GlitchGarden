using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour {

	public float fadeInTime;
	
	private Image fadePanel;
	private Color currentColor = Color.black;
	
	
	void Start () {
		fadePanel = GetComponent<Image>();
		currentColor.a = 1; 
	}

	void Update () {
		if (Time.timeSinceLevelLoad < fadeInTime) {
			float alpaChange = Time.deltaTime / fadeInTime;
			currentColor.a -= alpaChange;
			fadePanel.color = currentColor;
		} else { 
			gameObject.SetActive(false);
		}
	}

}
