using UnityEngine;
using System.Collections;

public class Buffer : MonoBehaviour {

	public float buff;
	private Animator animator;
	private AttackerSpawner thisLaneSpawner;
	
	// Use this for initialization
	void Start () {
		animator = GameObject.FindObjectOfType<Animator>();
		SetThisLaneSpawner();
	}
	
	// Update is called once per frame
	void Update () {
		print (IsAttackerAheadInLane());
		if (IsAttackerAheadInLane()) {
			Debug.Log ("attacker in line");
			animator.SetBool("is attacking", true); 
		} else {
			Debug.Log ("No attacker in line");
			animator.SetBool("is attacking", false);
		}
	}
	
	private bool IsAttackerAheadInLane () {
		if (thisLaneSpawner.transform.childCount <= 0) {
			return false;
		}
		
		foreach (Transform attacker in thisLaneSpawner.transform) {
			if (attacker.transform.position.x >= transform.position.x) {
				return true;
			}
		}
		return false;
	}
	
	private void SetThisLaneSpawner () {
		AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
		foreach (AttackerSpawner spawner in spawners) {
			if (spawner.transform.position.y == transform.position.y) {
				thisLaneSpawner = spawner;
				print (thisLaneSpawner);
				return;
			} else {
				Debug.Log("Cant find spawner");
			}
		}
	} 
	
	void OnTriggerStay2D (Collider2D collider) {
		Attacker attacker = collider.GetComponent<Attacker>();
		if (attacker) {
			animator.SetTrigger ("under attack");
		}
	}
	
}
