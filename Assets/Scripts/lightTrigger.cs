using UnityEngine;
using System.Collections;

public class lightTrigger : MonoBehaviour {
	GameObject player;
	public GameObject light;
	bool isInRange;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		isInRange = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<CharacterControllerScript> ().checkInteract () && isInRange) {
			player.GetComponent<CharacterControllerScript> ().setInteract(false);
			if(light.gameObject.activeSelf ==false){
			light.gameObject.SetActive(true);
			}else{
				light.gameObject.SetActive(false);
			}

			
		}
	}
	
	void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			isInRange = true;
			gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
			player.GetComponent<CharacterControllerScript> ().canInteract(true);
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			isInRange = false;
			gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
			player.GetComponent<CharacterControllerScript> ().canInteract(false);
		}
	}
	
}


