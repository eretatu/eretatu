﻿//-----------------------------------------------------
//            Arbor 3: FSM & BT Graph Editor
//		  Copyright(c) 2014-2021 caitsithware
//-----------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using System.Reflection; // Required for UWP (.Net) builds
using UnityEngine;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// パラメータ関連ユーティリティクラス
	/// </summary>
#else
	/// <summary>
	/// Parameter related utility class
	/// </summary>
#endif
	public static class ParameterUtility
	{
		private static readonly Dictionary<Parameter.Type, ParameterValueTypeAttribute> _Attributes;

		static ParameterUtility()
		{
			_Attributes = new Dictionary<Parameter.Type, ParameterValueTypeAttribute>();

			var typeParameterType = typeof(Parameter.Type);
			foreach (Parameter.Type type in System.Enum.GetValues(typeParameterType))
			{
				var fieldInfo = typeParameterType.GetField(type.ToString());
				var valueTypeAttribute = AttributeHelper.GetAttribute<ParameterValueTypeAttribute>(fieldInfo);
				if (valueTypeAttribute != null)
				{
					_Attributes.Add(type, valueTypeAttribute);
				}
				else
				{
					throw new System.NotImplementedException("not implemented ParameterValueTypeAttribute : " + type);
				}
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// パラメータの値の型を取得する。
		/// </summary>
		/// <param name="type">パラメータのタイプ</param>
		/// <param name="referenceType">参照する型（Enum, Component, Variableで使用）</param>
		/// <returns>パラメータの値の型</returns>
#else
		/// <summary>
		/// Get the value type of the parameter.
		/// </summary>
		/// <param name="type">Type of parameter</param>
		/// <param name="referenceType">Reference type (used for Enum, Component, Variable)</param>
		/// <returns>Value type of the parameter</returns>
#endif
		public static System.Type GetValueType(Parameter.Type type, System.Type referenceType = null)
		{
			ParameterValueTypeAttribute valueTypeAttribute = null;
			if (_Attributes.TryGetValue(type, out valueTypeAttribute))
			{
				if (valueTypeAttribute.useReferenceType && referenceType != null)
				{
					if (valueTypeAttribute.toList)
					{
						return ListUtility.GetIListType(referenceType);
					}

					return referenceType;
				}

				return valueTypeAttribute.type;
			}

			throw new System.NotImplementedException("It is an unimplemented Parameter type(" + type + ")");
		}
	}
}