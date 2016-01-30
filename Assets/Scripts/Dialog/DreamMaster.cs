using UnityEngine;
using System.Collections;

public class DreamMaster : MonoBehaviour {

	bool used;
	void Start () {
	}

	void OnTriggerEnter2D (Collider2D other) {


		if (other.CompareTag ("Player") && !used) {
				
			transform.GetChild (0).GetComponent<dialogManager> ().Activate ();	//attivo il dialogo
				
			used = true;
			
		}
	}
}
