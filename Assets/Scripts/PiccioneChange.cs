using UnityEngine;
using System.Collections;

public class PiccioneChange : MonoBehaviour {
	public GameObject spriteLuce;
	public GameObject spriteBuio;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
}
