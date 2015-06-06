﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIGenericButton : MonoBehaviour {
	protected bool isMouseOver = false;

	protected virtual void Update(){
		if(isMouseOver){
			//if(this.GetComponent<Button>().interactable){
				CustomCursorController.Instance.ChangeCursorOverUIButton();
			//}
		}
	}

	public virtual void OnMouseOver(){
		CustomCursorController.Instance.isOverUIButton = true;
		isMouseOver = true;
	}

	public virtual void OnMouseExit(){
		CustomCursorController.Instance.isOverUIButton = false;
		CustomCursorController.Instance.ChangeCursorToDefault();
		isMouseOver = false;
	}

	public bool IsMouseOver(){
		return isMouseOver;
	}

}