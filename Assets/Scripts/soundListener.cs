using UnityEngine;
using System.Collections;

public class soundListener : MonoBehaviour {
	float moveSpeed = 3f;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerStay2D(Collider2D other){
		if(other.CompareTag("Player")){
			if(!other.GetComponent<CharacterControllerScript>().isSlow()){
				other.GetComponent<CharacterControllerScript>().canMove(false);
				other.GetComponent<CharacterControllerScript>().GameOver();
				gameObject.GetComponent<SpriteRenderer>().color = Color.red;
				gameObject.GetComponent<Animator>().SetTrigger("attack");
				gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, new Vector3 (other.transform.position.x , other.gameObject.transform.position.y, other.transform.position.z), Time.deltaTime * moveSpeed);

			}
		}
	}
}
