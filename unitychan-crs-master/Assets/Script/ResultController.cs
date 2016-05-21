using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// ResultScene内の管理と操作を行うコンポーネント
public class ResultController : MonoBehaviour {

	[SerializeField]
	private FadeParam fadeParam = null;

	// タイトルへの遷移
	public void OnClickTitleButton()
	{
		ScreenFadeManager.Instance.FadeIn(fadeParam.time, fadeParam.color,
			delegate {
				Debug.Log("Fade In OK");
				SceneManager.LoadScene("Title");
			});
	}

	// リトライへの遷移
	public void OnClickRetryButton()
	{
		ScreenFadeManager.Instance.FadeIn(fadeParam.time, fadeParam.color,
			delegate {
				Debug.Log("Fade In OK");
				SceneManager.LoadScene("Main");
			});
	}
}
