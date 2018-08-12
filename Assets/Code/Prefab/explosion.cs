using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {
	public GameObject Material;

	void OnCollisionEnter2D (Collision2D collision) {
		float Material_Width = Material.GetComponent<SpriteRenderer>().size.x * Material.GetComponent<Transform>().localScale.x;
		float Material_Height = Material.GetComponent<SpriteRenderer>().size.y * Material.GetComponent<Transform>().localScale.y;
		for (int a = -1; a < 2; a++) {
			for (int b = -1; b < 2; b++) {
				GameObject Clone = Instantiate(Material);
				Clone.transform.position = new Vector3(this.transform.position.x + Material_Width * a, this.transform.position.y + Material_Height * b, 0);
				Clone.name = Material.name;
			}
		}
		Destroy(this.gameObject);
	}
}
