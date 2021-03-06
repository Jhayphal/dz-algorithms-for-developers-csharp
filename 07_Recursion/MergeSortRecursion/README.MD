# ДЗ 
Требуется реализовать методы в `MergeSortRecursion.cs`, и проверить их тестами 
`MergeSortRecursionTest.cs`

*Запуск тестов:* 
**Visual Studio**
Откройте обозреватель тестов, выбрав Тест > Обозреватель тестов в верхней строке меню (или нажмите клавиши CTRL + E, T).
Запустите модульные тесты, нажав Запустить все (или нажмите клавиши CTRL + R, V).

## 1. Теперь их 2
★★★☆☆

Продакт менеджер узнал, что ты научился сортировать массив методом  MergeSort. Теперь у него
появилось столько идей! Например, можно взять ещё один отсортированный массив и получить один
большой отсортированный массив из двух начальных. Только вот данные уже хранятся в связных списках 
`LinkedList`, но ты уже и с этим знаком, так что это должно быть для тебя легко. Чтобы убедиться, 
что ты понял проблему, продакт накидал тебе схему слияния:

![Схема](https://i.imgur.com/F6COCgz.jpg)


Напиши метод, который принимает на вход две начальные ноды отсортированных связных списков и 
возвращает начальную ноду нового отсортированного списка.  В пакете MergeSortRecursion уже даже
есть класс с реализацией односвязного списка ListNode. Только обязательно используй механизм
рекурсии!


```C#
ListNode MergeTwoLists(ListNode l1, ListNode l2)
```

## 2. А 3 слабо?
★★★☆☆

Сортировать 2 списка оказалось не так уж и сложно. А если их будет 3? Думаю, ты уже догадался,
как это можно реализовать:)

Напиши метод, который принимает на вход три начальные ноды отсортированных связных списков и
возвращает начальную ноду нового отсортированного списка.

```C#
ListNode MergeThreeLists(ListNode l1, ListNode l2, ListNode l3)
```

*Подсказка!*
*Часть работы ты уже сделал в первом упражнении.*
