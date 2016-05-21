using UnityEngine;
using System.Collections;

// ResultScene内の管理と操作を行うコンポーネント
public class ResultController : MonoBehaviour {

	[SerializeField]
	private FadeParam fadeParam;

	// タイトルへの遷移
	public void OnClickTitleButton()
	{
		ScreenFadeManager.Instance.FadeIn(fadeParam.time, fadeParam.color,
			delegate { Debug.Log("Fade Out OK"); });
	}

	// リトライへの遷移
	public void OnClickRetryButton()
	{
		ScreenFadeManager.Instance.FadeIn(fadeParam.time, fadeParam.color,
			delegate { Debug.Log("Fade Out OK"); });
	}
}
