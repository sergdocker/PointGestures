using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundView : MonoBehaviour {

	static RoundView instance;
	Text scoreText;
	Image roundImg;

	public static RoundView Intsance {
		get {
			return instance;
		}
	}

	void Awake() {
		instance = this;
		GetScoreText ();
	}

	void Start() {
		RoundController.Instance.StartGame ();
	}

	public void Restart() {
		RoundController.Instance.GameOver = false;
		GameOverWindowView.Instance.ResetWindow ();
		RoundController.Instance.StartGame ();

	}

	void GetScoreText() {
		scoreText = GetComponentInChildren<Text> ();
		roundImg = GetComponentInChildren<Image> ();
	}

	Sprite GetRoundImage() {
		switch(RoundController.Instance.curGesture) {
		case 0:
			return Resources.Load<Sprite> ("Figures/TripleCircle");
		case 1:
			return Resources.Load<Sprite> ("Figures/Triangle");
		case 2:
			return Resources.Load<Sprite> ("Figures/Square");
		case 3:
			return Resources.Load<Sprite> ("Figures/Circle");
		}
		return null;
	}

	void SetImage() {
		roundImg.sprite = GetRoundImage();
	}

	public void UpdateScore() {
		scoreText.text = RoundController.Instance.curScore.ToString();
		SetImage ();
	}
}
