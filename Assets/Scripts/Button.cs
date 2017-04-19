using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	private Text costText;
	private Button[] ButtonArray;
	public static GameObject selectedDefender;
	
	void Start () {
		ButtonArray = FindObjectsOfType<Button>();
		costText = GetComponentInChildren<Text>();
		costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
	}

	void OnMouseDown () {
		print (name + " pressed");
		foreach(Button thisButton in ButtonArray) {
			thisButton.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
		}
		gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
	}
}
