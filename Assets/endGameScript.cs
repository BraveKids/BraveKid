using UnityEngine;
using System.Collections;

public class endGameScript : MonoBehaviour {
	public GameObject doppleganger;
	public GameObject credits;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			other.GetComponentInChildren<Rigidbody2D>().velocity = new Vector2(0f,0f);
			other.GetComponent<CharacterControllerScript>().canMove(false);
			other.GetComponent<CharacterControllerScript>().fantasyArmorIdle.SetActive(true);
			other.GetComponent<CharacterControllerScript>().fantasyArmorWalking.SetActive(false);
			other.GetComponentInChildren<Animator>().Play("kidSmile");
			doppleganger.GetComponent<Animator>().Play ("kidSmile");
			credits.SetActive(true);
		}
}
}
