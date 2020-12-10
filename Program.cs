using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            //Ввод числа
            long number = Convert.ToInt64(Console.ReadLine());
            //Массив разрядов
            long[] array_int = new long[4];
            //Массив с разрядами
            string[,] array_string = new string[4, 3] {{" миллиард", " миллиарда", " миллиардов"},
                {" миллион", " миллиона", " миллионов"},
                {" тысяча", " тысячи", " тысяч"},
                {"", "", ""}};
            //Миллиарды
            array_int[0] = (number - (number % 1000000000)) / 1000000000;
            //Миллионы
            array_int[1] = ((number % 1000000000) - (number % 1000000)) / 1000000;
            //Тысячные
            array_int[2] = ((number % 1000000) - (number % 1000)) / 1000;
            //Сотни, десятки и единицы
            array_int[3] = number % 1000;
            string result = "";     //результат
            for (int i = 0; i < 4; i++)     //цикл для каждого разряда
            {
                if (array_int[i] != 0)
                {
                    //Сотни
                    if (((array_int[i] - (array_int[i] % 100)) / 100) != 0)
                        switch (((array_int[i] - (array_int[i] % 100)) / 100))
                        {
                            case 0: result += ""; break;
                            case 1: result += " сто"; break;
                            case 2: result += " двести"; break;
                            case 3: result += " триста"; break;
                            case 4: result += " четыреста"; break;
                            case 5: result += " пятьсот"; break;
                            case 6: result += " шестьсот"; break;
                            case 7: result += " семьсот"; break;
                            case 8: result += " восемьсот"; break;
                            case 9: result += " девятьсот"; break;
                        }
                    //Числа от 11 до 19
                    if ((((array_int[i] % 100) - ((array_int[i] % 100) % 10)) / 10) == 1)
                    {
                        switch (array_int[i] % 100)
                        {
                            case 10: result += " десять"; break;
                            case 11: result += " одиннадцать"; break;
                            case 12: result += " двенадцать"; break;
                            case 13: result += " тринадцать"; break;
                            case 14: result += " четырнадцать"; break;
                            case 15: result += " пятнадцать"; break;
                            case 16: result += " шестнадцать"; break;
                            case 17: result += " семнадцать"; break;
                            case 18: result += " восемннадцать"; break;
                            case 19: result += " девятнадцать"; break;
                        }
                    }
                    //Десятки кроме чисел от 11 до 19
                    if ((((array_int[i] % 100) - ((array_int[i] % 100) % 10)) / 10) != 1)
                    {
                        switch (((array_int[i] % 100) - ((array_int[i] % 100) % 10)) / 10)
                        {
                            case 0: result += ""; break;
                            case 2: result += " двадцать"; break;
                            case 3: result += " тридцать"; break;
                            case 4: result += " сорок"; break;
                            case 5: result += " пятьдесят"; break;
                            case 6: result += " шестьдесят"; break;
                            case 7: result += " семьдесят"; break;
                            case 8: result += " восемьдесят"; break;
                            case 9: result += " девяносто"; break;
                        }
                        //Единицы
                        if (((array_int[i] % 100) % 10) >= 0 && ((array_int[i] % 100) % 10) <= 9)
                        {
                            switch ((array_int[i] % 100) % 10)
                            {
                                case 0: result += ""; break;
                                case 1: if (i == 2) result += " одна"; else result += " один"; break;
                                case 2: if (i == 2) result += " две"; else result += " два"; break;
                                case 3: result += " три"; break;
                                case 4: result += " четыре"; break;
                                case 5: result += " пять"; break;
                                case 6: result += " шесть"; break;
                                case 7: result += " семь"; break;
                                case 8: result += " восемь"; break;
                                case 9: result += " девять"; break;
                            }
                        }
                    }
                    //Добавление разрядов для чисел от 11 до 19 включительно
                    if ((array_int[i] % 100) >= 11 && (array_int[i] % 100) <= 19)
                        result += array_string[i, 2];
                    else  //разряд если единица равна 1
                        if (((array_int[i] % 100) % 10) == 1) { result += array_string[i, 0]; }
                    else  //разряд если единица в диапозоне от 2 до 4 включительно
                        if (((array_int[i] % 100) % 10) >= 2 && ((array_int[i] % 100) % 10) <= 4)
                    {
                        result += array_string[i, 1];
                    }
                    //Разряд в остальных случаях
                    else { result += array_string[i, 2]; }
                }
            }
            //Вывод на консоль числа прописью
            Console.WriteLine("Ваше число:" + result);
        }
    }
}