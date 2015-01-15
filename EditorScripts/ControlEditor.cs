#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace UGUI
{
	[CustomEditor(typeof(Control), true)]
	public class ControlEditor : Editor
	{
		Vector3 posHandle = Vector3.zero;
		Vector3 sizeHandle = Vector3.zero;
		GUISkin skin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Game);

		void OnSceneGUI()
		{
			Control myTarget = (Control)target;

			GUI.skin = skin;

			if (myTarget.visible)
			{
				Rect pos = myTarget.position;
				SceneView scene = SceneView.lastActiveSceneView;

				if (myTarget.anchor.x > 0)
					pos.x = scene.camera.pixelWidth - pos.x;

				if (myTarget.anchor.y > 0)
					pos.y = scene.camera.pixelHeight - pos.y;

				Handles.BeginGUI();

				Vector3[] verts = new Vector3[] { pos.position, 
												  new Vector2(pos.x + pos.width, pos.y), 
												  pos.position + pos.size, 
												  new Vector2(pos.x, pos.y + pos.height) };

				Handles.DrawSolidRectangleWithOutline(verts, Color.clear, Color.black);

				myTarget.Draw(pos);

				Handles.EndGUI();

				posHandle = HandleUtility.GUIPointToWorldRay(pos.position).origin;
				posHandle = Handles.FreeMoveHandle(HandleUtility.GUIPointToWorldRay(pos.position).origin,
									Quaternion.identity,
									HandleUtility.GetHandleSize(posHandle) * .1f,
									Vector2.zero,
									Handles.RectangleCap);

				Vector2 guiPos = HandleUtility.WorldToGUIPoint(posHandle);

				if(myTarget.anchor.x < 1)
					myTarget.position.x = guiPos.x;
				else
					myTarget.position.x = scene.camera.pixelWidth - guiPos.x;

				if (myTarget.anchor.y < 1)
					myTarget.position.y = guiPos.y;
				else
					myTarget.position.y = scene.camera.pixelHeight - guiPos.y;

				//myTarget.position = guiPos;

				sizeHandle = HandleUtility.GUIPointToWorldRay(pos.position + pos.size).origin;
				sizeHandle = Handles.FreeMoveHandle(sizeHandle,
									Quaternion.identity,
									HandleUtility.GetHandleSize(sizeHandle) * .1f,
									Vector2.zero,
									Handles.RectangleCap);

				pos.size = HandleUtility.WorldToGUIPoint(sizeHandle) - pos.position;

				myTarget.position.size = pos.size;

				myTarget.SnapToGrid();

				if (GUI.changed)
					EditorUtility.SetDirty(target);
			}
		}
	}
}
#endif