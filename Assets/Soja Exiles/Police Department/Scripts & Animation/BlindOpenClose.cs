﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindOpenClose : MonoBehaviour {

	public Animator Blinds;
	public bool open;
	public Transform Player;

	void Start (){
		Player = GameObject.FindWithTag("Player").transform;
		open = false;
	}

	void OnMouseOver (){
		{
			if (Player) {
				float dist = Vector3.Distance (Player.position, transform.position);
				if (dist < 15) {
					if (open == false) {
						if (Input.GetMouseButtonDown (0)) {
							StartCoroutine (opening ());
						}
					} else {
						if (open == true) {
							if (Input.GetMouseButtonDown (0)) {
								StartCoroutine (closing ());
							}
						}

					}

				}
			}

		}

	}

	IEnumerator opening(){
		print ("you are Opening the blinds");
        Blinds.Play ("BlindOpen");
		open = true;
		yield return new WaitForSeconds (.5f);
	}

	IEnumerator closing(){
		print ("you are Closing the blinds");
        Blinds.Play ("BlindClose");
		open = false;
		yield return new WaitForSeconds (.5f);
	}


}

