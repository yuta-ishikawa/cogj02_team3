using UnityEngine;
using System;
using System.Collections;

public class ScreenFadeManager : SingletonMonoBehaviour<ScreenFadeManager> {

	// public
	public bool isFadeAction = false;	// フェード中かどうか

	// private
	// フェード用変数
	private Texture2D texture;
	private String sequence = null;
	private Color from;
	private Color to;
	private Color now; 
	private float time;
	private float fadeInTime; 
	private float fadeOutTime;

	// delegate
	public delegate void OnComplete(); 	// delegate
	private OnComplete callBack;		// コールバック


	void Awake() {
		if (this != Instance) {
			Destroy (this);
			return;
		}

		DontDestroyOnLoad (this.gameObject);

		texture = new Texture2D( 1, 1, TextureFormat.ARGB32, false );
		texture.SetPixel(0,0, Color.white );
		texture.Apply();
	}

	void OnGUI () {
		if( now.a != 0 ){
			GUI.color = now;
			GUI.DrawTexture(new Rect( 0, 0, Screen.width, Screen.height ), texture );
		}
	}

	// 共通処理
	void StartSequence ( String function_name ) {
		if( sequence == null ){
			StopCoroutine( sequence );
			sequence = null;
		}
		sequence = function_name;
		StartCoroutine( sequence );
	}

	// フェード処理
	IEnumerator FadeUpdate () {
		float now_time = 0;
		while( 0 < time && now_time < time ){ 
			now_time += Time.deltaTime;
			now = Color.Lerp( from, to, now_time / time );
			yield return 0;
		}
		now = to;
		isFadeAction = false;

		// コールバック
		callBack();
	}

	// フェードインを開始する
	public void FadeIn( float t_time, Color t_color, OnComplete t_cb ) {
		callBack = t_cb;
		to = from = t_color;
		from.a = 0;
		time = t_time;
		this.fadeInTime = time;
		StartSequence( "FadeUpdate" );
	}

	// フェードアウトを開始する
	public void FadeOut( float t_time, Color t_color, OnComplete t_cb ) {
		callBack = t_cb;
		to = from = t_color;
		to.a = 0;
		time = t_time;
		this.fadeOutTime = time;
		StartSequence( "FadeUpdate" );
	}

	public float GetFadeInTime () {
		return this.fadeInTime;
	}

	public float GetFadeOutTime () {
		return this.fadeOutTime;
	}
}
