using UnityEngine;
using System.Collections;

public class RevealLight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {

		if (other.CompareTag ("Enemy")) {
			other.gameObject.GetComponent<EnemyControllerScript> ().intoTheLight (true);
		}
		if (other.CompareTag ("Mouse")) {
			other.gameObject.GetComponent<TopoControllerScript> ().intoTheLight (true);
		}
		if (other.CompareTag ("Piccione")) {
			other.gameObject.GetComponent<PiccioneChange> ().intoTheLight (true);
		}
		if (other.CompareTag ("Player")) {
			other.GetComponent<CharacterControllerScript> ().setUnderLight (true);
		}
        if (other.CompareTag("Spectre")) {
            Destroy(other.gameObject);
        }

	}

	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("Enemy")) {
			other.gameObject.GetComponent<EnemyControllerScript>().intoTheLight(false);
		}
		if (other.CompareTag ("Player")) {
			other.GetComponent<CharacterControllerScript> ().setUnderLight (false);
		}
		if (other.CompareTag ("Piccione")) {
			other.gameObject.GetComponent<PiccioneChange> ().intoTheLight (false);
		}
		if (other.CompareTag ("Mouse")) {
			other.gameObject.GetComponent<TopoControllerScript> ().intoTheLight (false);
		}
	}

}
