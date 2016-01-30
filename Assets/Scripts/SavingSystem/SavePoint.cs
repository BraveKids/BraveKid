using UnityEngine;
using System.Collections;

public class SavePoint : MonoBehaviour {

	private bool usable = true;
	private bool onNewLevel = false;
	string id;
	public bool save;
	Animator anim;
	void Start () {
	

	}

	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.CompareTag ("Player") && usable) {

			if(!save && usable){
				anim.Play("checkpoint");
			}

			usable = false;
			setColor ();

			Debug.Log ("salvando");

				
		}		
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.CompareTag ("Player")) {		

			if (other.transform.position.x >= transform.position.x && !onNewLevel) {
				//in case he's coming from a level change and is running
				onNewLevel = true;

			}
		}
	}

	void setColor () {
		SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();

		if (usable) {
			renderer.color = new Color (0f, 1f, 0f, 1f);
		} else {
			renderer.color = new Color (1f, 0f, 0f, 1f);
		}
	}
}
