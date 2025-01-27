﻿//-----------------------------------------------------
//            Arbor 3: FSM & BT Graph Editor
//		  Copyright(c) 2014-2021 caitsithware
//-----------------------------------------------------
using UnityEngine;
using UnityEngine.Serialization;

namespace Arbor
{
#if ARBOR_DOC_JA
	/// <summary>
	/// Arbor Editorにあるノードの基底クラス
	/// </summary>
#else
	/// <summary>
	/// Base class of a node in Arbor Editor
	/// </summary>
#endif
	[System.Serializable]
	public class Node
	{
		[SerializeField]
		[FormerlySerializedAs("_StateMachine")]
		private NodeGraph _NodeGraph;

		[SerializeField]
		[FormerlySerializedAs("_StateID")]
		[FormerlySerializedAs("_CalculatorID")]
		[FormerlySerializedAs("_CommentID")]
		private int _NodeID;

#if ARBOR_DOC_JA
		/// <summary>
		/// Arbor Editor上での位置。
		/// </summary>
#else
		/// <summary>
		/// Position on the Arbor Editor.
		/// </summary>
#endif
		public Rect position;

#if ARBOR_DOC_JA
		/// <summary>
		/// コメントを表示するかどうか
		/// </summary>
#else
		/// <summary>
		/// Whether to display comments
		/// </summary>
#endif
		public bool showComment;

#if ARBOR_DOC_JA
		/// <summary>
		/// コメント
		/// </summary>
#else
		/// <summary>
		/// Comment
		/// </summary>
#endif
		public string nodeComment;

#if ARBOR_DOC_JA
		/// <summary>
		/// NodeGraphを取得。
		/// </summary>
#else
		/// <summary>
		/// Gets the NodeGraph.
		/// </summary>
#endif
		public NodeGraph nodeGraph
		{
			get
			{
				return _NodeGraph;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// ノードIDを取得。
		/// </summary>
#else
		/// <summary>
		/// Gets the node identifier.
		/// </summary>
#endif
		public int nodeID
		{
			get
			{
				return _NodeID;
			}
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// Nodeのコンストラクタ
		/// </summary>
		/// <param name="nodeGraph">このノードを持つNodeGraph</param>
		/// <param name="nodeID">ノードID</param>
#else
		/// <summary>
		/// Node constructor
		/// </summary>
		/// <param name="nodeGraph">NodeGraph with this node</param>
		/// <param name="nodeID">Node ID</param>
#endif
		protected Node(NodeGraph nodeGraph, int nodeID)
		{
			_NodeGraph = nodeGraph;
			_NodeID = nodeID;
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// Nodeが所属するNodeGraphが変わった際に呼ばれる。
		/// </summary>
#else
		/// <summary>
		/// Called when the NodeGraph to which the Node belongs has changed.
		/// </summary>
#endif
		protected virtual void OnGraphChanged()
		{
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// NodeBehaviourを含んでいるかをチェックする。
		/// </summary>
		/// <param name="behaviour">チェックするNodeBehaviour</param>
		/// <returns>NodeBehaviourを含んでいる場合にtrueを返す。</returns>
#else
		/// <summary>
		/// Check if it contains NodeBehaviour.
		/// </summary>
		/// <param name="behaviour">Check NodeBehaviour</param>
		/// <returns>Returns true if it contains NodeBehaviour.</returns>
#endif
		public virtual bool IsContainsBehaviour(NodeBehaviour behaviour)
		{
			return false;
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// 削除できるかどうかを返す。
		/// </summary>
		/// <returns>削除できる場合にtrueを返す。</returns>
#else
		/// <summary>
		/// Returns whether or not it can be deleted.
		/// </summary>
		/// <returns>Returns true if it can be deleted.</returns>
#endif
		public virtual bool IsDeletable()
		{
			return true;
		}

		internal void ChangeGraph(NodeGraph nodeGraph)
		{
			if (!Application.isEditor || Application.isPlaying)
			{
				throw new System.NotSupportedException();
			}

			_NodeGraph = nodeGraph;

			OnGraphChanged();
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// ノードの名前を取得
		/// </summary>
		/// <returns>ノードの名前</returns>
#else
		/// <summary>
		/// Get node name.
		/// </summary>
		/// <returns>Node name</returns>
#endif
		public virtual string GetName()
		{
			return GetType().Name;
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// ノードを文字列に変換（デバッグ用）。
		/// </summary>
		/// <returns>変換された文字列</returns>
#else
		/// <summary>
		/// Convert node to string (for debugging).
		/// </summary>
		/// <returns>Converted string</returns>
#endif
		public override string ToString()
		{
			return GetName();
		}
	}
}
