using UnityEngine;

namespace UGUI
{
	[AddComponentMenu("UGUI/Button")]
	public class Button : Control
	{
		[HideInInspector]
		public bool value = false;

		public GUIContent content;

		public override void Draw(Rect pos)
		{
			base.Draw(pos);

			value = GUI.Button(pos, content);
		}
	}
}