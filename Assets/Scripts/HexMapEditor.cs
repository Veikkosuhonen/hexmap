using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;

[CustomEditor(typeof(HexMap))]
public class HexMapEditor : Editor {

    public override void OnInspectorGUI() {

        DrawDefaultInspector();

        var generator = (HexMap)target;

        if (GUILayout.Button("Generate")) {
            Debug.Log("Generating " + generator);
            generator.Generate();
        }

        if (GUILayout.Button("Reset")) {
            Debug.Log("Resetting " + generator);
            generator.ResetMap();
        }
    }
}

#endif