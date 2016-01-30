using UnityEngine;
using System.Collections;

public class enlightHideSpot : MonoBehaviour {
	public GameObject enlightSprite;
	public GameObject normalSprite;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){

			enlightSprite.gameObject.SetActive(true);
			normalSprite.gameObject.SetActive(false);
		}
	}

		void OnTriggerExit2D(Collider2D other){
			if(other.CompareTag("Player")){
				enlightSprite.gameObject.SetActive(false);
				normalSprite.gameObject.SetActive(true);
			}
			}
}
