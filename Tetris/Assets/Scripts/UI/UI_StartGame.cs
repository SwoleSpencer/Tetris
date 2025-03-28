using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UI_StartGame : MonoBehaviour
{
	[SerializeField] private string _gameScene;
	[SerializeField] private string _entitiesSubScene;

	[SerializeField] private GameObject _uiMenu;
	[SerializeField] private GameObject _uiGame;

	public void LoadGameScene()
	{
		StartCoroutine(LoadScenesAsync());
	}

	private IEnumerator LoadScenesAsync()
	{
		AsyncOperation loadGameSceneOperation = SceneManager.LoadSceneAsync(_gameScene, LoadSceneMode.Additive);
		loadGameSceneOperation.allowSceneActivation = false;

		while (loadGameSceneOperation.isDone == false)
		{
			if (loadGameSceneOperation.progress >= 0.9f)
			{
				loadGameSceneOperation.allowSceneActivation = true;
			}
			yield return null;
		}

		AsyncOperation entitiesSubSceneOperation = SceneManager.LoadSceneAsync(_entitiesSubScene, LoadSceneMode.Additive);
		entitiesSubSceneOperation.allowSceneActivation = false;

		while (entitiesSubSceneOperation.isDone == false)
		{
			if (entitiesSubSceneOperation.progress >= 0.9f)
			{
				entitiesSubSceneOperation.allowSceneActivation = true;
			}
			yield return null;
		}

		_uiMenu.SetActive(false);
		_uiGame.SetActive(true);
	}
}
