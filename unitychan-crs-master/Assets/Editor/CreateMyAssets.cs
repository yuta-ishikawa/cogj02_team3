using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateMyAssets : MonoBehaviour {

	// ScriptableObject生成コマンド用テンプレート
	public static void CreateAssets<T>() where T : ScriptableObject{
		// オブジェクト生成
		T obj = ScriptableObject.CreateInstance<T>();

		// オブジェクトを保存するパス
		string path = AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/Data/" + typeof(T) + ".asset");
		AssetDatabase.CreateAsset(obj, path);
		AssetDatabase.SaveAssets();

		EditorUtility.FocusProjectWindow();
		Selection.activeObject = obj;
	}

	[MenuItem("Assets/Create/CreateResultText")]
	public static void CreateResultText()
	{
		CreateAssets<ResultTextObject>();
	}

	[MenuItem("Assets/Create/CreateResultFaceImages")]
	public static void CreateFaceImages()
	{
		CreateAssets<ResultFaceImageObject>();
	}

	[MenuItem("Assets/Create/CreateResultVoices")]
	public static void CreateResultVoices()
	{
		CreateAssets<ResultVoiceObject>();
	}

	[MenuItem("Assets/Create/CreateTensionStatus")]
	public static void CreateTensionStatus()
	{
		CreateAssets<TensionStatusObject>();
	}

	[MenuItem("Assets/Create/CreateMotionOrder")]
	public static void CreateMotionOrder() {
		CreateAssets<MotionOrderObject> ();
	}

	[MenuItem("Assets/Create/CreateMotionOrders")]
	public static void CreateMotionOrders() {
		CreateAssets<MotionOrderObjects> ();
	}

	[MenuItem("Assets/Create/CreateVoiceObject")]
	public static void CreateVoiceObject() {
		CreateAssets<VoiceObject> ();
	}
	
	[MenuItem("Assets/Create/CreateTensionTable")]
	public static void CreateTensionTable()
	{
		CreateAssets<TensionTableObject>();
	}
}
