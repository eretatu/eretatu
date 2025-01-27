﻿//-----------------------------------------------------
//            Arbor 3: FSM & BT Graph Editor
//		  Copyright(c) 2014-2021 caitsithware
//-----------------------------------------------------
using UnityEngine;
using UnityEditor;

namespace ArborEditor.Calculators
{
	using Arbor;
	using Arbor.Calculators;

	[CustomEditor(typeof(RandomSelectComponent))]
	internal sealed class RandomSelectComponentInspector : NodeBehaviourEditor
	{
		SerializedProperty _WeightsProperty;
		OutputSlotComponentProperty _OutputProperty;
		
		private void OnEnable()
		{
			_WeightsProperty = serializedObject.FindProperty("_Weights");
			_OutputProperty = new OutputSlotComponentProperty(serializedObject.FindProperty("_Output"));
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			var oldReferenceType = _OutputProperty.type;
			EditorGUI.BeginChangeCheck();
			EditorGUILayout.PropertyField(_OutputProperty.typeProperty.property);
			if (EditorGUI.EndChangeCheck())
			{
				var newReferenceType = _OutputProperty.type;
				if (oldReferenceType != newReferenceType)
				{
					var valuesProperty = _WeightsProperty.FindPropertyRelative("_Values");
					for (int i = 0; i < valuesProperty.arraySize; i++)
					{
						FlexibleComponentProperty componentProperty = new FlexibleComponentProperty(valuesProperty.GetArrayElementAtIndex(i));
						componentProperty.Disconnect();
					}
					
					_OutputProperty.Disconnect();

					serializedObject.ApplyModifiedProperties();

					GUIUtility.ExitGUI();
				}
			}

			EditorGUILayout.PropertyField(_WeightsProperty);

			EditorGUILayout.PropertyField(_OutputProperty.property);

			serializedObject.ApplyModifiedProperties();
		}
	}
}