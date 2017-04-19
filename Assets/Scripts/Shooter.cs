using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	private GameObject projectilesParent;
	private Animator animator;
	private AttackerSpawner thisLaneSpawner;
	
	// Use this for initialization
	void Start () {
		projectilesParent = GameObject.Find("Projectiles");
		if (!projectilesParent) projectilesParent = new GameObject("Projectiles");
		
		animator = GameObject.FindObjectOfType<Animator>();
		
		SetThisLaneSpawner();
	}
	
	// Update is called once per frame
	void Update () {
		if (IsAttackerAheadInLane()) {
			animator.SetBool("is attacking", true); 
		} else {
			animator.SetBool("is attacking", false);
		}
	}
	
	private void Shoot () {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectilesParent.transform;
		newProjectile.transform.position = gun.transform.position;
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
			}
		}
	} 
	
}
