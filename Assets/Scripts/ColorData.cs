using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorData{

	[System.Serializable]
	public struct ColorSet
	{
		public float[] textColor;
		public float[] buttonColor;
	}

	public List<ColorSet> colours;
	
	public ColorData(){
		colours = new List<ColorSet>();
	}
	public Color GetColor(int index, string which){
		Color color = new Color();
		switch (which)
		{
			case "text":
				color.r = colours[index].textColor[0];
				color.g = colours[index].textColor[1];
				color.b = colours[index].textColor[2];
				color.a = colours[index].textColor[3];
				break;
			case "button":
				color.r = colours[index].buttonColor[0];
				color.g = colours[index].buttonColor[1];
				color.b = colours[index].buttonColor[2];
				color.a = colours[index].buttonColor[3];
				break;
			default:
			break;
		}
		return color;
	}

	public void AddColors(Color text, Color button){
		ColorSet newSet = new ColorSet();
		newSet.textColor = new float[4];
		newSet.buttonColor = new float[4];
		newSet.textColor[0] = text.r;
		newSet.textColor[1] = text.g;
		newSet.textColor[2] = text.b;
		newSet.textColor[3] = text.a;

		newSet.buttonColor[0] = button.r;
		newSet.buttonColor[1] = button.g;
		newSet.buttonColor[2] = button.b;
		newSet.buttonColor[3] = button.a;

		colours.Add(newSet);
	}
}
