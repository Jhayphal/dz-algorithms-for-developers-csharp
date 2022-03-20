using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTree
{
	internal class BTree
	{
		private const int T = 5;
		private Node Root;

		private class Node
        {
			public Node[] Child = new Node[2 * T];
			public int?[] Keys = new int?[2 * T - 1];
			public int Count;

			public Node(int count)
            {
				Count = count;
            }
		}

		public BTree()
		{
			Root = new Node(count: 0);
		}

        // Добавляет число X в дерево
		public void Add(int x)
		{
			Add(Root, x);

			if (Root.Count == 2 * T - 1)
            {
				Node node = new(0);
				node.Child[0] = Root;

				SplitChild(node, 0);

				Root = node;
            }
		}

        private void SplitChild(Node node, int index)
        {
			Node son = node.Child[index];
			Node newSon = new(T - 1);

			for (int i = 0;i < T - 1; ++i)
            {
				newSon.Keys[i] = son.Keys[i + T];
				newSon.Child[i] = son.Child[i + T];

				son.Keys[i + T] = null;
				son.Child[i + T] = null;
            }

			newSon.Child[T - 1] = son.Child[2 * T - 1];
			son.Child[2 * T - 1] = null;

			son.Count = T - 1;

			for (int i = node.Count - 1; i >= index; --i)
            {
				node.Keys[i + 1] = node.Keys[i];
				node.Child[i + 1] = node.Child[i];
            }

			node.Keys[index] = son.Keys[T - 1];

			son.Keys[T - 1] = null;

			node.Child[index + 1] = newSon;
			++node.Count;
		}

        private void Add(Node node, int key)
        {
			if (node == null)
				return;

			if (node.Child[0] == null)
            {
				InsertInLeaf(node, key);

				return;
            }

			int i;

			for (i = 0; i < node.Count; ++i)
				if (node.Keys[i].Value.CompareTo(key) > 0)
					break;

			if (node.Child[i].Count == 2 * T - 1)
				SplitChild(node, i);

			for (i = 0; i < node.Count; ++i)
				if (node.Keys[i].Value.CompareTo(key) > 0)
					break;

			Add(node.Child[i], key);
		}

        private void InsertInLeaf(Node node, int key)
        {
			int i;

			for (i = node.Count - 1; i >= 0; --i)
			{
				if (node.Keys[i].Value.CompareTo(key) < 0)
					break;

				node.Keys[i + 1] = node.Keys[i];
			}

			node.Keys[i + 1] = key;
			
			++node.Count;
        }

        // Проверяет, было ли число X добавлено в дерево
        public bool Contains(int x)
		{
			return Contains(Root, x);
		}

		private bool Contains(Node node, int key)
		{
			if (node == null)
				return false;

			for (int i = 0; i < node.Count; ++i)
			{
				var currentKey = node.Keys[i];

				if (currentKey.Equals(key))
					return true;

				if (currentKey.Value.CompareTo(key) > 0)
					return Contains(node.Child[i], key);
			}

			return Contains(node.Child[node.Count], key);
		}

		// Выводит текущую максимальную глубину дерева
		public int GetMaxHeight()
		{
			int height = 0;

			var node = Root;

			while(node != null)
            {
				++height;

				node = node.Child[0];
            }

			return height;
		}

		// Возвращает список всех чисел, добавленных в дерево в возрастающем порядке
		public int[] GetSorted()
		{
			List<int> result = new();

			SetItems(Root, result);

			return result.ToArray();
		}

		private void SetItems(Node node, List<int> outItems)
		{
			if (node == null)
				return;

			for (int i = 0; i < node.Count; ++i)
            {
				SetItems(node.Child[i], outItems);

				outItems.Add(node.Keys[i].Value);
            }

			SetItems(node.Child[node.Count], outItems);
		}
	}
}
