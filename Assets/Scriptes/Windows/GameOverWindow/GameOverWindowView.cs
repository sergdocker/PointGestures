using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverWindowView : MonoBehaviour {
	private static GameOverWindowView instance;

	Image fadeImg;
	Image backImg;
	Image RestartButtonImg;
	Text scoreText;

	const string fadeName = "fade";
	const string backImgName = "GameOverWindow";
	const string RestartButtonImgName = "restartBtn";

	public static GameOverWindowView Instance {
		get {
			return instance;
		}
	}

	void SetImages() {
		Image[] imgs = GetComponentsInChildren<Image> ();
		foreach (Image img in imgs) {
			if (img.gameObject.name == "fade") {
				fadeImg = img;
				fadeImg.sprite = Resources.Load<Sprite> (fadeName);
			} else if (img.gameObject.name == "back") {
				backImg = img;
				backImg.sprite = Resources.Load<Sprite> (backImgName);
			} else if (img.gameObject.name == "RestartButton") {
				RestartButtonImg = img;
				RestartButtonImg.sprite = Resources.Load<Sprite> (RestartButtonImgName);
			}
		}
	}

	void InitScore() {
		scoreText = GetComponentInChildren<Text> ();
	}

	void Awake() {
		instance = this;
		SetImages ();
		InitScore ();
		gameObject.SetActive (false);
	}

	public void SetScore(int score) {
		gameObject.SetActive (true);
		scoreText.text = score.ToString ();
	}

	public void ResetWindow() {
		Debug.Log ("ResetWindow");
		gameObject.SetActive (false);
	}
}
