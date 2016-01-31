using UnityEngine;
using System.Collections;

public class Chasing : MonoBehaviour {
	public bool chasing;
	void OnTriggerEnter2D (Collider2D other)
	{		
		if (other.CompareTag ("Player")) {
			cameraManager.instance.setChasing(chasing);
		}
	}
}
