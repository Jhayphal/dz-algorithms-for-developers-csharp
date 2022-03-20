
using System;

namespace Duplicates
{
	public class TextEditor
	{
		// Больше 255 символов в память не влезает =/
		public char[] Text = new char[255]; // Тип String ещё не изобрели :(
		public int TextLength; // текущая длина текста в массиве text

		// Пустое место в этом массиве забито просто “пробелами”
		// Например если textLength = 3, и text = {‘ш’,’к’,’я’, … еще 252 символа ‘пробел’ .. }

		public void InsertCharacterAt(int position, char c)
		{
			// Эта функция должна вставлять символ в строку на позиции position
			// Например когда пользователь напечатал “При|ет мир!” (этот текст у нас в переменной text)
			// и его курсор находится между буквами “и” и “е”, и он нажимает “в”.
			// В этот момент вызывается функция insertCharacterAt(3, “в”), после чего в переменной text значение меняется на “Привет мир!”

#warning ПРИМЕЧАНИЕ
			// я так и не понял, курсор реально находится в тексте или это "образно"
			// в примере написано, что именно этот текст (с курсором) находится в переменной, но после выполнения операции курсор исчезает
			// поэтому решил, что самого символа курсора в тексте нет

			if (position < 0 || position > Text.Length - 1)
				throw new ArgumentOutOfRangeException(nameof(position));

			if (TextLength == Text.Length)
				return;

			for (int i = TextLength; i > position; --i)
				Text[i] = Text[i - 1];

			Text[position] = c;

			++TextLength;
		}

		public void Backspace(int position)
		{
			// “Привет Мм|ир!” => “Привет Мир!”

			if (position < 0 || position > Text.Length - 1)
				throw new ArgumentOutOfRangeException(nameof(position));

			if (TextLength == 0)
				return;

			for (int i = position + 1; i < TextLength - 1; ++i)
				Text[i - 1] = Text[i];

			--TextLength;
		}


		// Конструктор готов!
		public TextEditor()
		{
			TextLength = 0;
			for (int i = 0; i < 255; i++)
			{
				Text[i] = ' ';
			}
		}
	}
}
