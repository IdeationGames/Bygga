using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
	public void loadByIndex(int sceneIndex)
	{
		globalInfo.countScoreAndReset();
		SceneManager.LoadScene(sceneIndex);
	}

	public void resetLevelScoreAndLoadIndex(int sceneIndex)
	{
		globalInfo.resetGameScore();
		SceneManager.LoadScene(sceneIndex);
	}

	public void loadByIndexAndResetGlobalScore(int sceneIndex)
	{
		globalInfo.resetTotalScore();
		SceneManager.LoadScene(sceneIndex);
	}
}
