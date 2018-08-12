using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {
	public Sprite[] Phases;
	float Step;

	void Start () {
		StartCoroutine(Fire());
		Step = this.GetComponent<SpriteRenderer>().size.y * this.GetComponent<Transform>().localScale.y;
	}

	IEnumerator Fire () {
		while (1 > 0) {
			this.GetComponent<SpriteRenderer>().sprite = Phases[0];
			yield return new WaitForSeconds(.4f);
			this.GetComponent<SpriteRenderer>().sprite = Phases[1];
			yield return new WaitForSeconds(.4f);

			if (Random.Range(0, 25) == 24) {
				int Direction = Random.Range(0, 4);
				RaycastHit2D hit = Object_Detection(Step / 2, Direction);
				if (hit == false) {
					if (Direction == 0) {
						GameObject Clone = Instantiate(this.gameObject);
						Clone.transform.position = new Vector3(transform.position.x, transform.position.y + Step, 0);
						Clone.name = "Fire";
					}else if (Direction == 1) {
						GameObject Clone = Instantiate(this.gameObject);
						Clone.transform.position = new Vector3(transform.position.x - Step, transform.position.y, 0);
						Clone.name = "Fire";
					}else if (Direction == 2) {
						GameObject Clone = Instantiate(this.gameObject);
						Clone.transform.position = new Vector3(transform.position.x, transform.position.y - Step, 0);
						Clone.name = "Fire";
					}else {
						GameObject Clone = Instantiate(this.gameObject);
						Clone.transform.position = new Vector3(transform.position.x + Step, transform.position.y, 0);
						Clone.name = "Fire";
					}
				}
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.transform.name != "Player" && collision.transform.name != "Enemy" && collision.transform.name != "Fire") {
			Destroy(this.gameObject);
		}
	}

	RaycastHit2D Object_Detection (float Distance, int Direction) {
		if (Direction == 0) {
			return Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + Step), Vector2.up, Distance);
		}else if (Direction == 1) {
			return Physics2D.Raycast(new Vector2(transform.position.x - Step, transform.position.y), Vector2.left, Distance);
		}else if (Direction == 2) {
			return Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - Step), Vector2.down, Distance);
		}else {
			return Physics2D.Raycast(new Vector2(transform.position.x + Step, transform.position.y), Vector2.right, Distance);
		}
	}
}
