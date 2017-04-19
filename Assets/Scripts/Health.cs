using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0f) {
			DestroyObject();
		}
	}
	
	public void DealDamage(float damage) {
		health -= damage; 
	}
	
	void DestroyObject (){
		Destroy(gameObject);
	}
}
