using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonGridUI : MonoBehaviour {

	public bool useNames;
	public Transform content;
	public GridButton gridButtonPrefab;
	public  List<GridButton> gridButtons;
	// Use this for initialization
	void Start () {
		gridButtons = new List<GridButton>();
		if(content){
			//GridButton newButton;
			for (int i = 0; i < 12; i++)
			{
				//Debug.Log("Creating button "+i);
				GridButton newButton = Instantiate(gridButtonPrefab,content);
				newButton.onClicked.AddListener(UpdateButtonValues);
				gridButtons.Add(newButton);
				UpdateButtonValues(newButton);
			}
		}
	}

	public void RefreshButtons(){
		for (int i = 0; i < gridButtons.Count; i++)
		{
			gridButtons[i].text.text = "";
			UpdateButtonValues(gridButtons[i]);
		}
	}

	void UpdateButtonValues(GridButton button){
		Color imageColor = Color.red;
		Color textColor = Color.blue;
		string text = "T";
		TMP_FontAsset randFont = button.text.font;
		if(GameControl.instance.colorData.colours.Count>0){
			int randInt = Random.Range(0,GameControl.instance.colorData.colours.Count);
			imageColor = GameControl.instance.colorData.GetColor(randInt,"button");
			textColor = GameControl.instance.colorData.GetColor(randInt,"text");
		}
		if(button.text.text == ""){ // create new
			button.SetNewAnimal(GetNewAnimal());
			randFont = GameControl.instance.fonts[Random.Range(0,GameControl.instance.fonts.Count)];
			if(useNames)
				text = button.animal.name.ToCharArray()[0].ToString();
			else
				text = Random.Range(1,10).ToString();
			button.SetValues(imageColor,textColor,text,randFont);
		} else if (button.text.text == "1" || (useNames && button.displayIndex == button.animal.name.Length)){ // show image only
			button.ShowImage();
		} else {
			if(useNames)
				text = button.animal.name.ToCharArray()[button.displayIndex].ToString();
			else
				text = (int.Parse(button.text.text)-1).ToString();
			button.SetValues(imageColor,textColor,text,randFont);
		}
		//Debug.Log("Button values set");
	}

	Animal GetNewAnimal(){
		Animal newAnimal = GameControl.instance.animals[0].animals[0];
		//Debug.Log("setting up new animal");
		bool yes = false;
		List<Animal> usedAnimals = new List<Animal>();
		for (int i = 0; i < gridButtons.Count; i++)
			{
				usedAnimals.Add(gridButtons[i].animal);
			}
		newAnimal = GameControl.instance.animals[0].animals[Random.Range(0,GameControl.instance.animals[0].animals.Count)];
		int counter = 0;
		while (!yes || counter <10)
		{
			newAnimal = GameControl.instance.animals[0].animals[Random.Range(0,GameControl.instance.animals[0].animals.Count)];
			if (!usedAnimals.Contains(newAnimal))
				yes = true;
			counter ++;
		}
		//Debug.Log("animal set");
		return newAnimal;
	}
}
