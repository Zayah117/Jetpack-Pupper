using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigator : MonoBehaviour {
	public void OpenMenu(GameObject openPanel) {
		openPanel.SetActive(true);
		this.transform.parent.gameObject.SetActive(false);
	}
}
