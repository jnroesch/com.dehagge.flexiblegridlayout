using System;
using Packages.com.dehagge.flexiblegridlayout.Runtime;
using UnityEditor;

namespace Packages.com.dehagge.flexiblegridlayout.Editor
{
    [CustomEditor(typeof(FlexibleGridLayout))]
    public class FlexibleGridLayoutEditor : UnityEditor.Editor
    {
        private bool _paddingFoldout;
        
        public override void OnInspectorGUI()
        {
            var flexibleGridLayout = target as FlexibleGridLayout;
            
            _paddingFoldout = EditorGUILayout.Foldout(_paddingFoldout, "Padding");
            if (_paddingFoldout)
            {
                var indentLevel = EditorGUI.indentLevel;
                EditorGUI.indentLevel++;
                
                flexibleGridLayout.padding.left = EditorGUILayout.IntField("Left", flexibleGridLayout.padding.left);
                flexibleGridLayout.padding.right = EditorGUILayout.IntField("Right", flexibleGridLayout.padding.right);
                flexibleGridLayout.padding.top = EditorGUILayout.IntField("Top", flexibleGridLayout.padding.top);
                flexibleGridLayout.padding.bottom = EditorGUILayout.IntField("Bottom", flexibleGridLayout.padding.bottom);
                
                //reset indent level
                EditorGUI.indentLevel = indentLevel;
            }

            flexibleGridLayout.spacing = EditorGUILayout.Vector2Field("Spacing", flexibleGridLayout.spacing);

            flexibleGridLayout.fitType = (FlexibleGridLayout.FitType)EditorGUILayout.EnumPopup("Fit Type", flexibleGridLayout.fitType);

            switch (flexibleGridLayout.fitType)
            {
                case FlexibleGridLayout.FitType.FixedColumns:
                    flexibleGridLayout.columns = EditorGUILayout.IntField("Columns", flexibleGridLayout.columns);
                    break;
                case FlexibleGridLayout.FitType.FixedRows:
                    flexibleGridLayout.rows = EditorGUILayout.IntField("Rows", flexibleGridLayout.rows);
                    break;
                case FlexibleGridLayout.FitType.Uniform:
                    break;
                case FlexibleGridLayout.FitType.Width:
                    break;
                case FlexibleGridLayout.FitType.Height:
                    break;
                case FlexibleGridLayout.FitType.FixedGrid:
                    flexibleGridLayout.columns = EditorGUILayout.IntField("Columns", flexibleGridLayout.columns);
                    flexibleGridLayout.rows = EditorGUILayout.IntField("Rows", flexibleGridLayout.rows);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            flexibleGridLayout.CalculateLayoutInputVertical();
        }
    }
}
