//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;

//[CustomEditor(typeof(LevelData))]
//public class LevelSpawnEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        serializedObject.Update();
//        SerializedProperty spawnList = serializedObject.FindProperty("spawns");
//        spawnList.arraySize = EditorGUILayout.IntField("Vehicle Spawn Size", spawnList.arraySize);

//        EditorGUILayout.BeginHorizontal();
//        EditorGUILayout.LabelField("No.", EditorStyles.boldLabel, GUILayout.Width(25));
//        EditorGUILayout.LabelField("Vehicle", EditorStyles.boldLabel, GUILayout.MaxWidth(100));
//        EditorGUILayout.LabelField("Spawn Point", EditorStyles.boldLabel, GUILayout.Width(120));
//        EditorGUILayout.LabelField("Spawn Time", EditorStyles.boldLabel, GUILayout.Width(80));
//        EditorGUILayout.EndHorizontal();

//        for (int i = 0; i < spawnList.arraySize; i++)
//        {
//            EditorGUILayout.BeginHorizontal();
//            EditorGUILayout.LabelField($"{i + 1}", GUILayout.Width(25));
//            EditorGUILayout.PropertyField(spawnList.GetArrayElementAtIndex(i).FindPropertyRelative("vehicleType"), GUIContent.none, GUILayout.MaxWidth(100));
//            EditorGUILayout.PropertyField(spawnList.GetArrayElementAtIndex(i).FindPropertyRelative("spawnPoint"), GUIContent.none, GUILayout.Width(120));
//            EditorGUILayout.PropertyField(spawnList.GetArrayElementAtIndex(i).FindPropertyRelative("spawnTime"), GUIContent.none, GUILayout.Width(80));

//            //if (GUILayout.Button("+", GUILayout.Width(30))) { spawnList.InsertArrayElementAtIndex(i); }
//            //if (GUILayout.Button("-", GUILayout.Width(30))) { spawnList.DeleteArrayElementAtIndex(i); }
//            //if (GUILayout.Button("↑", GUILayout.Width(30))) { spawnList.MoveArrayElement(i, i - 1); }
//            //if (GUILayout.Button("↓", GUILayout.Width(30))) { spawnList.MoveArrayElement(i, i + 1); }

//            EditorGUILayout.EndHorizontal();
//        }

//        if (serializedObject.hasModifiedProperties)
//        {
//            serializedObject.ApplyModifiedProperties();
//        }
//    }
//}
