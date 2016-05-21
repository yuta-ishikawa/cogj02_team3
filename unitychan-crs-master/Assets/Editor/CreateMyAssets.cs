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

	[MenuItem("Assets/Create/CreateMotionOrder")]
	public static void CreateMotionOrder() {
		CreateAssets<MotionOrderObject> ();
	}

	[MenuItem("Assets/Create/CreateMotionOrders")]
	public static void CreateMotionOrders() {
		CreateAssets<MotionOrderObjects> ();
	}

}
