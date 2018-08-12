using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {
	public Sprite[] Phases;

	void Start () {
		StartCoroutine(Fire());
	}

	IEnumerator Fire () {
		while (1 > 0) {
			this.GetComponent<SpriteRenderer>().sprite = Phases[0];
			yield return new WaitForSeconds(.4f);
			this.GetComponent<SpriteRenderer>().sprite = Phases[1];
			yield return new WaitForSeconds(.4f);
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.transform.name != "Player" && collision.transform.name != "Enemy") {
			Destroy(this.gameObject);
		}
	}
}
