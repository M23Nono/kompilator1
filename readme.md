###№ Компилятор

### Описание
Компилятор - это приложение для редактирования текстовых файлов с возможностью компиляции и выполнения программ на языке программирования. Приложение разработано как часть курсовой работы по теме "Разработка пользовательского интерфейса (GUI) для языкового процессора" с использованием C# и .NET Framework 4.8.

### Функциональности
Создание, открытие и сохранение текстовых файлов в различных форматах (.txt, .cs, все файлы).
Возможность редактирования текста с поддержкой форматирования.
Отображение номеров строк.
Возможность компиляции и выполнения программ на языке программирования.

### Инструкции по установке
1.Скачайте исполняемый файл
2.Запустите приложение.

##№ Использование
1.Запустите приложение.
2.Создайте новый файл или откройте существующий.
3.Редактируйте текст в редакторе.
4.Сохраните изменения при необходимости.

### Лицензия
Этот проект лицензирован под лицензией MIT.

### Автор
Варвянский Даниил  - разработка приложения.

### Обратная связь
Если у вас возникли вопросы или предложения по улучшению приложения, пожалуйста, свяжитесь со мной по адресу: varvyanskiy03@mail.ru


# Лабораторная №2
## **Лексический анализатор (сканер)**
## **Постановка задачи**
*Разработать лексический анализатор (сканер) для выделения лексем из текста программного кода на языке PHP. Лексемы могут быть ключевыми словами, идентификаторами, знаками операций, числами и т.д. Недопустимыми символами считаются все символы, не являющиеся частью лексем. Вывести ошибку при обнаружении недопустимого символа.*

## **Персональный вариант задания на лабораторную работу**
Тема: Разработка лексического анализатора (сканера).

Цель работы: Изучить назначение лексического анализатора. Спроектировать алгоритм и выполнить программную реализацию сканера.

### **Вариант задания:**
"*"Язык: PHP
"*"Входные данные: строка (текст программного кода)
"*"Выходные данные: последовательность условных кодов, описывающих структуру разбираемого текста с указанием места положения и типа ("число", "идентификатор", "знак", "недопустимый символ" и т.д.)
## **Примеры допустимых строк**
Пример строки программного кода на языке PHP:
`<?php
    $x = 123;
    echo "Hello, world!";
?>`


**Диаграмма состояний сканера**
![https://sun9-79.userapi.com/impg/F3D3KOzXl4WztQ7DPERB-j_fp0luN8UolF197w/vwEphWW_f_k.jpg?size=906x656&quality=96&sign=06813fbf8a207289089322644423b889&type=album]
## **Тестовые примеры**
1. Входная строка: `$var = 42;`
`2 - идентификатор - var - с 1 по 3 символ
10 - оператор присваивания - = - с 5 по 5 символ
1 - целое без знака - 42 - с 7 по 8 символ
16 - конец оператора - ; - с 9 по 9 символ`

2.Входная строка: `echo "Hello, world!";`
Выходные данные:`15 - ключевое слово - echo - с 1 по 4 символ
11 - разделитель - (пробел) - с 5 по 5 символ
18 - строковая литерал - "Hello, world!" - с 6 по 19 символ
16 - конец оператора - ; - с 20 по 20 символ`

## **Использование**
1. Убедитесь, что у вас установлен интерпретатор PHP.
2.Запустите сканер, передав ему входную строку в качестве аргумента.
3.Программа выведет результат работы сканера в виде последовательности условных кодов, описывающих структуру разбираемого текста.
## **Лицензия**
Этот проект лицензируется в соответствии с лицензией MIT.


# Лабораторная №3 
Грамматика 
G [<N, T, P, S>]:

VT = { '#', '//', "/*", "*/" newline, symbol}

VN = {
COMMENT, // Общий нетерминал для комментариев
LINE_COMMENT, // Однострочный комментарий (начинается с "//")
MULTI_COMMENT // Многострочный комментарий (начинается с "/" и заканчивается "/")
}

P = {K -> / SLASH | /MULTICOM | #HASHCOM
SLASH -> / SLASH 2
SLASH2 -> symbol/text
TEXT -> symbol / TEXT /;
MULTICOM -> * TEXTMUL
TEXT MUL -> symbol/ {symbol} /ENDMUL
ENDMUL -> * SLASHMUL
SLASHMUL ->/
SLASHCOM -> symbol {symbol} ENDSLASH
ENDSLASH ->;
}

Здесь:

COMMENT представляет общий нетерминал для всех видов комментариев,
LINE_COMMENT представляет однострочный комментарий, начинающийся с //,
MULTI_COMMENT представляет многострочный комментарий, начинающийся с /* и заканчивающийся */,
anyCharacter* обозначает любой символ (включая пустую строку), который может повторяться ноль или более раз.

P:
COMMENT -> LINE_COMMENT | MULTI_COMMENT
LINE_COMMENT -> // anyCharacter* newline
MULTI_COMMENT -> /* anyCharacter* */
### Граф конечного автомата комментариев на PHP
![image](https://github.com/M23Nono/kompilator1/assets/34939868/d833ad82-bcf7-4d21-9698-c230a2d798ff)

### Работа программы 
![1foto](https://github.com/M23Nono/kompilator1/assets/34939868/c58415cd-58ca-49cd-93f3-5ef5d9da56b2)
![2foto](https://github.com/M23Nono/kompilator1/assets/34939868/ad86da3d-7d37-45d5-9ff6-d5cca25468ec)
![3foto](https://github.com/M23Nono/kompilator1/assets/34939868/b22a7288-3ed0-42f6-921d-ac048c0f108b)








