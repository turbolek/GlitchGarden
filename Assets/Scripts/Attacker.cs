using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	public float spawnRatio;
	public float speedBuff;
	[Range (-1f, 1.5f)]
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;
	private float difficulty;
	private Buffer thisLaneBuffer;
	// Use this for initialization
	void Start () { 
		animator = GetComponent<Animator>();
		difficulty = PlayerPrefsManager.GetDifficulty();
		spawnRatio /= difficulty;
		speedBuff = 1;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool ("is attacking", false);
		}
		
		if (IsBufferAheadInLane()) {
			speedBuff = 0.66f;
		} else {
			speedBuff = 1f;
		}
		
	}
	
	void OnTriggerEnter2D () {
	}
	
	public void setSpeed (float speed) {
		currentSpeed = speed * speedBuff;
	}
	
	void StrikeCurrentTarget (float damage) {
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			if (health) {
				health.DealDamage(damage);
			}
		} 
	}
	
	public void Attack (GameObject obj) {
		currentTarget = obj;
	}
	
	private bool IsBufferAheadInLane () {
		Buffer[] buffers = FindObjectsOfType<Buffer>();
		foreach (Buffer buffer in buffers) {
			if (buffer.transform.position.y == transform.position.y) {
				if (buffer.transform.position.x <= transform.position.x) {
					return true;
				}
			}  
		}
		return false;
	}
	
}