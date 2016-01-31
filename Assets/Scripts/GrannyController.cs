using UnityEngine;
using System.Collections;

public class GrannyController : MonoBehaviour {
	GameObject player;
	public GameObject light;
	public GameObject grannyBody;
	public bool awake;

	public Transform movePoint;

	float moveSpeed = 0.8f;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		awake = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (awake) {
				grannyBody.layer = 9;
				grannyBody.GetComponent<Animator> ().SetBool ("isSpotted", true);
				grannyBody.transform.position = Vector3.MoveTowards (grannyBody.transform.position, movePoint.position, Time.deltaTime * moveSpeed);
			}
		


	}

	void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			if(!player.GetComponent<CharacterControllerScript>().isSlow() || player.GetComponent<CharacterControllerScript>().checkShout()){
				light.SetActive(false);
				awake = true;

			}

		}
	}

}
