using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSize : MonoBehaviour {

	public GridLayoutGroup grid;
	RectTransform rect;
	void Awake () {
		if(!grid)
			grid = GetComponent<GridLayoutGroup>();
		if(!rect)
			rect = GetComponent<RectTransform>();
		RefreshLayout();
	}

	private void Update() {
		/* if(Input.anyKeyDown || Input.touchCount>0){
			RefreshLayout();
		} */
	}

	void RefreshLayout(){
		Debug.Log("Refreshing layout");
		grid.cellSize = new Vector2(rect.rect.width/4,rect.rect.height/3);
		
	}
}
