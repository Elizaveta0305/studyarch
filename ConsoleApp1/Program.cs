using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace DeliveryApp
{
    public enum MyFoodType
    {
        Italian = 0,
        Asian = 1,
        American = 2,
        Caucasian = 3,
        Georgian = 4,
        Panasian = 5
    }

    // абстрактный класс catering только для хранения информации и работы с коллекцией
    public abstract class Catering
    {
        public int CateringID { get; set; }
        public string Name { get; set; }
        private List<Good> Goods { get; } = new List<Good>(); // коллекция товаров


        // это для добавления заказа
        public void AddGood(Good good)
        {
            Goods.Add(good);
            Console.WriteLine($"Товар \"{good.Name}\" добавлен в \"{Name}\".");
        }

        // это для удаления заказа
        public void RemoveGood(Good good)
        {
            if (Goods.Remove(good))
            {
                Console.WriteLine($"Товар \"{good.Name}\" удалён из \"{Name}\".");
            }
            else
            {
                Console.WriteLine($"Товар \"{good.Name}\" не найден в \"{Name}\".");
            }
        }

        // отображения всех товаров
        public void DisplayGoods()
        {
            Console.WriteLine($"Товары в \"{Name}\":");
            foreach (var good in Goods)
            {
                Console.WriteLine($"- {good.Name} ({good.TypeOfGood})");
            }
        }
    }

    // класс good модель данных для хранения информации о товаре
    public class Good
    {
        public string Name { get; set; }
        public MyFoodType TypeOfGood { get; set; }
    }
    partial class Items
    {

    }
    // класс restaurant 
    public class Restaurant : Catering
    {
        
    }

    // класс shop
    public class Shop : Catering
    {
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            // создаем ресторан и магазин
            Restaurant rest = new Restaurant { CateringID = 0, Name = "Итальянский ресторан" };
            Shop shop = new Shop { CateringID = 2, Name = "Магазин продуктов" };

            // создаем товары
            Good pizza = new Good { Name = "Пицца", TypeOfGood = MyFoodType.Italian };
            Good sushi = new Good { Name = "Суши", TypeOfGood = MyFoodType.Asian };
            Good seaweed = new Good { Name = "Водоросли", TypeOfGood = MyFoodType.Panasian };

            // добавляем товары
            rest.AddGood(pizza);
            shop.AddGood(sushi);
            shop.AddGood(seaweed);

            // отображаем товары
            rest.DisplayGoods();
            shop.DisplayGoods();

            // удаляем товар
            shop.RemoveGood(sushi);
            shop.DisplayGoods();

            // пауза, чтобы увидеть результат
            Console.WriteLine("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}
