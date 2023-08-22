namespace QTTools
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;

    public class QTResetPrefab : MonoBehaviour
    {
        [MenuItem("QT Tools/Reset transforms to prefab")]
        public static void Open()
        {
            EditorWindow window = EditorWindow.CreateInstance<ResetTransformToPrefabStateWindow>();
            window.Show();
        }
    }

    public class ResetTransformToPrefabStateWindow : EditorWindow
    {
        public Transform[] transforms = { };
        private Vector2 scrollPos = Vector2.zero;
        private Rect resetButton;

        private void OnGUI()
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

            GUILayout.Label("Put transforms to reset to prefab values");

            ScriptableObject target = this;
            SerializedObject so = new SerializedObject(target);
            SerializedProperty stringsProperty = so.FindProperty("transforms");

            EditorGUILayout.PropertyField(stringsProperty, true);
            so.ApplyModifiedProperties(); // Save changes

            EditorGUILayout.EndScrollView();

            GUILayout.Space(10);
            if (GUILayout.Button("Reset to prefab state", GUILayout.Width(200)))
            {
                foreach (var tranform in transforms)
                {
                    PrefabUtility.RevertObjectOverride(tranform, InteractionMode.UserAction);
                }
                EditorUtility.DisplayDialog("Success", "Done", "OK");
            }

            if (Event.current.type == EventType.Repaint) resetButton = GUILayoutUtility.GetLastRect();
        }
    }
}
