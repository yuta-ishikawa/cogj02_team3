using UnityEngine;
using System.Collections;

// TitleSceneに関わる処理を管理するコンポ―ネント
public class TitleController : MonoBehaviour {


	// スタートボタンをクリック
	public void OnClickStartButton()
	{
		ScreenFadeManager.Instance.FadeIn(2.0f, new Color(0.0f, 0.0f, 0.0f),
			delegate { Debug.Log("Fade Out OK"); });
	}

}
