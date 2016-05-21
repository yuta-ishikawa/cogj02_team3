using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateMyAssets : MonoBehaviour {

	[MenuItem("Assets/Create/CreateResultText")]
	public static void CreateResultText()
	{
		// オブジェクト生成
		ResultTextObject obj = ScriptableObject.CreateInstance<ResultTextObject>();

		// オブジェクトを保存するパス
		string path = AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/Data/" + typeof(ResultTextObject) + ".asset");

		AssetDatabase.CreateAsset(obj, path);
		AssetDatabase.SaveAssets();

		EditorUtility.FocusProjectWindow();
		Selection.activeObject = obj;
	}

	[MenuItem("Assets/Create/CreateResultFaceImages")]
	public static void CreateFaceImages()
	{
		// オブジェクト生成
		ResultFaceImageObject obj = ScriptableObject.CreateInstance<ResultFaceImageObject>();

		// オブジェクトを保存するパス
		string path = AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/Data/" + typeof(ResultFaceImageObject) + ".asset");

		AssetDatabase.CreateAsset(obj, path);
		AssetDatabase.SaveAssets();

		EditorUtility.FocusProjectWindow();
		Selection.activeObject = obj;
	}

	[MenuItem("Assets/Create/CreateResultVoices")]
	public static void CreateResultVoices()
	{
		// オブジェクト生成
		ResultVoiceObject obj = ScriptableObject.CreateInstance<ResultVoiceObject>();

		// オブジェクトを保存するパス
		string path = AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/Data/" + typeof(ResultVoiceObject) + ".asset");

		AssetDatabase.CreateAsset(obj, path);
		AssetDatabase.SaveAssets();

		EditorUtility.FocusProjectWindow();
		Selection.activeObject = obj;
	}

	[MenuItem("Assets/Create/CreateTensionStatus")]
	public static void CreateTensionStatus()
	{
		// オブジェクト生成
		TensionStatusObject obj = ScriptableObject.CreateInstance<TensionStatusObject>();

		// オブジェクトを保存するパス
		string path = AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/Data/" + typeof(TensionStatusObject) + ".asset");

		AssetDatabase.CreateAsset(obj, path);
		AssetDatabase.SaveAssets();

		EditorUtility.FocusProjectWindow();
		Selection.activeObject = obj;
	}

	[MenuItem("Assets/Create/CreateTensionTable")]
	public static void CreateTensionTable()
	{
		// オブジェクト生成
		TensionTableObject obj = ScriptableObject.CreateInstance<TensionTableObject>();

		// オブジェクトを保存するパス
		string path = AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/Data/" + typeof(TensionTableObject) + ".asset");

		AssetDatabase.CreateAsset(obj, path);
		AssetDatabase.SaveAssets();

		EditorUtility.FocusProjectWindow();
		Selection.activeObject = obj;
	}
}
