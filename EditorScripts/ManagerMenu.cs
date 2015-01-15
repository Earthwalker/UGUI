#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace UGUI
{
	public class ManagerMenu : MonoBehaviour
	{
		[MenuItem("Window/UGUI")]
		static void Settings()
		{
			EditorWindow.GetWindow<Manager>();
		}
	}
}
#endif