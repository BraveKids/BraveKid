using UnityEngine;
using System.Collections;

public class BreakingGround : MonoBehaviour {
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Rock")){
			gameObject.SetActive(false);
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if(other.CompareTag("Player")){
			if(!player.GetComponent<CharacterControllerScript> ().isSlow ()){
				gameObject.SetActive(false);
				
			}
		}

	}
}
