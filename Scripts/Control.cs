using UnityEngine;

namespace UGUI
{
	[AddComponentMenu("UGUI/Control")]
	public class Control : MonoBehaviour
	{
		public string controlName = "control";
		public bool visible = true;
		public Rect position = new Rect(32, 32, 128, 32);
		public Vector2 anchor = Vector2.zero;
		public Color color = Color.white;

		[HideInInspector]
		public GUIStyle style = new GUIStyle();

		public void SnapToGrid(int gridSize)
		{
			if (gridSize < 1)
				gridSize = 1;

			position = new Rect(Mathf.RoundToInt(position.x / gridSize) * gridSize,
								Mathf.RoundToInt(position.y / gridSize) * gridSize,
								Mathf.RoundToInt(position.width / gridSize) * gridSize,
								Mathf.RoundToInt(position.height / gridSize) * gridSize);
		}

		public void SnapToGrid()
		{
			if (GetComponent<Settings>())
				SnapToGrid(GetComponent<Settings>().gridSize);
			else
			{
#if UNITY_EDITOR
				SnapToGrid(UnityEditor.EditorWindow.GetWindow<Manager>("UGUI", false).gridSize);
#endif
			}
		}

		public void OnGUI()
		{
			Rect pos = position;

			if (anchor.x >= 1)
				pos.x = Screen.width - pos.x;
			if (anchor.y >= 1)
				pos.y = Screen.height - pos.y;

			Draw(pos);
		}

		public virtual void Draw(Rect pos)
		{
			GUI.color = color;
		}
	}
}