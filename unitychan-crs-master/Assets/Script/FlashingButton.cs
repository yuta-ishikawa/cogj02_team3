using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// インターバル時間と更新時処理の変更量
[System.Serializable]
public class IntervalAndAlpha
{
	public float interval;
	public float alpha;
};

// ボタンの点滅を行う
public class FlashingButton : MonoBehaviour {

	// α値の更新状態：減算or加算
	private enum StateType { Sub, Add, Stay };

	[SerializeField]
	private IntervalAndAlpha normal;
	[SerializeField]
	private IntervalAndAlpha clicked;

	[SerializeField]
	private StateType stateType = StateType.Sub;

	private bool isCliked = false;

	private float nowTime = 0.0f;
	private Image image = null;
	private Color color;

	public void OnClicked()
	{
		if (isCliked == true) return;

		isCliked	= true;
		color.a		= 1.0f;
		nowTime		= 0.0f;
		stateType	= StateType.Sub;
	}

	private float CalcAlpha()
	{
		float mark = stateType == StateType.Sub ? -1.0f : 1.0f;
		float a = isCliked ? clicked.alpha : normal.alpha;
		return a * mark;
	}

	void Awake()
	{
		// 減算から開始する
		stateType = StateType.Sub;
		image = GetComponent<Image>();
		color = image.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (stateType == StateType.Stay) return;
		
		// 透明度更新
		color.a += CalcAlpha();
		image.color = color;

		// 時間更新
		nowTime += Time.deltaTime;
		if(nowTime >= (isCliked ? clicked.interval : normal.interval))
		{
			nowTime = 0.0f;
			stateType = stateType == StateType.Sub ? StateType.Add : StateType.Sub;
		}
	}
}
