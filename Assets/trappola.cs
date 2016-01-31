using UnityEngine;
using System.Collections;

public class trappola : MonoBehaviour {
	Animator anim;
	public GameObject trigger;
	public GameObject topo;
	void Start(){
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag("Mouse")){
			anim.Play ("Scatto");
			Invoke ("Destroy", 0.5f);
			trigger.SetActive(false);
			trigger.GetComponent<playerFoundTopo>().attack = false;
		}
		if(other.CompareTag ("Player")){
			anim.Play ("Scatto");
			topo.GetComponent<TopoControllerScript>().chase = true;
		}



}

	void Destroy(){

		topo.SetActive (false);
	}
}
