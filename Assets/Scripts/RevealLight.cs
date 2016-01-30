using UnityEngine;
using System.Collections;

public class RevealLight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Enemy")) {
			other.gameObject.GetComponent<EnemyControllerScript>().intoTheLight(true);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("Enemy")) {
			other.gameObject.GetComponent<EnemyControllerScript>().intoTheLight(false);
		}
	}

}
