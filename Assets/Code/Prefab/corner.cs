using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corner : MonoBehaviour {
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.transform.name == "Laser") {
			if (this.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, 0)) {
				if (collision.gameObject.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, -90)) {
					collision.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
				}else if (collision.gameObject.GetComponent<Transform>().rotation.z == -1) {
					collision.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 90);
				}else {
					Destroy(collision.gameObject);
				}
			}else if (this.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, 90)) {
				if (collision.gameObject.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, -90)) {
					collision.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 180);
				}else if (collision.gameObject.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, 0)) {
					collision.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 90);
				}else {
					Destroy(collision.gameObject);
				}
			}else if (this.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, 180)) {
				if (collision.gameObject.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, 90)) {
					collision.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 180);
				}else if (collision.gameObject.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, 0)) {
					collision.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, -90);
				}else {
					Destroy(collision.gameObject);
				}
			}else if (this.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, 270)) {
				if (collision.gameObject.GetComponent<Transform>().rotation == Quaternion.Euler(0, 0, 90)) {
					collision.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
				}else if (collision.gameObject.GetComponent<Transform>().rotation.z == -1) {
					collision.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, -90);
				}else {
					Destroy(collision.gameObject);
				}
			}
		}
	}
}
