using UnityEngine;
using System.Collections;

public class soundListener : MonoBehaviour {
	float moveSpeed = 3f;
	public Transform flyPoint;
	public bool needParent = false;
	public bool ifSlowOK = true;
	public GameObject parent;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			if (!needParent) {
				if (ifSlowOK) {
					if (!other.GetComponent<CharacterControllerScript> ().isSlow ()) {
						other.GetComponent<CharacterControllerScript> ().canMove (false);
						other.GetComponent<CharacterControllerScript> ().GameOver ();
						gameObject.GetComponent<Animator> ().SetTrigger ("attack");
						gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, new Vector3 (other.transform.position.x, other.gameObject.transform.position.y, other.transform.position.z), Time.deltaTime * moveSpeed);

					}
				} else {

					other.GetComponent<CharacterControllerScript> ().canMove (false);
					other.GetComponent<CharacterControllerScript> ().GameOver ();
					gameObject.GetComponent<Animator> ().SetTrigger ("attack");
					gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, new Vector3 (other.transform.position.x, other.gameObject.transform.position.y, other.transform.position.z), Time.deltaTime * moveSpeed);
					}
			}else{
				flyPoint.position = new Vector3(other.transform.position.x-1,other.transform.position.y-1,other.transform.position.z-1);
				if (ifSlowOK) {
					if (!other.GetComponent<CharacterControllerScript> ().isSlow ()) {
						other.GetComponent<CharacterControllerScript> ().canMove (false);
						other.GetComponent<CharacterControllerScript> ().GameOver ();
						gameObject.GetComponent<Animator> ().SetTrigger ("attack");
						parent.gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, new Vector3 (other.transform.position.x, other.gameObject.transform.position.y, other.transform.position.z), Time.deltaTime * moveSpeed);
						
					}
				} else {

					other.GetComponent<CharacterControllerScript> ().canMove (false);
					other.GetComponent<CharacterControllerScript> ().GameOver ();
					gameObject.GetComponent<Animator> ().SetTrigger ("attack");
					parent.gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, new Vector3 (other.transform.position.x, other.gameObject.transform.position.y, other.transform.position.z), Time.deltaTime * moveSpeed);
					}
			}
		}
	}
}
