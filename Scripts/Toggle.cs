using UnityEngine;

namespace UGUI
{
	[AddComponentMenu("UGUI/Toggle")]
	public class Toggle : Control
	{
		public bool value = false;
		public GUIContent content = new GUIContent();

		public override void Draw(Rect pos)
		{
			base.Draw(pos);

			value = GUI.Toggle(pos, value, content);
		}
	}
}