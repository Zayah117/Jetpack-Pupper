using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {
	// https://www.youtube.com/watch?v=rXnZE8MwK-E

	public GameObject loadingScreen;
	public Slider slider;

	AsyncOperation async;

	public void LoadScreen() {
		StartCoroutine(LoadingScreenCoroutine());
	}

	IEnumerator LoadingScreenCoroutine() {
		loadingScreen.SetActive(true);
		async = SceneManager.LoadSceneAsync(1);
		async.allowSceneActivation = false;

		while (async.isDone == false) {
			slider.value = async.progress;
			if (async.progress == 0.9f) {
				slider.value = 1f;
				async.allowSceneActivation = true;
			}
			yield return null;
		}
	}
}
