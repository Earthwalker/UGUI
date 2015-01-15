#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace UGUI
{
	public class Manager : EditorWindow
	{
		public int gridSize = 32;

		void OnGUI()
		{
			int newGridSize = EditorGUILayout.IntField("Grid Size", gridSize);

			if (newGridSize < 1)
				newGridSize = 1;

			if (newGridSize != gridSize)
			{
				gridSize = newGridSize;

				foreach (Control control in FindObjectsOfType<Control>())
					control.SnapToGrid(gridSize);
			}
		}
	}
}
#endif