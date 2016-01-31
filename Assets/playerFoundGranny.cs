using UnityEngine;
using System.Collections;

public class playerFoundGranny : MonoBehaviour {
	GameObject player;
	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){

			player.GetComponent<CharacterControllerScript>().canMove(false);
			player.GetComponent<Rigidbody2D>().isKinematic = true;
			player.GetComponent<CharacterControllerScript>().GameOver();
			//enemy.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
			
			
		}
	}
}
