﻿//-----------------------------------------------------
//            Arbor 3: FSM & BT Graph Editor
//		  Copyright(c) 2014-2021 caitsithware
//-----------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;

namespace ArborEditor
{
	public sealed class ReorderableListEx : ReorderableList
	{
		static readonly RectOffset s_EntryBackPadding = new RectOffset(2, 2, 0, 0);

		public ReorderableListEx(IList elements, Type elementType) : base(elements, elementType)
		{
			Initialize();
		}

		public ReorderableListEx(IList elements, Type elementType, bool draggable, bool displayHeader, bool displayAddButton, bool displayRemoveButton) : base(elements, elementType, draggable, displayHeader, displayAddButton, displayRemoveButton)
		{
			Initialize();
		}

		public ReorderableListEx(SerializedObject serializedObject, SerializedProperty elements) : base(serializedObject, elements)
		{
			Initialize();
		}

		public ReorderableListEx(SerializedObject serializedObject, SerializedProperty elements, bool draggable, bool displayHeader, bool displayAddButton, bool displayRemoveButton) : base(serializedObject, elements, draggable, displayHeader, displayAddButton, displayRemoveButton)
		{
			Initialize();
		}

		void Initialize()
		{
			drawElementBackgroundCallback = DrawElementBackground;
		}

		void DrawElementBackground(Rect rect, int index, bool isActive, bool isFocused)
		{
			if (Event.current.type != EventType.Repaint)
			{
				return;
			}

			if (index >= 0)
			{
				if (elementHeightCallback != null)
				{
					rect.height = elementHeightCallback(index);
				}
			}

			if (isActive)
			{
				defaultBehaviours.DrawElementBackground(rect, index, isActive, isFocused, false);
			}
			else
			{
				rect = s_EntryBackPadding.Remove(rect);

				GUIStyle style = ((index + 1) % 2 == 0) ? Styles.entryBackEven : Styles.entryBackOdd;
				style.Draw(rect, GUIContent.none, false, false, false, isFocused);
			}
		}
	}
}