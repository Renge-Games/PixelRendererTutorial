using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Picker : MonoBehaviour {
	Camera cam;
	Collider picked;

	private void Start() {
		cam = Camera.main;
	}

	private void Update() {
		Ray mp = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit rh;
		
		if(Physics.Raycast(mp, out rh) && rh.distance > 1.0f) {
			picked = rh.collider;
		} else {
			picked = null;
		}
	}

	private void OnDrawGizmos() {
		if(picked != null) {
			Gizmos.color = Color.red;
			Gizmos.DrawCube(picked.bounds.center, picked.bounds.size);
		}
	}
}
