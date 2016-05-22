using UnityEngine;
using System.Collections;

public class ScaleUp : MonoBehaviour {

	private enum StateType { Stay, Up, Success };

	[SerializeField]
	private float addScale = 0.01f;
	[SerializeField]
	private StateType stateType = StateType.Stay;

	Vector3 nowScale = new Vector3(0.01f, 0.01f, 0.01f);

	void Awake()
	{
		gameObject.transform.localScale = nowScale;
	}

	public void StartScaleUp()
	{
		stateType = StateType.Up;
	}

	// Update is called once per frame
	void Update () {
		if (stateType != StateType.Up) return;


		nowScale += new Vector3(addScale, addScale, addScale);
		gameObject.transform.localScale = nowScale;
		// 拡大率1.0fまでいったらおわり
		if(nowScale.x >= 1.0f)
		{
			nowScale.Set(1.0f, 1.0f, 1.0f);
			gameObject.transform.localScale = nowScale;
			stateType = StateType.Success;
		}
	}
}
