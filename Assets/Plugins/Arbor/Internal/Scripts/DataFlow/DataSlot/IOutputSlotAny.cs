﻿//-----------------------------------------------------
//            Arbor 3: FSM & BT Graph Editor
//		  Copyright(c) 2014-2021 caitsithware
//-----------------------------------------------------
using UnityEngine;
using System.Collections;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// 任意の型の出力スロットを定義するインターフェイス
	/// </summary>
#else
	/// <summary>
	/// Interface that defines an output slot of any type
	/// </summary>
#endif
	public interface IOutputSlotAny
	{
#if ARBOR_DOC_JA
		/// <summary>
		/// 値を設定する。
		/// </summary>
		/// <typeparam name="T">値の型</typeparam>
		/// <param name="value">値</param>
#else
		/// <summary>
		/// Set the value.
		/// </summary>
		/// <typeparam name="T">Value type</typeparam>
		/// <param name="value">Value</param>
#endif
		void SetValue<T>(T value);

#if ARBOR_DOC_JA
		/// <summary>
		/// 値を取得する。
		/// </summary>
		/// <typeparam name="T">値の型</typeparam>
		/// <returns>値を返す。</returns>
#else
		/// <summary>
		/// Get the value.
		/// </summary>
		/// <typeparam name="T">Value type</typeparam>
		/// <returns>Returns a value.</returns>
#endif
		T GetValue<T>();
	}
}