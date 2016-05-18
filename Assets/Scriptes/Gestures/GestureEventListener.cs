using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GestureEventListener : MonoBehaviour {

	void OnCustomGesture( PointCloudGesture gesture ) 
	{
		if(!RoundController.Instance.GameOver) {
			Debug.Log( "Recognized custom gesture: " + gesture.RecognizedTemplate.name + 
				", match score: " + gesture.MatchScore + 
				", match distance: " + gesture.MatchDistance );

			List<PointCloudGestureTemplate> gestures = RoundController.Instance.regognizer.Templates;
			int curGesture = RoundController.Instance.curGesture;
			Debug.Log ("curGesture:" + curGesture);

			PointCloudGestureTemplate roundGesture = gestures[curGesture];
			Debug.Log ("roundGesture.name:" + roundGesture.name);

			if (roundGesture.name == gesture.RecognizedTemplate.name) {
				RoundController.Instance.NextRound ();
			}
		}
	}
}
