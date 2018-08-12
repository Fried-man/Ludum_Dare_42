using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
	public GameObject[] Page_Main;
	public GameObject[] Page_About;
	public GameObject[] Page_HowtoPlay;
	public GameObject[] Page_PlayervsPlayer;

	public void PlayervsPlayer_1 () {
		if (Page_Main[0].activeSelf == true) {
			for (int i = 0; i < Page_Main.Length; i++) {
				Page_Main[i].SetActive(false);
			}
			for (int i = 0; i < Page_PlayervsPlayer.Length; i++) {
				Page_PlayervsPlayer[i].SetActive(true);
			}
		}else {
			for (int i = 0; i < Page_PlayervsPlayer.Length; i++) {
				Page_PlayervsPlayer[i].SetActive(false);
			}
			for (int i = 0; i < Page_Main.Length; i++) {
				Page_Main[i].SetActive(true);
			}
		}
	}

	public void PlayervsPlayer_2 () {
		PlayerPrefs.SetInt("Player1", 0);
		PlayerPrefs.SetInt("Player2", 0);
		SceneManager.LoadScene("PVP");
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

	public void Impossible_Level () {
		SceneManager.LoadScene("Impossible");
	}

	public void Arcade () {
		PlayerPrefs.SetInt("Level", 0);
		PlayerPrefs.SetInt("Score", 0);
		SceneManager.LoadScene("Arcade");
	}
}
