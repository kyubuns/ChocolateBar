using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ChocolateBar
{
	public class CreateConfigFile
	{
		[MenuItem("Assets/Create/ChocolateBar/Config")]
		public static void CreateConfig()
		{
			var config = CreateAsset<ProjectionConfig>();
			config.ScreenPositions = new List<Vector2>();
			config.ScreenPositions.Add(new Vector2(0.0f, 0.0f));
			config.ScreenPositions.Add(new Vector2(1.0f, 0.0f));
			config.ScreenPositions.Add(new Vector2(0.0f, 1.0f));
			config.ScreenPositions.Add(new Vector2(1.0f, 1.0f));
			
			config.TexturePositions = new List<Vector2>();
			config.TexturePositions.Add(new Vector2(0.0f, 0.0f));
			config.TexturePositions.Add(new Vector2(1.0f, 0.0f));
			config.TexturePositions.Add(new Vector2(0.0f, 1.0f));
			config.TexturePositions.Add(new Vector2(1.0f, 1.0f));
		}
		
		public static T CreateAsset<T>() where T : ScriptableObject
		{
			var item = ScriptableObject.CreateInstance<T>();
			string path = AssetDatabase.GenerateUniqueAssetPath("Assets/" + typeof(T) + ".asset");
			AssetDatabase.CreateAsset(item, path);
			AssetDatabase.SaveAssets();
			EditorUtility.FocusProjectWindow();
			Selection.activeObject = item;
			return item;
		}
	}
}