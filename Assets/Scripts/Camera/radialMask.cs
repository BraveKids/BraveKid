using UnityEngine;
using System.Collections;

public class radialMask : MonoBehaviour {

	//TEXTURE SETTINGS
	static int texWidth = 1980  ;
	static int texHeight = 1020;
	
	//MASK SETTINGS
	static float maskThreshold = 2.0f;
	
	//REFERENCES
	static Texture2D mask;
	
	void Start(){
		GenerateTexture();    
	}
	
	public static Texture2D GenerateTexture(){
		
		mask = new Texture2D(texWidth, texHeight, TextureFormat.RGBA32, true);
		Vector2 maskCenter = new Vector2(texWidth * 0.5f, texHeight * 0.5f);
		
		for(int y = 0; y <texHeight; ++y){
			for(int x = 0; x < texWidth; ++x){
				
				float distFromCenter = Vector2.Distance(maskCenter, new Vector2(x, y));
				float maskPixel = (0.5f - (distFromCenter / texWidth)) * maskThreshold;
				mask.SetPixel(x, y, new Color(maskPixel, maskPixel, maskPixel, 1f));
			}
		}
		mask.Apply();
		Debug.Log(texWidth);
		
		return mask;
	}
}
