using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {
	public GameObject parent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.isTrigger != true) {
			Invoke ("DestroyProjectile", 0.2f);


		}
	}

	void DestroyProjectile(){
		GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerScript>().canMove(true);
		parent.SetActive(false);
	}
}
