using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour {
	public Sprite[] Form;

	void Start () {
		if (this.name == "Spike #0") {
			this.GetComponent<SpriteRenderer>().sprite = Form[1];
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
