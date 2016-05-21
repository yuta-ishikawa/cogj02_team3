using UnityEngine;
using System.Collections;

// TitleSceneに関わる処理を管理するコンポ―ネント
public class TitleController : MonoBehaviour {

	[SerializeField]
	private FadeParam fadeParam;

	// スタートボタンをクリック
	public void OnClickStartButton()
	{
		ScreenFadeManager.Instance.FadeIn(fadeParam.time, fadeParam.color,
			delegate { Debug.Log("Fade Out OK"); });
	}

}
