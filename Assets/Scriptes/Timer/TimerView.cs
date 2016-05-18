using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerView : MonoBehaviour {

	Slider timeSlider;
	Text timerText;

	public void Start() {
		timeSlider = GetComponent<Slider> ();
		timeSlider.value = 0;

		timerText = GetComponentInChildren<Text> ();
		timerText.text = "TEST_VALUE";
	}

	public void UpdateSlider(float value) {
		timeSlider.value = value;
	}

	public void UpdateText(string text) {
		timerText.text = text;
	}
}
