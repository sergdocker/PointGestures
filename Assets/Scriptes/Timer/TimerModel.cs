using UnityEngine;
using System.Collections;

public class TimerModel {

	const float modifier = 0.9f;
	const float maxValueStarted = 50;

	#region private variables
	int _curTime;
	int _maxTime;
	#endregion

	#region public parameters
	public int curTime{
		get {
			return _curTime;
		}
		set {
			_curTime = value;
		}
	}

	public int maxTime{
		get {
			return _maxTime;
		}
		set {
			_maxTime = value;
		}
	}
	#endregion

	//y = 50 * (0.9) ^ x
	//30 lvl = 2sec
	public void Initialise(int currentLvl) {
		_curTime = 0;

		int curentLvlInit = currentLvl - 1;
		_maxTime = (int) (maxValueStarted * Mathf.Pow (modifier, curentLvlInit));
		Debug.Log ("maxTime:" + _maxTime);
	}
}
