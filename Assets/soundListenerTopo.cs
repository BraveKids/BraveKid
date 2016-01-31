using UnityEngine;
using System.Collections;

public class soundListenerTopo : MonoBehaviour {
	public GameObject topo;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			if(player.GetComponent<CharacterControllerScript>().checkShout()){
				topo.GetComponent<TopoControllerScript>().chase = true;
			}
		}
	}
}
