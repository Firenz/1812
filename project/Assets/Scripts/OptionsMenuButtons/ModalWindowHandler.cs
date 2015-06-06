﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModalWindowHandler : Singleton<ModalWindowHandler> {
	private bool isYesClicked = false;
	private bool isNoClicked = false;
	private bool isEnabled = false;
	private bool isSelectionEnded = false;

	public delegate void OnModalWindowInitialized();
	public static event OnModalWindowInitialized onInitialized;
	public delegate void OnModalWindowDisabled();
	public static event OnModalWindowDisabled onDisable;

	 //Use this for initialization
	private void Start () {
		isEnabled = false;
		isYesClicked = false;
		isNoClicked = false;
		this.transform.SetAsFirstSibling();
		isSelectionEnded = false;
		this.transform.FindChild("YesButton").GetComponent<Button>().interactable = false;
		this.transform.FindChild("NoButton").GetComponent<Button>().interactable = false;
	}

	public void YesOnClick(){
		if(isEnabled){
			Debug.Log("Yes clicked");
			isYesClicked = true;
			isSelectionEnded = true;
		}
	}

	public void NoOnclick(){
		if(isEnabled){
			Debug.Log("No clicked");
			isNoClicked = true;
			isSelectionEnded = true;
		}
	}

	public void Initialize(string modalQuestion){
		this.transform.FindChild("Text").GetComponent<Text>().text = LocalizedTextManager.GetLocalizedText("OPTIONS_MENU", "MODAL_WINDOW", modalQuestion)[0];
		this.transform.FindChild("YesButton/Text").GetComponent<Text>().text = LocalizedTextManager.GetLocalizedText("OPTIONS_MENU", "MODAL_WINDOW", "YES_BUTTON")[0];
		this.transform.FindChild("NoButton/Text").GetComponent<Text>().text = LocalizedTextManager.GetLocalizedText("OPTIONS_MENU", "MODAL_WINDOW", "NO_BUTTON")[0];
		isEnabled = true;
		isSelectionEnded = false;
		this.transform.FindChild("YesButton").GetComponent<Button>().interactable = true;
		this.transform.FindChild("NoButton").GetComponent<Button>().interactable = true;
		onInitialized();
		this.transform.SetAsLastSibling();
	}

	public void Disable(){
		isEnabled = false;
		isYesClicked = false;
		isNoClicked = false;
		this.transform.SetAsFirstSibling();
		isSelectionEnded = false;
		this.transform.FindChild("YesButton").GetComponent<Button>().interactable = false;
		this.transform.FindChild("NoButton").GetComponent<Button>().interactable = false;
		onDisable();
	}

	public bool IsSelectionEnded(){
		return isSelectionEnded;
	}

	public bool IsYesClicked(){
		return isYesClicked;
	}

	public bool IsNoClicked(){
		return isNoClicked;
	}

}