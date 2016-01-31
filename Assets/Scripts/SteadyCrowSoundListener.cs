using UnityEngine;
using System.Collections;

public class SteadyCrowSoundListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (!other.GetComponent<CharacterControllerScript>().isSlow()) {
                other.GetComponent<CharacterControllerScript>().canMove(false);
                other.GetComponent<CharacterControllerScript>().GameOver();
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                gameObject.GetComponent<Animator>().SetBool("isSpotted", true);
            }
        }
    }
}
