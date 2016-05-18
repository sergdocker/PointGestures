using UnityEngine;
using System.Collections;

public class ParticleView : MonoBehaviour {

	const float distance = 10.0f;

	bool particleEnabled = false;
	ParticleSystem particleSys = null;

	// Use this for initialization
	void Start () {
		if (particleSys == null) {
			particleSys = GetComponentInChildren<ParticleSystem> ();
			particleSys.enableEmission = false;
			particleEnabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			OnMouseDown ();
		} else if (Input.GetMouseButtonUp(0)) {
			OnMouseUp ();
		}
		if (particleEnabled) {
			UpdatePos ();
		}

		if (RoundController.Instance.GameOver) {
			OnMouseUp ();
		}
	}

	void OnMouseDown() {
		particleSys.enableEmission = true;
		//particleSys.emission.enabled = true;
		particleEnabled = true;
	}

	void OnMouseUp() {
		//particleSys.emission.enabled = false;
		particleSys.enableEmission = false;
		particleEnabled = false;
	}

	void UpdatePos() {
		//if() {
		//}
		Vector3 mousePos = Input.mousePosition;
		Ray r = Camera.main.ScreenPointToRay(mousePos);

		Vector3 pos = r.GetPoint(distance);
		transform.position = pos;
	}
}
