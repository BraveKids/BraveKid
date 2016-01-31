using UnityEngine;
using System.Collections;

public class piccioneSprite : MonoBehaviour {
	public Transform point;
	bool flyAway=false;
	float moveSpeed = 3f;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		if (flyAway) {
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, point.position, Time.deltaTime * moveSpeed);
			gameObject.GetComponentInChildren<Animator>().SetTrigger("attack");
			Invoke ("Destroy", 4f);
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			if(other.GetComponent<CharacterControllerScript>().checkShout()){
				flyAway = true;
			}

		}
	}

	void Destroy(){
		gameObject.SetActive (false);
	}

}
