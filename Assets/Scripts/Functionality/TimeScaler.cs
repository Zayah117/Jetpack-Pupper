using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaler : MonoBehaviour {
	public void ScaleTime(int timeScale) {
		Time.timeScale = timeScale;
	}
}
