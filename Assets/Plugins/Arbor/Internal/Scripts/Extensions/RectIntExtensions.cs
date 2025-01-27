﻿//-----------------------------------------------------
//            Arbor 3: FSM & BT Graph Editor
//		  Copyright(c) 2014-2021 caitsithware
//-----------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arbor.Extensions
{
#if ARBOR_DOC_JA
	/// <summary>
	/// RectIntの拡張クラス
	/// </summary>
#else
	/// <summary>
	/// RectInt extension class
	/// </summary>
#endif
	public static class RectIntExtensions
	{
#if ARBOR_DOC_JA
		/// <summary>
		/// RectInt(0, 0, 0, 0)を返す。
		/// </summary>
#else
		/// <summary>
		/// Returns RectInt (0, 0, 0, 0).
		/// </summary>
#endif
		public static RectInt zero
		{
			get
			{
				return new RectInt(0, 0, 0, 0);
			}
		}

#if !UNITY_2019_3_OR_NEWER
#if ARBOR_DOC_JA
		/// <summary>
		/// RectInt同士が重なっているかをテストする。
		/// </summary>
		/// <param name="rectInt">重なっているかテストするRectInt</param>
		/// <param name="other">重なっているかテストするRectInt</param>
		/// <returns>重なっている場合にtrueを返す。</returns>
#else
		/// <summary>
		/// Test if the RectInts overlap each other.
		/// </summary>
		/// <param name="rectInt">RectInt to test for overlap</param>
		/// <param name="other">RectInt to test for overlap</param>
		/// <returns>Returns true if there is an overlap.</returns>
#endif
		public static bool Overlaps(this RectInt rectInt, RectInt other)
		{
			return other.xMin < rectInt.xMax
				&& other.xMax > rectInt.xMin
				&& other.yMin < rectInt.yMax
				&& other.yMax > rectInt.yMin;
		}
#endif

#if !UNITY_2020_1_OR_NEWER
#if ARBOR_DOC_JA
		/// <summary>
		/// RectIntを文字列に変換する。
		/// </summary>
		/// <param name="rectInt">変換するRectInt</param>
		/// <param name="format">フォーマット</param>
		/// <returns>変換した文字列。</returns>
#else
		/// <summary>
		/// Convert RectInt to a string.
		/// </summary>
		/// <param name="rectInt">RectInt to convert</param>
		/// <param name="format">Format</param>
		/// <returns>Converted string.</returns>
#endif
		public static string ToString(this RectInt rectInt, string format)
		{
			return string.Format("(x:{0}, y:{1}, width:{2}, height:{3})", rectInt.x.ToString(format), rectInt.y.ToString(format), rectInt.width.ToString(format), rectInt.height.ToString(format));
		}
#endif
	}
}