using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameMaster : MonoBehaviour {
	public GameObject Spikes;
	public GameObject Enemy;
	public GameObject Space;

	float Space_Width;
	float Space_Height;
	float Spikes_Width;
	float Spikes_Height;

	public GameObject Pause_Menu;
	public GameObject Game_Over_Menu;

	int Total_Time = 180;
	Vector2 Quantity_Max;
	public Vector2 Quantity;
	GameObject[] All_Spikes;
	float Delay;

	public AudioSource Background;

	void Start () {
		Time.timeScale = 1;
		Spikes_Width = Spikes.GetComponent<SpriteRenderer>().size.x * Spikes.GetComponent<Transform>().localScale.x;
		Spikes_Height = Spikes.GetComponent<SpriteRenderer>().size.y * Spikes.GetComponent<Transform>().localScale.y;
		Space_Width = Mathf.Floor((Camera.main.orthographicSize * 2f * Screen.width / Screen.height * .95f) / Spikes_Width) * Spikes_Width;
		Space_Height =  Mathf.Floor((Camera.main.orthographicSize * 2f * .95f) / Spikes_Width) * Spikes_Width;
		Quantity_Max = new Vector2(
			Mathf.RoundToInt(Space_Height / (Spikes.GetComponent<SpriteRenderer>().size.x * Spikes.GetComponent<Transform>().localScale.x)), 
			Mathf.RoundToInt(Space_Width / Spikes_Width)
		);
		Delay = Total_Time / (Quantity_Max.x +  Quantity_Max.y - 8);
		All_Spikes = new GameObject[Mathf.RoundToInt(Quantity_Max.x * 2 + Quantity_Max.y * 2)];
		//Enemy_Wave();
		StartCoroutine(Closing_Walls());
	}
		
	void Update () {
		Background.pitch = 1 + (Time.timeSinceLevelLoad / Total_Time);
	}

	void Enemy_Wave () {
		Vector2 Enemy_Size = new Vector2(
			Enemy.GetComponent<SpriteRenderer>().size.x * Enemy.GetComponent<Transform>().localScale.x, 
			Enemy.GetComponent<SpriteRenderer>().size.y * Enemy.GetComponent<Transform>().localScale.y
		);
		GameObject Clone = Instantiate(Enemy);
		Clone.transform.position = new Vector3(Enemy_Size.x * 10, Enemy_Size.x * Random.Range(4, 6), 0);
		Clone.name = "Enemy";
		Clone = Instantiate(Enemy);
		Clone.transform.position = new Vector3(Enemy_Size.x * -10, Enemy_Size.x * Random.Range(4, 6), 0);
		Clone.name = "Enemy";
		Clone = Instantiate(Enemy);
		Clone.transform.position = new Vector3(Enemy_Size.x * Random.Range(4, 6), Enemy_Size.x * 10, 0);
		Clone.name = "Enemy";
		Clone = Instantiate(Enemy);
		Clone.transform.position = new Vector3(Enemy_Size.x * Random.Range(4, 6), Enemy_Size.x * -10, 0);
		Clone.name = "Enemy";
	}

	public void Generate_Walls () {
		Space_Width = Quantity.y * Spikes_Width;
		Space_Height =  Quantity.x * Spikes_Width;
		float Ratio_x = Space_Width / (Camera.main.orthographicSize * 2f * Screen.width / Screen.height);
		float Ratio_y = Space_Height / (Camera.main.orthographicSize * 2f);
		Vector3 Screen_Pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * (Ratio_x + ((1 - Ratio_x) / 2f)), Screen.height * (Ratio_y + ((1 - Ratio_y) / 2f)), 0)); // Top right
		Space.transform.localScale = new Vector3(Space_Width / Space.GetComponent<SpriteRenderer>().size.x - (Spikes.GetComponent<Transform>().localScale.x), Space_Height / Space.GetComponent<SpriteRenderer>().size.x, 1);

		for (int a = 0; a < All_Spikes.Length; a++) {
			Destroy(All_Spikes[a]);
		}

		Spikes_Height = Spikes_Width;
		for (int i = 0; i < Quantity.x - 1; i++) { //RIGHT
			GameObject Clone = Instantiate(Spikes);
			All_Spikes[i] = Clone;
			Clone.name = "Spike #" + i;
			Clone.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 90);
			Clone.GetComponent<Transform>().position = new Vector3(Screen_Pos.x - Spikes_Height / 2f, Screen_Pos.y - Spikes_Width / 2f - Spikes_Width * i, 0);
			if (i == 0) {
				Spikes_Height = Clone.GetComponent<SpriteRenderer>().size.y * Clone.GetComponent<Transform>().localScale.y;
			}
		}
		Spikes_Height = Spikes_Width;
		for (int i = 0; i < Quantity.x - 1; i++) { //LEFT
			GameObject Clone = Instantiate(Spikes);
			All_Spikes[Mathf.RoundToInt(i + Quantity.x)] = Clone;
			Clone.name = "Spike #" + i;
			Clone.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 270);
			Clone.GetComponent<Transform>().position = new Vector3(Screen_Pos.x * -1 + Spikes_Height / 2f, Screen_Pos.y * -1 + Spikes_Width / 2f + Spikes_Width * i, 0);
			if (i == 0) {
				Spikes_Height = Clone.GetComponent<SpriteRenderer>().size.y * Clone.GetComponent<Transform>().localScale.y;
			}
		}
		Spikes_Height = Spikes_Width;
		for (int i = 0; i < Quantity.y - 1; i++) { //TOP
			GameObject Clone = Instantiate(Spikes);
			All_Spikes[Mathf.RoundToInt(i + Quantity.x * 2 - 1)] = Clone;
			Clone.name = "Spike #" + i;
			Clone.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 180);
			Clone.GetComponent<Transform>().position = new Vector3(Screen_Pos.x * -1 + (Spikes_Width * (i + .5f)), Screen_Pos.y - Spikes_Height / 2, 0);
			if (i == 0) {
				Spikes_Height = Clone.GetComponent<SpriteRenderer>().size.y * Clone.GetComponent<Transform>().localScale.y;
			}
		}
		Spikes_Height = Spikes_Width;
		for (int i = 0; i < Quantity.y - 1; i++) { //BOTTOM
			GameObject Clone = Instantiate(Spikes);
			All_Spikes[Mathf.RoundToInt(i + Quantity.x * 2 + Quantity.y - 1)] = Clone;
			Clone.name = "Spike #" + i;
			Clone.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
			Clone.GetComponent<Transform>().position = new Vector3(Screen_Pos.x - (Spikes_Width * (i + .5f)), Screen_Pos.y * -1 + Spikes_Height / 2, 0);
			if (i == 0) {
				Spikes_Height = Clone.GetComponent<SpriteRenderer>().size.y * Clone.GetComponent<Transform>().localScale.y;
			}
		}
	}

	IEnumerator Closing_Walls () {
		Quantity = Quantity_Max;
		Generate_Walls();
		yield return new WaitForSeconds(Delay);
		for (int i = 0; i < Quantity_Max.x + Quantity_Max.y - 8; i++) {
			if (Quantity.y >= Quantity.x) {
				Quantity = new Vector2(Quantity.x, Quantity.y - 1);
			}else {
				Quantity = new Vector2(Quantity.x - 1, Quantity.y);
			}
			Generate_Walls();
			yield return new WaitForSeconds(Delay);
		}
	}

	public void Game_Over () {
		Game_Over_Menu.SetActive(true);
		Freeze();
	}

	public void Pause () {
		if (Pause_Menu.activeSelf == false) {
			Pause_Menu.SetActive(true);
		}else {
			Pause_Menu.SetActive(false);
		}
		Freeze();
	}

	public void Freeze () {
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
		}else {
			Time.timeScale = 1;
		}
	}

	public void Restart () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Exit () {
		SceneManager.LoadScene("Title");
	}
}
