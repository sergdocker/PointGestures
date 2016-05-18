using UnityEngine;
using System.Collections;

public class TimerController: MonoBehaviour {
	
	static TimerController instance;

	TimerView view;
	TimerModel model;

	public static TimerController Instance {
		get {
			return instance;
		}
	}

	void Awake() {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		view = gameObject.GetComponent<TimerView> ();
		model = new TimerModel ();
		model.Initialise (1);
		//every 1 second checkTimer
		InvokeRepeating ("checkTime", 0f, 1f);
	}

	void checkTime() {
		changeTime ();
		view.UpdateSlider (model.curTime / (float) model.maxTime );

		int leftTime = model.maxTime - model.curTime;
		view.UpdateText (leftTime.ToString());
		if (leftTime <= 0 ) {
			ShowGameOverWindow ();
		}
	}

	void changeTime() {
		model.curTime++;
	}

	void resetTime(int curLvl) {
		model.Initialise (curLvl);
	}

	void ShowGameOverWindow() {
		RoundController.Instance.GameOver = true;
		int score = RoundController.Instance.curRound;
		GameOverWindowView.Instance.SetScore (score);
		Debug.Log ("GameOver");
		CancelInvoke ();
	}

	public void RestartTimer() {
		InvokeRepeating ("checkTime", 0f, 1f);
		SetTimerModel (RoundController.Instance.curRound);
	}
	
	public void SetTimerModel(int round) {
		model.Initialise (round);
	}
}
