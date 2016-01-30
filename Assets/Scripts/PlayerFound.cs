using UnityEngine;
using System.Collections;

public class PlayerFound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
		}
	}
}
