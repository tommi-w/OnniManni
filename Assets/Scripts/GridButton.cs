using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

[System.Serializable]
public class GridButtonEvent : UnityEvent<GridButton> {}
public class GridButton : MonoBehaviour {

	public TextMeshProUGUI text;
	public Image image;
	public GridButtonEvent onClicked;
	public AudioSource source;
	public Animal animal;
	public int displayIndex;
	public float coolDownTime = .5f;
	float lastPressed = 0;


	public void SetValues(Color imageColor, Color textColor, string textText, TMP_FontAsset textFont){
		text.text = textText;
		text.color = textColor;
		text.font = textFont;
		image.color = imageColor;
		displayIndex ++;
	}

	public void SetNewAnimal(Animal newAnimal){
		animal = newAnimal;
		image.sprite = null;
		displayIndex = 0;
	}

	public void ShowImage(){
		image.sprite = animal.animalImages[Random.Range(0,animal.animalImages.Count)];
		image.color = Color.white;
		text.text = "";
	}

	public void SaveColors(){
		GameControl.instance.colorData.AddColors(text.color,image.color);
	}

	public void PlaySound(){
		AudioClip clip = animal.animalSounds[Random.Range(0,animal.animalSounds.Count)];
		if(clip)
			source.PlayOneShot(clip);
	}

	public void Click(){
		if( Time.time - lastPressed >= coolDownTime){
			if (text.text == ""){
				PlaySound();
				lastPressed = Time.time;
			}
			else {
				onClicked.Invoke(this);
				PlaySound();
				lastPressed = Time.time;
			}
		}
	}
		

	
}
