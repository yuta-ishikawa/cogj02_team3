using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnityChanTensionStatus : MonoBehaviour {

	[SerializeField]
	private TensionStatusObject tensionStatus;
	[SerializeField]
	private TensionTableObject tensionTable;
	
	private SpriteRenderer spriteRender;

	// 適当にテーブル設定
	private int GetTensionStatus()
	{
		int score = GameManager.Instance.GetScore();
		int spriteNum = 0;
		// 現在のスコアに応じた値を返す
		// スコアが良いほどループが長くなる
		foreach (var num in tensionTable.table)
		{
			if (score <= num) return spriteNum;
			++spriteNum;
		}
		return spriteNum;
	}

	private void SetSprite() { spriteRender.sprite = tensionStatus.tensionSprites[GetTensionStatus()]; }

	// Use this for initialization
	void Start () {
		spriteRender = GetComponent<SpriteRenderer>();
		SetSprite();
	}
	
	// Update is called once per frame
	void Update () {
		// ここで更新
		SetSprite();
	}
}
