using UnityEngine;
using System.Collections;

public class traviScript : MonoBehaviour {
	public GameObject traviSpezzate;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	void OnTriggerStay2D(Collider2D other){
		if(other.CompareTag("Player")){
			if(!player.GetComponent<CharacterControllerScript> ().isSlow ()){
				gameObject.GetComponent<SpriteRenderer>().enabled = false;
				traviSpezzate.SetActive(true);
				gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
				
			}
		}
		
	}

}
