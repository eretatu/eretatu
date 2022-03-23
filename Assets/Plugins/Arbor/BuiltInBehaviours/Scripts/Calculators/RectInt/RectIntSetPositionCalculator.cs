﻿//-----------------------------------------------------
//            Arbor 3: FSM & BT Graph Editor
//		  Copyright(c) 2014-2021 caitsithware
//-----------------------------------------------------
using UnityEngine;

namespace Arbor.Calculators
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 矩形の位置を設定する。
	/// </summary>
#else
	/// <summary>
	/// Sets the position of the rect.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("RectInt/RectInt.SetPosition")]
	[BehaviourTitle("RectInt.SetPosition")]
	[BuiltInBehaviour]
	public sealed class RectIntSetPositionCalculator : Calculator
	{
		#region Serialize fields

		/// <summary>
		/// RectInt
		/// </summary>
		[SerializeField] private FlexibleRectInt _RectInt = new FlexibleRectInt();

#if ARBOR_DOC_JA
		/// <summary>
		/// 矩形の位置
		/// </summary>
#else
		/// <summary>
		/// the position of the rect.
		/// </summary>
#endif
		[SerializeField] private FlexibleVector2Int _Position = new FlexibleVector2Int();

#if ARBOR_DOC_JA
		/// <summary>
		/// 結果出力
		/// </summary>
#else
		/// <summary>
		/// Output result
		/// </summary>
#endif
		[SerializeField] private OutputSlotRectInt _Result = new OutputSlotRectInt();

		#endregion // Serialize fields

		// Use this for calculate
		public override void OnCalculate()
		{
			RectInt value = _RectInt.value;
			value.position = _Position.value;
			_Result.SetValue(value);
		}
	}
}