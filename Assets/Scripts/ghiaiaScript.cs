using UnityEngine;
using System.Collections;

public class ghiaiaScript : MonoBehaviour {
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	void OnTriggerStay2D(Collider2D other){
		if(other.CompareTag("Rock")){
			gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			if(!player.GetComponent<CharacterControllerScript> ().isSlow ()){
				gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
				
			}
		}
		
	}
}
