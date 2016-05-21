using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// ResultScene内の管理と操作を行うコンポーネント
public class ResultController : MonoBehaviour {

	[SerializeField]
	private FadeParam fadeParam = null;
	[SerializeField]
	private ResultVoice resultVoice;

	void Start()
	{
		// フェードが終わったらボイス再生
		ScreenFadeManager.Instance.FadeOut(fadeParam.time, fadeParam.color,
			delegate {
				Debug.Log("Fade Out OK");
				resultVoice.PlayVoice();
			});
	}

	// タイトルへの遷移
	public void OnClickTitleButton()
	{
		// フェードアウト中は反応しないように
		if (ScreenFadeManager.Instance.isFadeAction) return;

		ScreenFadeManager.Instance.FadeIn(fadeParam.time, fadeParam.color,
			delegate {
				Debug.Log("Fade In OK");
				SceneManager.LoadScene("Title");
			});
	}

	// リトライへの遷移
	public void OnClickRetryButton()
	{
		// フェードアウト中は反応しないように
		if (ScreenFadeManager.Instance.isFadeAction) return;

		ScreenFadeManager.Instance.FadeIn(fadeParam.time, fadeParam.color,
			delegate {
				Debug.Log("Fade In OK");
				SceneManager.LoadScene("Main");
			});
	}
}
