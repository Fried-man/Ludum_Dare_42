using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeCondition : MonoBehaviour {
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.transform.tag == "Spike") {
			Destroy(this.gameObject);
		}
	}
}
