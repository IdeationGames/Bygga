using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
	public void loadByIndex(int sceneIndex)
	{
		globalInfo.resetGameScore();
		SceneManager.LoadScene(sceneIndex);
	}
}
