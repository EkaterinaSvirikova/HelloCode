Console.Clear();

// Вид 1 (Ничего не возвращает и ничего не принимает)

void Method1()                                      // скобочки пустые, они обязательны
{
    Console.WriteLine("Автор Свирикова Екатерина"); // тело метода
}
Method1();                                          // так вызывается метод, скобочки обязательны



// Вид 2 (Ничего не возвращает, но может принимать аргументы)

void Method2(string msg)
{
    Console.WriteLine(msg);                         // в теле метода мы используем принятые аргументы
}
Method2("Текст сообщения");                         // аргумент строка с сообщением

// Method2(msg: "Текст сообщения");  аргументы могут быть именованными
// Это нужно, когда методы принимают какое-то количество аргументов

// например:
void Method21(string msg, int count)       // указаны два аргумента
{
    int i = 0;
    while(i < count)
    {
        Console.WriteLine(msg);
        i++;
    }
}
Method21(msg: "Текст", count: 4);          //  вызов метода путем указания аргументов - сообщение и сколько раз показать его

// Method21(count: 4, msg: "Новый текст"); // их не обязательно писать по порядку, это и есть особенность:


// Вид 3 (Что-то возвращает, но ничего не принимает)

int Method3()
{
    return DateTime.Now.Year;
}
int year = Method3();                      // можем использовать идентификатор переменной и присвоить ему нужное значение
Console.WriteLine(year);                   // и использовать эту переменную для вывода значения, кот вернул метод


// Вид 4 (Метод, который что-то принимает и что-то возвращает)

string Method4(int count, string text)     // возвращать будем строку, т.е. какой-то текст мы будем выводить count раз
{
    int i = 0;                             // возьмем цикл
    string result = string.Empty;          // потребуется переменная, куда будем класть результат - пустая строка
    
    while(i < count) 
    {
        result = result + text;            // в result кладем указанный текст
        i++;
    }
    return result;                         // используем классический оператор return с указанием переменной, которую ожидаем получить из метода
}
string res = Method4(10, "z");             // чтобы вызвать метод, нужно создать переменную (res), в нее "положить" напр 10 раз вывести z
Console.WriteLine(res);                    // вывести res, который возвращает данный метод


// еще одна вариация с использованием  for

string Method4(int count, string text)
{
    string result = string.Empty; 
    for(int i = 0; i < count; i++)          // в скобки пишем инициализацию счетчика, проверку условия и инкремент
    {
        result = result + text; 
    }
    return result;
}
string res = Method4(10, "z");
Console.WriteLine(res);


// Использование цикла внутри цикла (вывод таблицы умножения)

for(int i = 2; i <= 10; i++)                        // внешний цикл с счетчиком i
 {
    for(int j = 2; j <= 10; j++)                    //внутренний цикл с счетчиком j
    {
        Console.WriteLine($"{i} * {j} = {i * j}");
    }
    Console.WriteLine();                            // чтобы был переход в виде пустой строки
}


// ===== Работа с текстом
// Дан текст. В тексте нужно все пробелы заменить черточками, маленькие буквы "к" заменить большими "К",
// а большие "С" заменить маленькими "с".

string text = "- Я думаю, - сказал князь, улыбаясь, -что,"
            + "ежели бы вас послали вместо нашего милого Винценгероде,"
            + "вы бы взяли приступом согласие прусского короля. "
            + "Вы так красноречивы. Вы дадите мне чаю?";

// string s = "qwerty"
//             012345
// s[3] // r

string Replace(string text, char oldValue, char newValue)    // возвр. будет строка, условно 4 вид метода, указ-ем старый символ и новый
{
    string result = string.Empty;                            // инициализируем пустую строку
    int length = text.Length;                                // получение длины строки, text.Length показывает кол-во символов в строке

    for(int i = 0; i < length; i++)                          // пробегаемся от 0 символа до конца строки
    {
        if(text[i] == oldValue) result = result + $"{newValue}";   // если итое совпал с oldValue, то в результат кладем newValue
        else result = result + $"{text[i]}";                       // если нет, то в резалт добавляем текущий символ

    }
    return result;                                        // возврат результата
}
string newText = Replace(text, ' ', '|');                 // кладем в text что на что меняем - пробелы на |
Console.WriteLine(newText);
Console.WriteLine();

newText = Replace(newText, 'к', 'К');                     // кладем в newText что на что меняем - к на К
Console.WriteLine(newText);
Console.WriteLine();

newText = Replace(newText, 'с', 'С');                     // кладем в newText что на что меняем - с на С
Console.WriteLine(newText);
Console.WriteLine();

// Задача упорядочить массив. Алгоритм сортировки выбором max или min

int[] arr = { 1, 5, 4 ,3, 2, 6, 7, 1, 1 };         // внутри могут находиться повторяющиеся элементы

void PrintArray(int[] array)                       // решает задачу по выводу массива на экран, аргумент массив
{
    int count = array.Length;

    for(int i = 0; i < count; i++)
    {
        Console.Write($"{array[i]} ");
    }
    Console.WriteLine();
} 

void SelectionSort(int[] array)                    // метод, который будет упорядочивать наш массив
{
    for(int i = 0; i < array.Length - 1; i++)      // нужно отнять 1 от длины массива, т.к. ниже в цикле мы прибавляем 1
    {
        int minPosition = i;                       // определяем ту позицию, на кот смотрим

        for(int j = i+1; j < array.Length ; j++)   // ищем минимальный элемент, i+1 даст общее колво элементов
        {                                          // чтобы отсорторовать от большего к меньшему, нужно просто изменить знак на >
            
            if(array[j] > array[minPosition]) minPosition = j;
        }
        int temporary = array[i];                   // меняем min с той позицией, которую нашли
        array[i] = array[minPosition];
        array[minPosition] = temporary;
    }
}
PrintArray(arr);                                    // вывод исходного массива
SelectionSort(arr);                                 // применение метода
PrintArray(arr);                                    // вывод измененного массива
