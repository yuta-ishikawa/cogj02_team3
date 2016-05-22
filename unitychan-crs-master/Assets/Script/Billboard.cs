using UnityEngine;
using System.Collections;


// 自前のビルボードコンポーネント
public class Billboard : MonoBehaviour {

	// カメラに描画される範囲に居る場合のみ処理
	void OnWillRenderObject()
	{
		transform.rotation = Camera.current.transform.rotation;
	}
}
