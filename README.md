# csharp-learning

Учебный репозиторий по C# и .NET с практикой по дням: от простых консольных программ до Web API на ASP.NET Core.

Сейчас в репозитории реализованы задания `day1`-`day7`, а дни `8`-`30` оформлены как дорожная карта обучения.

## Что внутри

- базовый синтаксис C#: типы, условия, циклы, методы;
- коллекции, строки, работа с датой и временем;
- небольшие консольные приложения с постепенно растущей сложностью;
- первые тесты на `xUnit`;
- план дальнейшего перехода к `LINQ`, `async/await`, `JSON`, `ASP.NET Core`, `EF Core`, `Docker`.

## Прогресс

| День | Тема | Проект | Статус |
| --- | --- | --- | --- |
| 1 | Hello, C#, переменные, ввод/вывод | `day1/HelloWorld` | готово |
| 1 | Первые unit-тесты | `day1/HelloWorld.Tests` | готово |
| 2 | Типы данных и преобразования | `day2/UnitConverter` | готово |
| 3 | `if`, `switch`, тернарный оператор | `day3/Calculator` | готово |
| 4 | Циклы `for`, `while`, `foreach` | `day4/*` | готово |
| 5 | Методы, разбиение по классам | `day5/Calculator` | готово |
| 6 | `Array`, `List<T>`, `Dictionary<TKey, TValue>` | `day6/BookInventory` | готово |
| 7 | Строки, `StringBuilder`, дата и время | `day7/OrderParser` | готово |
| 8-20 | ООП, LINQ, JSON, async, события, generics, SOLID, тесты | - | в плане |
| 21-30 | ASP.NET Core Web API, EF Core, JWT, Docker | - | в плане |

## Структура репозитория

```text
.
|- day1/
|- day2/
|- day3/
|- day4/
|- day5/
|- day6/
|- day7/
`- README.md
```

## Требования

- `.NET SDK` 8.0 или новее;
- любая удобная IDE: `Rider`, `Visual Studio`, `VS Code`.

Проверка установки:

```bash
dotnet --info
```

## Как запускать

Общий формат:

```bash
dotnet run --project <путь-к-csproj>
```

Примеры:

```bash
dotnet run --project day1/HelloWorld/HelloWorld.csproj
dotnet run --project day2/UnitConverter/UnitConverter.csproj
dotnet run --project day3/Calculator/Calculator.csproj
dotnet run --project day4/ForeachExample/ForeachExample.csproj
dotnet run --project day4/MultiplicationTable/MultiplicationTable.csproj
dotnet run --project day4/WhileDoWhileExample/WhileDoWhileExample.csproj
dotnet run --project day5/Calculator/Calculator.csproj
dotnet run --project day6/BookInventory/BookInventory.csproj
dotnet run --project day7/OrderParser/OrderParser.csproj
```

Тесты:

```bash
dotnet test day1/HelloWorld.Tests/HelloWorld.Tests.csproj
```

## Реализованные мини-проекты

### День 1 - HelloWorld

`day1/HelloWorld` - консольная программа с приветствием пользователя, нормализацией имени и повторным запуском.

### День 2 - UnitConverter

`day2/UnitConverter` - конвертер длины между метрами, сантиметрами и миллиметрами с проверкой пользовательского ввода.

### День 3 - Calculator

`day3/Calculator` - калькулятор с меню операций для тренировки условий и ветвления.

### День 4 - Циклы

- `day4/ForeachExample` - обход массива и подсчет гласных;
- `day4/MultiplicationTable` - таблица умножения через `for`;
- `day4/WhileDoWhileExample` - сумма чисел и повтор действия через `while` и `do-while`.

### День 5 - Calculator (refactor)

`day5/Calculator` - калькулятор, разнесенный по нескольким классам: чтение чисел, меню, движок вычислений.

### День 6 - BookInventory

`day6/BookInventory` - учет книг с добавлением, удалением, поиском по `ISBN` и выводом данных через `Dictionary`, массив и `List<T>`.

### День 7 - OrderParser

`day7/OrderParser` - парсинг строки заказа вида `orderId;customer;product;quantity;price;orderDate` с валидацией и форматированным выводом результата.

## План обучения

### День 1-10: база C#

1. установка SDK и первая программа;
2. типы данных, `var`, `nullable`, преобразования;
3. условия: `if`, `switch`, тернарный оператор;
4. циклы: `for`, `while`, `foreach`;
5. методы, параметры, `ref/out`, перегрузка;
6. массивы, `List<T>`, `Dictionary<TKey, TValue>`;
7. строки, `StringBuilder`, дата и время;
8. ООП: классы, свойства, конструкторы, инкапсуляция;
9. наследование, интерфейсы, полиморфизм;
10. обработка исключений.

### День 11-20: продвинутый C# и мини-проект

11. `LINQ`;
12. `record`, `enum`, `struct`, `init`;
13. файлы и `System.Text.Json`;
14. `async/await`, `Task`, `CancellationToken`;
15. делегаты, события, лямбды;
16. generics и ограничения типов;
17. основы `SOLID`;
18. модульное тестирование с `xUnit`;
19. повторение и рефакторинг;
20. мини-проект `Task Tracker`.

### День 21-30: ASP.NET Core Web API

21. основы ASP.NET Core, middleware, DI, контроллеры;
22. роутинг, DTO, валидация;
23. слои `Controller -> Service -> Repository`;
24. `EF Core`, `DbContext`, миграции;
25. CRUD с базой данных;
26. JWT-аутентификация;
27. логирование, конфигурация, секреты;
28. интеграционные тесты API;
29. Docker для .NET;
30. финальный мини-проект `Notes API`.

## Цель репозитория

По завершении плана репозиторий должен дать практику, достаточную чтобы:

- уверенно писать консольные программы на C#;
- использовать `LINQ`, `async/await` и обработку исключений;
- собирать Web API на ASP.NET Core;
- подключать базу данных через `EF Core` и выполнять миграции;
- покрывать базовую логику тестами;
- запускать проекты локально и в Docker.
