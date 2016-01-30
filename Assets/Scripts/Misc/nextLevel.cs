using UnityEngine;
using System.Collections;

public class nextLevel : MonoBehaviour
{

	void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.CompareTag ("Player")) {
			cameraManager.instance.cameraFade();
			SaveLoad.savedGame.firstGame=false;
			SaveLoad.savedGame.level++;
			SaveLoad.SaveGame(other.transform.position.x,other.transform.position.y);
		}
	}
}
