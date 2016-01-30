using UnityEngine;
using System.Collections;

public class EnemyTrigger : MonoBehaviour {
	public GameObject enemy;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			enemy.gameObject.SetActive(true);
			this.gameObject.SetActive(false);
		}
	}
}
