using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook
{
	public class Node
	{
		public readonly Dictionary<char, Node> Next;
		public readonly List<Contact> EndHere;
		
		public int Count => Next.Count;

		public Node()
		{
			Next = new();
			EndHere = new();
		}
	}

	public class ContactBook
	{
		private readonly Node Root;

		public ContactBook()
		{
			Root = new Node();
		}

		// Добавляет имя нового контакта в адресную книгу
		public void Add(Contact s)
		{
			if (string.IsNullOrEmpty(s?.Name))
				return;

			Add(Root, s, 0);
		}

		private void Add(Node to, Contact s, int charPosition)
		{
			if (charPosition == s.Name.Length)
            {
				to.EndHere.Add(s);

				return;
            }

			var currentChar = s.Name[charPosition];

			if (!to.Next.TryGetValue(currentChar, out var node))
			{
				node = new Node();

				to.Next.Add(currentChar, node);
			}

			Add(node, s, charPosition + 1);
		}

		// Возвращает true, если контакт с именем name есть в книге
		public bool Contains(string name)
		{
			var node = Find(Root, name, 0);

			if (node == null)
				return false;

			return node
				.EndHere
				.Any(x => string.Equals(x.Name, name));
		}

		// Возвращает количество контактов, добавленных в адресную книгу, имена которых начинаются с pref
		public int CountStartsWith(string pref)
		{
			return StartsWith(pref).Length;
			// please implement this
		}

		// Возвращает все контакты, имена которых начинаются с префикса pref
		public Contact[] StartsWith(string pref)
		{
			List<Contact> result = new();

			var node = Find(Root, pref, 0);

			GetAllChildrenContacts(node, result);

			return result.ToArray();
		}

		private void GetAllChildrenContacts(Node node, List<Contact> contacts)
        {
			if (node == null)
				return;

			contacts.AddRange(node.EndHere);

			foreach(var c in node.Next.Values)
				GetAllChildrenContacts(c, contacts);
        }

		private Node Find(Node inThat, string name, int charPosition)
		{
			if (charPosition == name.Length)
				return inThat;

			var currentChar = name[charPosition];

			if (inThat.Next.TryGetValue(currentChar, out var node))
				return Find(node, name, charPosition + 1);

			return null;
		}
	}
}
