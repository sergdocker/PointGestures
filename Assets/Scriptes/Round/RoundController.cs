using UnityEngine;
using System.Collections;

public class RoundController {

	#region Singleton
	private static readonly RoundController instance = new RoundController();

	// Explicit static constructor to tell C# compiler
	// not to mark type as beforefieldinit
	static RoundController()
	{
	}

	private RoundController()
	{
	}

	public static RoundController Instance
	{
		get
		{
			return instance;
		}
	}
	#endregion

	int _curRound = 1;
	int _curScore = 0;

	int _curGesture = 0;
	int _maxGestures = 0;

	public PointCloudRegognizer regognizer;

	public bool GameOver = false;

	public int curRound {
		get {
			return _curRound;
		}
	}

	public int curScore {
		get {
			return _curScore;
		}
	}

	public int curGesture {
		get {
			return _curGesture;
		}
	}

	public void StartGame() {
		Debug.Log ("StartGame");
		_curRound = 0;
		_curScore = 0;
		GetMaxGestures ();
		_curGesture = Random.Range (0, _maxGestures);
		RoundView.Intsance.UpdateScore ();
		TimerController.Instance.RestartTimer ();
	}

	void GetMaxGestures() {
		Debug.Log ("_maxGestures:" + _maxGestures);
		if (_maxGestures == 0) {
			regognizer = FingerGestures.Instance.GetComponent<PointCloudRegognizer> ();
			Debug.Log ("regognizer:" + regognizer);
			if (regognizer != null) {
				_maxGestures = regognizer.Templates.Count;
				Debug.Log ("_maxGestures:" + _maxGestures);
			}
		}
	}

	public void NextRound() {
		_curRound++;
		_curScore++;

		GetMaxGestures ();

		_curGesture = Random.Range (0, _maxGestures);

		RoundView.Intsance.UpdateScore ();
		TimerController.Instance.SetTimerModel (_curRound);
	}
}