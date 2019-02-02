using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;
using UnityEngine.Events;
public class GameControl : MonoBehaviour {
	public static GameControl instance;
    public ColorData colorData;
    public List<TMP_FontAsset> fonts;
    public List<AnimalCollection> animals;

	public UnityEvent OnBackButton;

	private void Update() {
		if(Input.GetKeyUp(KeyCode.Escape)){
			ReturnToMainMenu();
		}
	}
	
	//Makes this object the only GameControl object in the game
	void Awake () {
        if (instance == null) {
                DontDestroyOnLoad (gameObject);
                instance = this;
        } else if (instance != this) {
                Destroy (gameObject);
        }
        Load ();
    }


	public void Save()
	{
		//ButtonGridUI.gridButtons[0].SaveColors();

		Debug.Log("PersistenDataPAth "+Application.persistentDataPath);
		
		string savePath = Application.dataPath + "/Resources/colors.json";
		Debug.Log("SAVING TO "+savePath);
		ColorData data = new ColorData ();

		data = colorData;

		File.WriteAllText(savePath,JsonUtility.ToJson(data,true));
		
	}

	public void Load()
	{
		string json = "";
		string path = Application.dataPath + "/Resources/colores.json";
		if (File.Exists (path)) {
				Debug.Log("FOUND COLORS FILE");

				StreamReader file = File.OpenText(path);
				json = file.ReadToEnd();
				//Debug.Log("json: "+ json);
				JsonUtility.FromJsonOverwrite(json,colorData);

				file.Close();
				Debug.Log("COLOR FILE LOADED");
		}
		else
		{
			TextAsset jsonResource = Resources.Load<TextAsset>("colors");
			JsonUtility.FromJsonOverwrite(jsonResource.text,colorData);
		}
	}

	public void ReturnToMainMenu(){
		OnBackButton.Invoke();
	}

	public void Quit(){
		/* if(Application.isEditor)
			UnityEditor.EditorApplication.isPlaying = false; */
		Application.Quit();
	}

}