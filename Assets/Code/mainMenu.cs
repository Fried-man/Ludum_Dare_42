using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour {
	public GameObject[] Page_Main;
	public GameObject[] Page_About;
	public GameObject[] Page_HowtoPlay;
	public GameObject[] Page_PlayervsPlayery;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void HowtoPlay () {
		if (Page_Main[0].activeSelf == true) {
			for (int i = 0; i < Page_Main.Length; i++) {
				Page_Main[i].SetActive(false);
			}
			for (int i = 0; i < Page_HowtoPlay.Length; i++) {
				Page_HowtoPlay[i].SetActive(true);
			}
		}else {
			for (int i = 0; i < Page_HowtoPlay.Length; i++) {
				Page_HowtoPlay[i].SetActive(false);
			}
			for (int i = 0; i < Page_Main.Length; i++) {
				Page_Main[i].SetActive(true);
			}
		}
	}

	public void About () {
		if (Page_Main[0].activeSelf == true) {
			for (int i = 0; i < Page_Main.Length; i++) {
				Page_Main[i].SetActive(false);
			}
			for (int i = 0; i < Page_About.Length; i++) {
				Page_About[i].SetActive(true);
			}
		}else {
			for (int i = 0; i < Page_About.Length; i++) {
				Page_About[i].SetActive(false);
			}
			for (int i = 0; i < Page_Main.Length; i++) {
				Page_Main[i].SetActive(true);
			}
		}
	}

	public void Exit () {
		Application.Quit();
	}
}
