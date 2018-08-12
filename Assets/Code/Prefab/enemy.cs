using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
	GameObject Player;
	public GameObject Laser;
	public Vector2 Distance;
	public GameObject Child;
	public GameObject Tombstone;
	float Speed = .4f;
	float Step;
	int Scale = 1;

	void Start () {
		Player = GameObject.Find("Player");
		if (this.transform.name == "Big Enemy") {
			Scale = 2;
		}
		StartCoroutine(Action());
		Step = this.GetComponent<SpriteRenderer>().size.y * this.GetComponent<Transform>().localScale.y;
	}

	void Update () {
		Distance = new Vector2(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y);
	}

	IEnumerator Action () {
		while (1 > 0) {
			if (Distance.x <= .1 && Distance.x >= -.1) {
				if (Distance.y > 0 && this.GetComponent<Transform>().rotation != Quaternion.Euler(0, 0, 0)) {
					this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
					yield return new WaitForSeconds(Speed);
				}else if (Distance.y < 0 && this.GetComponent<Transform>().rotation != Quaternion.Euler(0, 0, 180)) {
					this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 180);
					yield return new WaitForSeconds(Speed);
				}
				Shoot();
				yield return new WaitForSeconds(Speed);
			}else if (Distance.y <= .1 && Distance.y >= -.1) {
				if (Distance.x > 0 && this.GetComponent<Transform>().rotation != Quaternion.Euler(0, 0, 270)) {
					this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 270);
					yield return new WaitForSeconds(Speed);
				}else if (Distance.x < 0 && this.GetComponent<Transform>().rotation != Quaternion.Euler(0, 0, 90)) {
					this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 90);
					yield return new WaitForSeconds(Speed);
				}
				Shoot();
				yield return new WaitForSeconds(Speed);
			}else {
				if (Mathf.Abs(Distance.x) < Mathf.Abs(Distance.y)) {
					if (Distance.x > 0 && this.GetComponent<Transform>().rotation != Quaternion.Euler(0, 0, 270)) {
						this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 270);
						yield return new WaitForSeconds(Speed);
					}else if (Distance.x < 0 && this.GetComponent<Transform>().rotation != Quaternion.Euler(0, 0, 90)) {
						this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 90);
						yield return new WaitForSeconds(Speed);
					}
				}else {
					if (Distance.y > 0 && this.GetComponent<Transform>().rotation != Quaternion.Euler(0, 0, 0)) {
						this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
						yield return new WaitForSeconds(Speed);
					}else if (Distance.y < 0 && this.GetComponent<Transform>().rotation != Quaternion.Euler(0, 0, 180)) {
						this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 180);
						yield return new WaitForSeconds(Speed);
					}
				}
				RaycastHit2D hit = Object_Detection(Step);
				if (Object_Detection(Step) == false) {
					transform.Translate(0, Step, 0);
				}
				yield return new WaitForSeconds(Speed);
			}
		}
	}

	void Shoot () {
		RaycastHit2D hit = Object_Detection(Mathf.Infinity);
		if (hit.collider.name != "Enemy") {
			GameObject Clone = Instantiate(Laser);
			if (this.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, 0)) {
				Clone.transform.position = new Vector3(transform.position.x, transform.position.y + .23f * Scale, 0);
			}else if (this.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, 90)) {
				Clone.transform.position = new Vector3(transform.position.x - .23f * Scale, transform.position.y, 0);
			}else if (this.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, 180)) {
				Clone.transform.position = new Vector3(transform.position.x, transform.position.y - .23f * Scale, 0);
			}else {
				Clone.transform.position = new Vector3(transform.position.x + .23f * Scale, transform.position.y, 0);
			}
			Clone.GetComponent<Transform>().rotation = this.GetComponent<Transform>().rotation;
			Clone.GetComponent<SpriteRenderer>().color = this.GetComponent<SpriteRenderer>().color;
			if (this.transform.name == "Big Enemy") {
				Clone.GetComponent<Transform>().localScale = new Vector3(Clone.GetComponent<Transform>().localScale.x * 2, Clone.GetComponent<Transform>().localScale.y * 2, Clone.GetComponent<Transform>().localScale.z * 2);
			}
			Clone.name = "Laser";
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

	void OnCollisionEnter2D (Collision2D collision) {
		if (this.transform.name == "Big Enemy") {
			GameObject Clone = Instantiate(Child);
			Clone.transform.position = new Vector3(this.transform.position.x - Step / 2, this.transform.position.y + Step / 2, 0);
			Clone.name = "Enemy";
			Clone = Instantiate(Child);
			Clone.transform.position = new Vector3(this.transform.position.x + Step / 2, this.transform.position.y + Step / 2, 0);
			Clone.name = "Enemy";
			Clone = Instantiate(Child);
			Clone.transform.position = new Vector3(this.transform.position.x - Step / 2, this.transform.position.y - Step / 2, 0);
			Clone.name = "Enemy";
			Clone = Instantiate(Child);
			Clone.transform.position = new Vector3(this.transform.position.x + Step / 2, this.transform.position.y - Step / 2, 0);
			Clone.name = "Enemy";
		}
		GameObject Death = Instantiate(Tombstone);
		Death.transform.position = transform.position;
		Death.GetComponent<SpriteRenderer>().color = this.GetComponent<SpriteRenderer>().color;
		Destroy(this.gameObject);
	}
}
