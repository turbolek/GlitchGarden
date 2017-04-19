using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Chicken : MonoBehaviour {
	
	private Animator animator;
	private Attacker attacker;
	public GameObject eggPrefab;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D (Collider2D collider){
		
		GameObject obj = collider.gameObject;
		if (!obj.GetComponent<Defender>()) {
			return;
		}

			animator.SetBool ("is attacking", true);
			attacker.Attack(obj);
	}
	
	void LayEgg () {
		GameObject newEgg = Instantiate (eggPrefab) as GameObject;
		newEgg.transform.position = transform.position;
	}
}

