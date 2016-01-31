using UnityEngine;
using System.Collections;

public class TopoControllerScript : MonoBehaviour {
	public GameObject spriteLuce;
	public GameObject spriteBuio;
	public bool chase;
	bool facingRight = true;
	GameObject player;
	float moveSpeed = 2f;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
		if (chase) {
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, player.transform.position, Time.deltaTime * moveSpeed);

		}
	}
	
	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	public void intoTheLight(bool light){
		if (light == true) {
			spriteLuce.gameObject.SetActive (true);
			spriteBuio.gameObject.SetActive (false);
		} else {
			spriteLuce.gameObject.SetActive (false);
			spriteBuio.gameObject.SetActive (true);
		}
	}
	public void playerFound(bool found){
		if (found == true) {
			chase = true;
		} else {
			chase = false;
		}
	}
	public void Attack(){
		
		spriteLuce.gameObject.SetActive(false);
		spriteBuio.gameObject.SetActive (true);
		spriteBuio.GetComponent<Animator> ().SetBool ("attack", true);
	}
}




