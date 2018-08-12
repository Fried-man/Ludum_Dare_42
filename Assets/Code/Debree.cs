using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Debree : MonoBehaviour {
	public GameObject[] Items;
	Vector3[] Positions;
	int Amount;

	void Start () {
		float Size = Items[0].GetComponent<SpriteRenderer>().size.x * Items[0].GetComponent<Transform>().localScale.x;
		if  (SceneManager.GetActiveScene().name == "PVP") {
			Amount = Random.Range(2, 60);
		}else {
			Amount = Random.Range(0, 11);
		}

		if (SceneManager.GetActiveScene().name == "PVP") {
			Positions = new Vector3[Amount + 2];
			Positions[Amount] = new Vector3(-2.7f, .3f, 0);
			Positions[Amount + 1] = new Vector3(2.7f, -.3f, 0);
		}else {
			Positions = new Vector3[Amount];
		}

		for (int i = 0; i < Amount; i++) {
			GameObject Item = Items[Random.Range(0, Items.Length)];
			GameObject Clone = Instantiate(Item);
			Vector3 Spot = new Vector3(Size * Random.Range(-15, 15), Size * Random.Range(-10, 10), 0);
			for (int a = 0; a < Positions.Length; a++) {
				if (Spot == Positions[a]) {
					Spot = new Vector3(Size * Random.Range(-15, 15), Size * Random.Range(-10, 10), 0);
					a = 0;
				}
			}
			Clone.transform.position = Spot;
			Clone.transform.name = Item.name;
		}

		if (SceneManager.GetActiveScene().name == "Arcade") {
			GameObject.Find("Main Camera").GetComponent<arcade>().Enemy_Generation(Positions);
		}
	}
}
