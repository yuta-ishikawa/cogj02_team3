using UnityEngine;
using System;

// フェードイン・アウトに設定するパラメーター群
[System.Serializable]
public class FadeParam
{
	[SerializeField]
	private float _time = 0.0f;
	public	float time
	{
		get { return _time; }
		private set { _time = value; }
	}

	[SerializeField]
	private Color _color = new Color(0.0f, 0.0f, 0.0f);
	public	Color color
	{
		get { return _color; }
		private set { _color = value; }
	}
}
