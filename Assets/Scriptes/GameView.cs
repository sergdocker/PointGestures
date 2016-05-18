using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameView : MonoBehaviour {

	//image for background
	public Image backgroundImg;

	//name of background sprite in Resource folder without extension
	const string backgroundPath = "GameBackground";
	//Name of scene with game
	const string MainGameSceneName = "GameScene";

	// Use this for initialization
	void Start () {
		if (backgroundImg.sprite == null) {
			SetBackgroundImage ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//set backgroundImage
	//load sprite from resurce and set them
	void SetBackgroundImage() {
		Sprite spr = Resources.Load<Sprite> (backgroundPath);
		backgroundImg.sprite = spr;
	}
}
