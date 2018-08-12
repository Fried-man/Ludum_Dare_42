using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour {
	public GameObject Aftermath;

	void Update () {
		transform.Translate(Vector2.up * Time.deltaTime * 10);
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.transform.name != "Laser" && collision.transform.name != "Corner") {
			GameObject Clone = Instantiate(Aftermath);
			Clone.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
			Clone.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
			if (this.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, 0)) {
				Clone.GetComponent<Transform>().rotation = Quaternion.Euler(90, 0, 0);
			}else if (this.GetComponent<Transform>().rotation.z == -1) {
				Clone.GetComponent<Transform>().rotation = Quaternion.Euler(-90, 0, 0);
			}else if (this.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, -90)) {
				Clone.GetComponent<Transform>().rotation = Quaternion.Euler(0, -90, 0);
			}else if (this.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, 90)) {
				Clone.GetComponent<Transform>().rotation = Quaternion.Euler(0, 90, 0);
			}
			if (this.GetComponent<SpriteRenderer>().color == Aftermath.GetComponent<ParticleSystem>().startColor) {
				if (collision.transform.name == "Big Enemy") {
					PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 15);
				}else if (collision.transform.name == "Enemy") {
					PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 10);
				}else if (collision.transform.name == "Corner") {
					PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 2);
				}else if (collision.transform.name == "Fire Box") {
					PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 10);
				}else if (collision.transform.name == "Fire") {
					PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - 1);
				}
			}else {
				if (collision.transform.name == "Big Enemy") {
					PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 5);
				}else if (collision.transform.name == "Enemy") {
					PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 12);
				}else if (collision.transform.name == "Fire") {
					PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
				}
			}
			Destroy(this.gameObject);
		}
	}
}
