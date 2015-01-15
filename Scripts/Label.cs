using UnityEngine;

namespace UGUI
{
	[AddComponentMenu("UGUI/Label")]
	public class Label : Control
	{
		public GUIContent content = new GUIContent();

		public override void Draw(Rect pos)
		{
			base.Draw(pos);

			GUI.Label(pos, content);
		}
	}
}