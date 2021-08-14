using System;
using Packages.com.dehagge.flexiblegridlayout.Runtime;
using UnityEditor;
using UnityEngine;

namespace Packages.com.dehagge.flexiblegridlayout.Editor
{
    [CustomEditor(typeof(FlexibleGridLayout))]
    public class FlexibleGridLayoutEditor : UnityEditor.Editor
    {
        private bool _paddingFoldout;

        private SerializedProperty _padding;
        private SerializedProperty _spacing;
        private SerializedProperty _fitType;
        private SerializedProperty _columns;
        private SerializedProperty _rows;

        private void OnEnable()
        {
            _padding = serializedObject.FindProperty("m_Padding");
            _spacing = serializedObject.FindProperty("spacing");
            _fitType = serializedObject.FindProperty("fitType");
            _columns = serializedObject.FindProperty("columns");
            _rows = serializedObject.FindProperty("rows");
        }

        public override void OnInspectorGUI()
        {
            //do this first to make sure you have the latest version
            serializedObject.Update();

            EditorGUILayout.PropertyField(_padding);
            EditorGUILayout.PropertyField(_spacing);
            EditorGUILayout.PropertyField(_fitType);

            var fitType =
                (FlexibleGridLayout.FitType) Enum.GetValues(typeof(FlexibleGridLayout.FitType)).GetValue(_fitType.enumValueIndex);

            switch (fitType)
            {
                case FlexibleGridLayout.FitType.FixedColumns:
                    EditorGUILayout.PropertyField(_columns);
                    break;
                case FlexibleGridLayout.FitType.FixedRows:
                    EditorGUILayout.PropertyField(_rows);
                    break;
                case FlexibleGridLayout.FitType.Uniform:
                    break;
                case FlexibleGridLayout.FitType.Width:
                    break;
                case FlexibleGridLayout.FitType.Height:
                    break;
                case FlexibleGridLayout.FitType.FixedGrid:
                    EditorGUILayout.PropertyField(_columns);
                    EditorGUILayout.PropertyField(_rows);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
