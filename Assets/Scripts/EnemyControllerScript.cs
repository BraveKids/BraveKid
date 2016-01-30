using UnityEngine;
using System.Collections;

public class EnemyControllerScript : MonoBehaviour {
	public GameObject spriteLuce;
	public GameObject spriteBuio;
	bool chase;
	GameObject player;
	float moveSpeed = 2f;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (!chase) {
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, new Vector3 (player.transform.position.x - 2, player.transform.position.y, player.transform.position.z), Time.deltaTime * moveSpeed);
		}
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
		if(found == true){
			chase=true;
		}else {
			chase = false;
		}

}
}
