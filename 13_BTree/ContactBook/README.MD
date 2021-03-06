# ДЗ 
Требуется реализовать методы в `ContactBook.cs`, и проверить их тестами `ContactBookTests.cs`

*Запуск тестов:* 
**Visual Studio**
Откройте обозреватель тестов, выбрав Тест > Обозреватель тестов в верхней строке меню (или нажмите клавиши CTRL + E, T).
Запустите модульные тесты, нажав Запустить все (или нажмите клавиши CTRL + R, V).

### 1. Адресная книга
★★☆☆☆

Вам нужно помочь реализовать класс для хранения адресной книги и поиска по ней.

Для этого потребуется реализовать несколько функций. 

```C#
// Добавляет новый контакт в адресную книгу
void Add(Contact s);
```

```C#
// Возвращает true, если контакт с именем name есть в книге
boolean Contains(string name);
```

```C#
// Возвращает количество контактов, добавленных в адресную книгу, имена которых начинаются с pref
int CountStartsWith(string pref);
```

```C#
// Возвращает все контакты, имена которых начинаются с префикса pref
Contact[] StartsWith(string pref);
```