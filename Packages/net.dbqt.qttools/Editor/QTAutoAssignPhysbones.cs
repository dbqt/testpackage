namespace QTTools
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;
    using VRC.SDK3.Dynamics.PhysBone.Components;

    public class QTAutoAssignPhysbones : MonoBehaviour
    {
        [MenuItem("QT Tools/Auto-assign Physbones")]
        public static void Open()
        {
            EditorWindow window = EditorWindow.CreateInstance<QTAutoAssignPhysbonesWindow>();
            window.Show();
        }
    }

    public class QTAutoAssignPhysbonesWindow : EditorWindow
    {
        private Object root;
        private Vector2 scrollPos = Vector2.zero;
        private Rect assignBoneButton;

        private void OnGUI()
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

            GUILayout.Label("Automatically assign physbones that don't have a root.");
            GUILayout.Label("Base object (avatar)");
            root = EditorGUILayout.ObjectField(root, typeof(GameObject), true);
            EditorGUILayout.EndScrollView();

            if (GUILayout.Button("Assign physbones", GUILayout.Width(200)))
            {
                GameObject rootGameObject = root as GameObject;
                if (rootGameObject != null)
                {
                    int count = 0;
                    var physbones = rootGameObject.GetComponentsInChildren<VRCPhysBone>();
                    foreach (var physbone in physbones)
                    {
                        if (physbone.rootTransform == null)
                        {
                            physbone.rootTransform = physbone.gameObject.transform;
                            count++;
                        }
                    }

                    if (count > 0)
                    {
                        EditorUtility.DisplayDialog("Success", $"{count} physbones have been assigned.", "OK");
                    }
                    else
                    {
                        EditorUtility.DisplayDialog("Error", $"{count} physbones have been assigned.", "OK");
                    }
                }
                else
                {
                    EditorUtility.DisplayDialog("Error", $"Please assign a valid GameObject", "OK");
                }
            }

            if (Event.current.type == EventType.Repaint) assignBoneButton = GUILayoutUtility.GetLastRect();
        }
    }
}
