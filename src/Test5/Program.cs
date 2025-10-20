/*5. Класс “Студент и оценки”
Класс Student: имя + список оценок.
    Методы:

* AddGrade() — добавить оценку
* GetAverageGrade() — средний балл
* PrintInfo() — вывести информацию
*/

var tom = new Student("Tom");
List<int?> grades = [5, 4, 3, 2, 3, 4, 3, 2, 4, 2];
tom.AddGrade(5);
tom.AddGrades(grades);
tom.PrintAverageGrades();
tom.PrintInfo();