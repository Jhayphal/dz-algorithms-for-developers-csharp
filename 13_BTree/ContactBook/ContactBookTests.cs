using NUnit.Framework;
using System;
using System.Linq;

namespace ContactBook
{
	public class ContactBookTests
	{
		private static readonly Contact[] contacts = {
		new Contact("Adam Black", "79121231419"),
		new Contact("Amanda Waller", "79126131419"),
		new Contact("Jake Paul", "79121271719"),
		new Contact("Ilia 1", "79121231412"),
		new Contact("Ilya 2", "79121231477"),
		new Contact("Ilija 3", "79121232346"),
		new Contact("Jeff Dean", "79121267188"),
		new Contact("Jeff King", "79121293782"),
		new Contact("Jofrie King", "79123233126"),
		new Contact("Liam", "79161231256"),
		new Contact("Nilson", "79612131512"),
		new Contact("Abaca", "79167134212"),
		new Contact("Abada", "79179675480"),
		new Contact("Abba", "79119123871"),
		new Contact("Mother", "79128382190"),
		new Contact("Monk", "79167810293"),
		new Contact("Motel", "79101299291")
	};

		[Test]
		public void TestExists()
		{
			ContactBook book = new ContactBook();
			foreach (var item in contacts)
			{
				book.Add(item);
			}

			var negative = new string[] { "Vladimir", "Monks", "Mo", "Nilfather", "abba", "Jeff" };

			foreach (var name in negative)
			{
				Assert.IsFalse(book.Contains(name), "Name <" + name + "> found! in " + string.Join(Environment.NewLine, contacts.Select(p => p.ToString())));
			}
			var positive = new string[] { "Mother", "Jeff Dean", "Jofrie King", "Liam", "Adam Black" };
			foreach (var name in positive)
			{
				Assert.IsTrue(book.Contains(name), "Name <" + name + "> NOT found in " + string.Join(Environment.NewLine, contacts.Select(p => p.ToString())));
			}

		}

		[Test]
		public void TestCount()
		{
			ContactBook book = new ContactBook();
			foreach (var item in contacts)
			{
				book.Add(item);
			}

			Assert.AreEqual(0, book.CountStartsWith("Jefy"));
			Assert.AreEqual(2, book.CountStartsWith("Jeff"));
			Assert.AreEqual(3, book.CountStartsWith("I"));
			Assert.AreEqual(3, book.CountStartsWith("Il"));
			Assert.AreEqual(2, book.CountStartsWith("Ili"));
			Assert.AreEqual(1, book.CountStartsWith("Ilia"));
			Assert.AreEqual(contacts.Length, book.CountStartsWith(""));
			Assert.AreEqual(3, book.CountStartsWith("M"));
			Assert.AreEqual(3, book.CountStartsWith("Mo"));
			Assert.AreEqual(2, book.CountStartsWith("Mot"));
			Assert.AreEqual(1, book.CountStartsWith("Moth"));
		}

		[Test]
		public void TestStartsWith()
		{
			ContactBook book = new ContactBook();
			foreach (var item in contacts)
			{
				book.Add(item);
			}
			Assert.AreEqual("Mother", book.StartsWith("Moth").FirstOrDefault()?.Name);
			Assert.AreEqual("Jeff Dean", book.StartsWith("Jeff D").FirstOrDefault()?.Name);
		}
	}
}