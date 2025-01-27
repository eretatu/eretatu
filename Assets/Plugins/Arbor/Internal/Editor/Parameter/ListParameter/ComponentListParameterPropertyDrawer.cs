﻿//-----------------------------------------------------
//            Arbor 3: FSM & BT Graph Editor
//		  Copyright(c) 2014-2021 caitsithware
//-----------------------------------------------------
using UnityEngine;
using UnityEditor;

namespace ArborEditor
{
	using Arbor;

	internal sealed class ComponentListParameterEditor : ListParameterEditor
	{
		protected override void OnDrawElement(Rect rect, int index, bool isActive, bool isFocused)
		{
			System.Type componentType = property.GetStateData<System.Type>();

			rect.height = EditorGUIUtility.singleLineHeight;

			SerializedProperty valueProperty = _ReorderableList.serializedProperty.GetArrayElementAtIndex(index);

			GUIContent label = EditorGUITools.GetTextContent(valueProperty.displayName);
			label = EditorGUI.BeginProperty(rect, label, valueProperty);

			EditorGUI.BeginChangeCheck();
			Object obj = EditorGUI.ObjectField(rect, label, valueProperty.objectReferenceValue, componentType, true);
			if (EditorGUI.EndChangeCheck())
			{
				valueProperty.objectReferenceValue = obj;
			}

			EditorGUI.EndProperty();
		}
	}

	[CustomPropertyDrawer(typeof(ComponentListParameter))]
	internal sealed class ComponentListParameterPropertyDrawer : PropertyEditorDrawer<ComponentListParameterEditor>
	{
	}
}