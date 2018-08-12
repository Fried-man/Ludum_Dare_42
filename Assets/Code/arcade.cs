using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class arcade : MonoBehaviour {
	public UnityEngine.UI.Text[] Info;
	public GameObject[] Enemies;
	public int Amount;

	void Start () {
		Amount = (PlayerPrefs.GetInt("Level") + 1) * Random.Range(1, 3);
	}

	// Update is called once per frame
	void Update () {
		Info[0].text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore");
		Info[1].text = "LEVEL " + PlayerPrefs.GetInt("Level");
		Info[2].text = "SCORE: " + PlayerPrefs.GetInt("Score");

		if (Amount <= 0 && Amount != null) {
			PlayerPrefs.SetInt("Level",  PlayerPrefs.GetInt("Level") + 1);
			SceneManager.LoadScene("Arcade");
		}

		if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("Highscore")) {
			PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("Score"));
		}
	}

	public void Restart () {
		PlayerPrefs.SetInt("Score", 0);
		SceneManager.LoadScene("Arcade");
	}

	public void Enemy_Generation (Vector3[] Positions) {
		float Size = Enemies[0].GetComponent<SpriteRenderer>().size.x * Enemies[0].GetComponent<Transform>().localScale.x;
		Vector3[] More_Positions = new Vector3[Positions.Length + Amount + 16];
		for (int i = 0; i < Positions.Length; i++) {
			More_Positions[i] = Positions[i];
		}
		for (int a = 0; a < 4; a++) {
			for (int b = 0; b < 4; b++) {
				More_Positions[Positions.Length + b + a * 4] = new Vector3(Size * a - 2, Size * b - 2, 0);
			}
		}
		for (int i = 0; i < Amount; i++) {
			GameObject Item = Enemies[0];
			GameObject Clone = Instantiate(Item);
			Vector3 Spot = new Vector3(Size * Random.Range(-15, 15), Size * Random.Range(-10, 10), 0);
			for (int a = 0; a < More_Positions.Length; a++) {
				if (Spot == More_Positions[a]) {
					Spot = new Vector3(Size * Random.Range(-15, 15), Size * Random.Range(-10, 10), 0);
					a = 0;
				}
			}
			Clone.transform.position = Spot;
			Clone.transform.name = Item.name;
		}
	}
}