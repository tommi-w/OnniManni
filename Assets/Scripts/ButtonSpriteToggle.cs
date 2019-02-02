using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpriteToggle : MonoBehaviour {

	public Image targetImage;

	public Sprite primarySprite;

	public Sprite secondarySprite;

	public bool reverseAfter = false;

	public float seconds = 1f;

	bool interactable = true;

	bool isPrimary = true;

	public void ToggleSprite(){
		if(interactable){
			if(isPrimary){
				isPrimary = !isPrimary;
				targetImage.sprite = secondarySprite;
			}
			else {
				isPrimary = !isPrimary;
				targetImage.sprite = primarySprite;
			}
			if (reverseAfter){
				StartCoroutine("ReverseToggle");
			}
		}
	}

	private IEnumerator ReverseToggle(){
		interactable = false;
		yield return new WaitForSeconds(seconds);
		if(isPrimary){
			isPrimary = !isPrimary;
			targetImage.sprite = secondarySprite;
		}
		else {
			isPrimary = !isPrimary;
			targetImage.sprite = primarySprite;
		}
		interactable = true;
	}
}
