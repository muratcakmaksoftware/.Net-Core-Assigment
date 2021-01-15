using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {

        static string PascalCaseFinder(string message)
        {
            List<char> charList = new List<char>();
            List<char> numberList = new List<char>();

            string[] messages = message.Trim().Split(' '); //boşlukları dizeye çevirir.
            foreach (string msg in messages) //harf kelime kontrol edilecek.
            {
                if (char.IsUpper(Convert.ToChar(msg[0]))) //kelimenin ilk harfi büyük mü ?
                {
                    foreach(char chr in msg) //büyük ise tüm kelimenin harflerini kontrol ediyoruz
                    {
                        if (char.IsNumber(chr)) //karakter sayı mı ?
                        {
                            numberList.Add(chr);
                        }
                        else //karakter sayı değil.
                        {
                            if (char.IsUpper(chr)) //karakter büyük harf mi ?
                            {
                                charList.Add(chr);
                            }
                        }

                        
                    }

                }
            }

            string messagePascalCase = "";
            charList.Sort(); //a-Z sıralama
            numberList.Sort(); //küçükten büyüğe sayıları sıralama.


            foreach(char chr in charList)
            {
                messagePascalCase += chr;
            }

            foreach (char chr in numberList)
            {
                messagePascalCase += chr;
            }


            return messagePascalCase;
        }

        static void Main(string[] args)
        {
            string message = "This iS a PascalCase3 eXample";
            Console.WriteLine(PascalCaseFinder(message));

            Console.ReadKey();
        }
    }
}
