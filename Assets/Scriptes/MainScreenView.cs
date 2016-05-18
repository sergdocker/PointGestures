using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

//MVC arhitecture
//View of MainScene
public class MainScreenView : MonoBehaviour {

	//image for background
	public Image backgroundImg;

	//name of background sprite in Resource folder without extension
	const string backgroundPath = "background";
	//Name of scene with game
	const string MainGameSceneName = "GameScene";

	// Use this for initialization
	void Start () {
		if (backgroundImg.sprite == null) {
			SetBackgroundImage ();
		}
	}

	//set backgroundImage
	//load sprite from resurce and set them
	void SetBackgroundImage() {
		Sprite spr = Resources.Load<Sprite> (backgroundPath);
		backgroundImg.sprite = spr;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadMainGameScene() {
		Resources.UnloadUnusedAssets ();
		SceneManager.LoadSceneAsync (MainGameSceneName);
	}
}
