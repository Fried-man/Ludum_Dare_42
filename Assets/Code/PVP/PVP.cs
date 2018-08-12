using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PVP : MonoBehaviour {
	public UnityEngine.UI.Text[] Info;
	public GameObject Game_Over;

	void Update () {
		Info[0].text = "PLAYER 1: " + PlayerPrefs.GetInt("Player1");
		Info[1].text = "PLAYER 2: " + PlayerPrefs.GetInt("Player2");

		if (PlayerPrefs.GetInt("Player1") >= 10 || PlayerPrefs.GetInt("Player2") >= 10) {
			Game_Over.SetActive(true);
			GameObject.Find("Main Camera").GetComponent<gameMaster>().Freeze();
		}
	}

	public void Restart () {
		PlayerPrefs.SetInt("Player1", 0);
		PlayerPrefs.SetInt("Player2", 0);
		SceneManager.LoadScene("PVP");
	}
}
