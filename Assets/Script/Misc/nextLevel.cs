using UnityEngine;
using System.Collections;

public class nextLevel : MonoBehaviour
{

	void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.CompareTag ("Player")) {
			Debug.Log("sbam");
			cameraManager.instance.cameraFade();
			SaveLoad.Save();
		}
	}
}
