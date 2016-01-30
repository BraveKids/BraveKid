using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {
	public GameObject parent;
	public Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.isTrigger != true) {
			GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerScript>().canMove();
			target.GetComponentInChildren<SpriteRenderer>().enabled = false;
			parent.SetActive(false);

		}
	}
}
