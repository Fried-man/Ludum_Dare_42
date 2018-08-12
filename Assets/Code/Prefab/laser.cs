using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour {
	void Update () {
		transform.Translate(Vector2.up * Time.deltaTime * 10);
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.transform.name != "Laser" && collision.transform.name != "Corner") {
			Destroy(this.gameObject);
		}
	}
}
