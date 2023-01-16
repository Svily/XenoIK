﻿

using System;
using UnityEditor;
using UnityEngine;

namespace XenoIK.Editor
{
    public class IKSolverInspector
    {
        public delegate void DrawElement(SerializedProperty element, int index);
        public delegate void DrawButtons(SerializedProperty prop);
        
        public const float BtnWidth = 20;
        public const float CBtnWidth = 65;
        
        private static SerializedProperty element;
        private static bool isShowList = true;
        
        public static float GetHandleSize(Vector3 position) {
            float s = HandleUtility.GetHandleSize(position) * 0.1f;
            return Mathf.Lerp(s, 0.025f, 0.5f);
        }
        
        public static void DrawElements(SerializedProperty prop, 
            GUIContent guiContent, DrawElement drawElement, DrawButtons drawButtons = null, int index = 0)
        {
            int deleteIndex = -1;
            string headLabel = $"{guiContent.text}({prop.arraySize})";
            isShowList = EditorGUILayout.Foldout(isShowList, headLabel);
            if (!isShowList) return;
            GUILayout.Space(5);
            for (int i = 0; i < prop.arraySize; i++)
            {
                GUILayout.BeginHorizontal();
                GUILayout.BeginVertical();
                element = prop.GetArrayElementAtIndex(i);
                
                GUILayout.BeginHorizontal();
                //Draw Bones Chians
                drawElement(element, i);
                GUILayout.Space(5);
                if (GUILayout.Button(new GUIContent("×", "删除"), EditorStyles.miniButton, GUILayout.Width(BtnWidth)))
                {
                    deleteIndex = i;
                }
                if (GUILayout.Button(new GUIContent("↑", "上移"), EditorStyles.miniButton, GUILayout.Width(BtnWidth)))
                {
                    prop.MoveArrayElement(i, Math.Max(0, i - 1));
                }
                if (GUILayout.Button(new GUIContent("↓", "下移"), EditorStyles.miniButton, GUILayout.Width(BtnWidth)))
                {
                    prop.MoveArrayElement(i, Math.Min(prop.arraySize - 1, i + 1));
                }

                GUILayout.EndHorizontal();
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();
            }
            GUILayout.Space(5);
            // Draw Btns
            drawButtons?.Invoke(prop);
            
            if (deleteIndex != -1)
            {
                prop.DeleteArrayElementAtIndex(deleteIndex);
            }
        }


        public static void AddObjectReference(SerializedProperty prop, GUIContent guiContent, int lableWidth, int propWidth)
        {
            EditorGUILayout.LabelField(guiContent, GUILayout.Width(lableWidth));
            EditorGUILayout.PropertyField(prop, GUIContent.none, GUILayout.Width(propWidth));
        }
        

    }
}