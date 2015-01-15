using UnityEngine;

namespace UGUI
{
	[AddComponentMenu("UGUI/Slider")]
	public class Slider : Control
	{
		public float value = 0;
		public float leftValue = 0;
		public float rightValue = 100;

		public override void Draw(Rect pos)
		{
			base.Draw(pos);

			value = GUI.HorizontalSlider(pos, value, leftValue, rightValue);
		}
	}
}