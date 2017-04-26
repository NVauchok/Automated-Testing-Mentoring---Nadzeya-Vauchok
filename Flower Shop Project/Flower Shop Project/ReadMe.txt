PRE-SELECTION FOR TEST AUTOMATION MENTORING PARTICIPATION: .NET, part 2

Task 1
Спроектировать объектную модель для заданной предметной области. Использовать: классы, наследование, интерфейсы, полиморфизм, инкапсуляция. Каждый класс, метод и переменная должны иметь исчерпывающее смысл название и информативный состав. Необходимо точно продумать, какие классы необходимы для решения задачи. Наследование должно применяться только тогда, когда это имеет смысл. Классы должны быть грамотно разложены по пакетам. Работа с консолью или консольное меню должно быть минимальным (только необходимые данные для ввода, выводить только то, что просится в условии задачи). Задание представляет собой какую-то предметную область, в которой требуется выделить необходимую иерархию классов и реализовать ее с помощью ООП (используя наследование, если необходимо или реализовывая интерфейсы). В каждом классе должны быть поля и методы, которые вы посчитаете необходимыми. Программа должна создавать объекты различных классов в выделенной предметной области, объединять их в какой-то набор объектов (использовать коллекции). Как правило, задание требует выполнить поиск объектов по заданным критериям.

Варианты заданий (необходимо выбрать/реализовать один любой вариант):
1.	Цветочница. Определить иерархию цветов. Создать несколько объектов-цветов. Собрать букет с определением его стоимости. 


PRE-SELECTION FOR TEST AUTOMATION MENTORING PARTICIPATION: .NET, part 3
Task 1
Для объектной модели, реализованной в задании 2.1, необходимо реализовать классы пользовательских исключений и организовать обработку возможных исключительных ситуаций, например, если элемент отсутствует в коллекции, если мы не можем удалить текущий элемент и т.д. Комментарии оставлять в классах исключений. Создать минимум 3 пользовательских исключения и использовать минимум 5 встроенных исключений.


PRE-SELECTION FOR TEST AUTOMATION MENTORING PARTICIPATION: .NET, part 4
Task 1
Use the scenarios created in scope of the task 2.1, 3.1, 3.2. Add data reading from the following sources (choose one of the alternatives below):
1.	XML File using de\serialization
2.	JSON File using de\serialization. 
JSON.NET library can be downloaded here https://json.codeplex.com/releases/view/135702 .There will be Newtonsoft.Json.dll in the archive under the path Bin\Net45. You should include it into your solution.
Task 2
Use the scenarios created in scope of the task 2.1, 3.1, 3.2. Add data reading from a database.

Implementation:
-	Process different kinds of requests as SELECT, DELETE, UPDATE, INSERT using ADO.NET (do not use the requests described into the presentation and examples)
-	Call at least one stored procedure (except CustOrderHist which is used in presentation) using ADO.NET
