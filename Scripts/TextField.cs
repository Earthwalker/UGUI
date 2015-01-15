using UnityEngine;

namespace UGUI
{
	[AddComponentMenu("UGUI/Textfield")]
	public class TextField : Control
	{
		public string text = "";
		public int maxLength = 32;

		public override void Draw(Rect pos)
		{
			base.Draw(pos);

			text = GUI.TextField(pos, text, maxLength);
		}
	}
}