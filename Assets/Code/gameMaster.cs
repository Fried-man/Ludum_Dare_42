using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMaster : MonoBehaviour {
	public GameObject Spikes;

	void Start () {
		Vector3 Screen_Pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)); // Top right
		float Screen_Width = Camera.main.orthographicSize * 2f * Screen.width / Screen.height;
		float Screen_Height = Camera.main.orthographicSize * 2f;
		float Spikes_Width = Spikes.GetComponent<SpriteRenderer>().size.x * Spikes.GetComponent<Transform>().localScale.x;
		float Spikes_Height = Spikes.GetComponent<SpriteRenderer>().size.y * Spikes.GetComponent<Transform>().localScale.y;

		int Quantity = Mathf.CeilToInt(Screen_Height / (Spikes.GetComponent<SpriteRenderer>().size.x * Spikes.GetComponent<Transform>().localScale.x)); //fix this
		for (int i = 0; i < Quantity - 2; i++) { //RIGHT
			GameObject Clone = Instantiate(Spikes);
			Clone.name = "Spike #" + i;
			Clone.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 90);
			float Clone_Scale = Spikes_Width / Spikes.GetComponent<SpriteRenderer>().size.x;
			Clone.GetComponent<Transform>().localScale = new Vector3(Clone_Scale, Clone_Scale, Clone_Scale);
			Spikes_Height = Clone.GetComponent<SpriteRenderer>().size.y * Clone.GetComponent<Transform>().localScale.y;
			if (i == 0) {
				Spikes_Height = Spikes_Width;
			}
			Clone.GetComponent<Transform>().position = new Vector3(Screen_Pos.x - Spikes_Height / 2, Screen_Pos.y - Spikes_Width * (i + .5f), 0);
		}
		for (int i = 0; i < Quantity - 2; i++) { //LEFT
			GameObject Clone = Instantiate(Spikes);
			Clone.name = "Spike #" + i;
			Clone.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 270);
			float Clone_Scale = Spikes_Width / Spikes.GetComponent<SpriteRenderer>().size.x;
			Clone.GetComponent<Transform>().localScale = new Vector3(Clone_Scale, Clone_Scale, Clone_Scale);
			Spikes_Height = Clone.GetComponent<SpriteRenderer>().size.y * Clone.GetComponent<Transform>().localScale.y;
			if (i == 0) {
				Spikes_Height = Spikes_Width;
			}
			Clone.GetComponent<Transform>().position = new Vector3(Screen_Pos.x * -1 + Spikes_Height / 2, Screen_Pos.y * -1 + Spikes_Width * (i + .5f), 0);
		}
		Quantity = Mathf.FloorToInt(Screen_Width / Spikes_Width);
		for (int i = 0; i < Quantity - 1; i++) { //TOP
			GameObject Clone = Instantiate(Spikes);
			Clone.name = "Spike #" + i;
			Clone.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 180);
			Spikes_Width = Screen_Width / Quantity;
			float Clone_Scale = Spikes_Width / Spikes.GetComponent<SpriteRenderer>().size.x;
			Clone.GetComponent<Transform>().localScale = new Vector3(Clone_Scale, Clone_Scale, Clone_Scale);
			Spikes_Height = Clone.GetComponent<SpriteRenderer>().size.y * Clone.GetComponent<Transform>().localScale.y;
			if (i == 0) {
				Spikes_Height = Spikes_Width;
			}
			Clone.GetComponent<Transform>().position = new Vector3(Screen_Pos.x * -1 + (Spikes_Width * (i + .5f)), Screen_Pos.y - Spikes_Height / 2, 0);
		}
		for (int i = 0; i < Quantity - 1; i++) { //BOTTOM
			GameObject Clone = Instantiate(Spikes);
			Clone.name = "Spike #" + i;
			Clone.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
			Spikes_Width = Screen_Width / Quantity;
			float Clone_Scale = Spikes_Width / Spikes.GetComponent<SpriteRenderer>().size.x;
			Clone.GetComponent<Transform>().localScale = new Vector3(Clone_Scale, Clone_Scale, Clone_Scale);
			Spikes_Height = Clone.GetComponent<SpriteRenderer>().size.y * Clone.GetComponent<Transform>().localScale.y;
			if (i == 0) {
				Spikes_Height = Spikes_Width;
			}
			Clone.GetComponent<Transform>().position = new Vector3(Screen_Pos.x - (Spikes_Width * (i + .5f)), Screen_Pos.y * -1 + Spikes_Height / 2, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
