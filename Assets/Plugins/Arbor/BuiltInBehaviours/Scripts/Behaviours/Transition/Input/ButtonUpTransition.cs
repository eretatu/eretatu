﻿//-----------------------------------------------------
//            Arbor 3: FSM & BT Graph Editor
//		  Copyright(c) 2014-2021 caitsithware
//-----------------------------------------------------
using UnityEngine;

namespace Arbor.StateMachine.StateBehaviours
{
#if ARBOR_DOC_JA
	/// <summary>
	/// ボタンが離されたときにステートを遷移する。
	/// </summary>
#else
	/// <summary>
	/// It will transition the state when the button is released.
	/// </summary>
#endif
	[AddComponentMenu("")]
	[AddBehaviourMenu("Transition/Input/ButtonUpTransition")]
	[BuiltInBehaviour]
	public sealed class ButtonUpTransition : ButtonBehaviourBase
	{
		#region Serialize fields

#if ARBOR_DOC_JA
		/// <summary>
		/// 遷移先ステート。<br />
		/// 遷移メソッド : Update
		/// </summary>
#else
		/// <summary>
		/// Transition destination state.<br />
		/// Transition Method : Update
		/// </summary>
#endif
		[SerializeField] private StateLink _NextState = new StateLink();

		#endregion // Serialize fields

		// Update is called once per frame
		protected override void OnUpdate()
		{
			if (Input.GetButtonUp(buttonName))
			{
				Transition(_NextState);
			}
		}
	}
}
