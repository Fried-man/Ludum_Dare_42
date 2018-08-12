using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour {
	public GameObject Laser;
	public GameObject Tombstone;
	float Step;

	void Start () {
		Step = this.GetComponent<SpriteRenderer>().size.y * this.GetComponent<Transform>().localScale.y;
	}

	void Update () {
		if (Input.GetKeyDown("up") || Input.GetKeyDown("w")) {
			if (this.GetComponent<Transform>().rotation != Quaternion.Euler(0, 0, 0)) {
				this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
			}else {
				RaycastHit2D hit = Object_Detection(Step / 2f);
				if (hit == false) {
					transform.Translate(0, Step, 0);
				}
			}
		}else if (Input.GetKeyDown("down") || Input.GetKeyDown("s")) {
			if (this.GetComponent<Transform>().rotation != Quaternion.Euler(0, 0, 180)) {
				this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 180);
			}else {
				RaycastHit2D hit = Object_Detection(Step / 2f);
				if (hit == false) {
					transform.Translate(0, Step, 0);
				}
			}
		}else if (Input.GetKeyDown("right") || Input.GetKeyDown("d")) {
			if (this.GetComponent<Transform>().rotation != Quaternion.Euler(0, 0, 270)) {
				this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 270);
			}else {
				RaycastHit2D hit = Object_Detection(Step);
				if (hit == false) {
					transform.Translate(0, Step, 0);
				}
			} 
		}else if (Input.GetKeyDown("left") || Input.GetKeyDown("a")) {
			if (this.GetComponent<Transform>().rotation != Quaternion.Euler(0, 0, 90)) {
				this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 90);
			}else {
				RaycastHit2D hit = Object_Detection(Step);
				if (hit == false) {
					transform.Translate(0, Step, 0);
				}
			}
		}

		if (Input.GetKeyDown("space")) {
			GameObject Clone = Instantiate(Laser);
			if (this.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, 0)) {
				Clone.transform.position = new Vector3(transform.position.x, transform.position.y + .23f, 0);
			}else if (this.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, 90)) {
				Clone.transform.position = new Vector3(transform.position.x - .23f, transform.position.y, 0);
			}else if (this.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, 180)) {
				Clone.transform.position = new Vector3(transform.position.x, transform.position.y - .23f, 0);
			}else {
				Clone.transform.position = new Vector3(transform.position.x + .23f, transform.position.y, 0);
			}
			Clone.GetComponent<Transform>().rotation = this.GetComponent<Transform>().rotation;
			Clone.GetComponent<SpriteRenderer>().color = this.GetComponent<SpriteRenderer>().color;
			Clone.name = "Laser";
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			GameObject.Find("Main Camera").GetComponent<gameMaster>().Pause();
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.transform.name != "Wall") {
			GameObject Death = Instantiate(Tombstone);
			Death.transform.position = transform.position;
			Death.GetComponent<SpriteRenderer>().color = this.GetComponent<SpriteRenderer>().color;
			GameObject.Find("Main Camera").GetComponent<gameMaster>().Game_Over();
			Destroy(this.gameObject);
		}
	}

	RaycastHit2D Object_Detection (float Distance) {
		if (this.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, 0)) {
			return Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + Step), Vector2.up, Distance);
		}else if (this.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, 90)) {
			return Physics2D.Raycast(new Vector2(transform.position.x - Step, transform.position.y), Vector2.left, Distance);
		}else if (this.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, 180)) {
			return Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - Step), Vector2.down, Distance);
		}else {
			return Physics2D.Raycast(new Vector2(transform.position.x + Step, transform.position.y), Vector2.right, Distance);
		}
	}
}
