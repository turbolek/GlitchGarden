using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	private GameObject defenderParent;
	private StarsDisplay starDisplay;
	private int defenderCost;
	private Defender selectedDefender;

	// Use this for initialization
	void Start () {
		defenderParent = GameObject.Find("Defenders");
		if (!defenderParent) {
			defenderParent = new GameObject("Defenders");
		}
		
		starDisplay = GameObject.FindObjectOfType<StarsDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown () {
		Vector2 worldPosition = CalculateWorldPointofMouseClick();
		Vector2 roundWorldPosition = SnapToGrid(worldPosition);
		selectedDefender = Button.selectedDefender.GetComponent<Defender>();
		defenderCost = selectedDefender.starCost;
		SpawnSelectedDefender(roundWorldPosition);
	}
	
	Vector2 CalculateWorldPointofMouseClick () {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPoint = myCamera.ScreenToWorldPoint(weirdTriplet);
		return worldPoint;
	}
	
	Vector2 SnapToGrid (Vector2 worldPosition) {
		float newX = Mathf.RoundToInt(worldPosition.x);
		float newY = Mathf.RoundToInt(worldPosition.y);
		return new Vector2(newX, newY);
	}
	
	void SpawnSelectedDefender (Vector2 position) {
		if (starDisplay.UseStars(defenderCost) == StarsDisplay.Status.SUCCESS) {
			Defender defender = Instantiate(selectedDefender, position, Quaternion.identity) as Defender;
			Debug.Log(defender);
			defender.transform.parent = defenderParent.transform;
			Debug.Log(defenderParent);
		}	
	}
}
