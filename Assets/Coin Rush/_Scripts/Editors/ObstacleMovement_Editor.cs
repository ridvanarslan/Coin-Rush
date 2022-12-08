using CoinRush.Helpers;
using CoinRush.Obstacle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEditor.TerrainTools;
using UnityEngine;
using CoinRush.Enums;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CoinRush.Editors
{
#if UNITY_EDITOR
    [CustomEditor(typeof(ObstacleMovement))]
    public class ObstacleMovement_Editor : Editor
    {
        #region SerializedProperties
        SerializedProperty movementType;
        SerializedProperty rotateTime;
        SerializedProperty rotateDirection;
        SerializedProperty yoyoTime;
        SerializedProperty yoyoRange;
        #endregion


        private void OnEnable()
        {
            movementType = serializedObject.FindProperty("movementType");
            rotateTime = serializedObject.FindProperty("rotateTime");
            rotateDirection = serializedObject.FindProperty("rotateDirection");
            yoyoTime = serializedObject.FindProperty("yoyoTime");
            yoyoRange = serializedObject.FindProperty("yoyoRange");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(movementType);

            if (movementType.enumValueIndex != (int)MovementType.None)
            {
                if (movementType.enumValueIndex == (int)MovementType.Rotate)
                    ShowRotateSettings();
                else if (movementType.enumValueIndex == (int)MovementType.YoYo)
                    ShowYoyoSettings();
                else
                {
                    ShowRotateSettings();
                    ShowYoyoSettings();
                }
            }



            serializedObject.ApplyModifiedProperties();

            #region Local Functions

            void ShowRotateSettings()
            {
                EditorGUILayout.PropertyField(rotateTime);
                EditorGUILayout.PropertyField(rotateDirection);
            }

            void ShowYoyoSettings()
            {
                EditorGUILayout.PropertyField(yoyoTime);
                EditorGUILayout.PropertyField(yoyoRange);
            }

            #endregion
        }
    }
#endif
}
