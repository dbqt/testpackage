namespace QTTools
{
    using UnityEditor;
    using UnityEngine;
    using System.Linq;

    public class QTReassignArmature : MonoBehaviour
    {
        [MenuItem("QT Tools/Reassign Armature")]
        public static void Open()
        {
            EditorWindow window = EditorWindow.CreateInstance<QTReassignArmatureWindow>();
            window.Show();
        }
    }

    public class QTReassignArmatureWindow : EditorWindow
    {
        private Object mesh;
        private SkinnedMeshRenderer skinnedMeshRenderer;
        private Object armature;
        private GameObject armatureGameObject;
        private bool ignoreMissingBones;

        private Vector2 scrollPos = Vector2.zero;

        private Rect assignBoneButton;

        private void OnGUI()
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

            // Get mesh
            GUILayout.Label("Skinned Mesh Renderer to modify");
            mesh = EditorGUILayout.ObjectField(mesh, typeof(SkinnedMeshRenderer), true);
            if (mesh == null)
            {
                EditorGUILayout.HelpBox("The mesh is missing.", MessageType.Error);
            }
            else
            {
                skinnedMeshRenderer = mesh as SkinnedMeshRenderer;
                if (skinnedMeshRenderer == null)
                {
                    EditorGUILayout.HelpBox("The mesh is invalid.", MessageType.Error);
                }
            }

            GUILayout.Space(8);

            // Get armature
            GUILayout.Label("Armature to assign to the Mesh Renderer");
            armature = EditorGUILayout.ObjectField(armature, typeof(GameObject), true);
            if (armature == null)
            {
                EditorGUILayout.HelpBox("The armature is missing.", MessageType.Error);
            }
            else
            {
                armatureGameObject = armature as GameObject;
                if (armatureGameObject == null)
                {
                    EditorGUILayout.HelpBox("The armature is invalid.", MessageType.Error);
                }
            }

            GUILayout.Space(8);

            ignoreMissingBones = GUILayout.Toggle(ignoreMissingBones, "Ignore missing bones");
            EditorGUILayout.HelpBox("This option may not work properly if important bones are missing. Use at your own risk!", MessageType.Info);
            GUILayout.Space(8);

            

            // Early exit if missing something
            if (skinnedMeshRenderer == null || armatureGameObject == null)
            {
                EditorGUILayout.EndScrollView();
                return;
            }

            EditorGUILayout.EndScrollView();

            if (GUILayout.Button("Assign armature", GUILayout.Width(200)))
            {
                var bones = skinnedMeshRenderer.bones;

                // Assign equivalent root bone
                var rootbone = armatureGameObject.transform.Find(skinnedMeshRenderer.rootBone.name);
                if (rootbone == null && !ignoreMissingBones)
                {
                    EditorUtility.DisplayDialog("Error", $"Could not find root bone {rootbone.name}", "OK");
                    return;
                }

                skinnedMeshRenderer.rootBone = rootbone;

                // Get every other bones
                var armatureTransforms = armatureGameObject.transform.GetComponentsInChildren<Transform>();
                for (int i = 0; i < bones.Length; i++)
                {
                    var name = bones[i].name;
                    var equivalentBone = armatureTransforms.FirstOrDefault(t => t.name.Equals(name));
                    if (equivalentBone != null)
                    {
                        bones[i] = equivalentBone;
                    }
                    else if (!ignoreMissingBones)
                    {
                        EditorUtility.DisplayDialog("Error", $"The bone {name} was not found on the armature.", "OK");
                        return;
                    }
                }

                // Assign the bones to the skinned mesh renderer
                skinnedMeshRenderer.bones = bones;

                EditorUtility.DisplayDialog("Done", $"The armature has been assigned.", "OK");
            }

            if (Event.current.type == EventType.Repaint) assignBoneButton = GUILayoutUtility.GetLastRect();
        }
    }
}
