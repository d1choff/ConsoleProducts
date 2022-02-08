using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine("Выберите пункт меню:\n1 - Отобразить товар\n2 - Добавить товар\n3 - Редактировать товар\n4 - Удалить товар");
			int PoinMenu = int.Parse(Console.ReadLine());
            switch (PoinMenu)
            {
				case 1:
					ShowProduct();
					break;
				case 2:
					AddProduct();
					break;
				case 3:
					EditProduct();
					break;
				case 4:
					DelateProduct();
					break;
				default:
                    Console.WriteLine("Номер пункта, который вы ввели не существует!");
                    break;
            }
		}

		public static void AddProduct()
        {
			Laptop laptops = new Laptop();
			Console.WriteLine("Введите магазин продовца:");
			laptops.Vendor = Console.ReadLine();
			Console.WriteLine("Введите производителя ноутбука:");
			laptops.CompanyCreate = Console.ReadLine();
			Console.WriteLine("Введите модель ноутбука:");
			laptops.Model = Console.ReadLine();
			Console.WriteLine("Введите диагональ ноутбука:");
			laptops.Diagonal = Double.Parse(Console.ReadLine());
			Console.WriteLine("Введите процессор ноутбука:");
			laptops.CPU = Console.ReadLine();
			Console.WriteLine("Введите видеокарту ноутбука:");
			laptops.GPU = Console.ReadLine();
			Console.WriteLine("Введите стоимость ноутбука:");
			laptops.Cost = double.Parse(Console.ReadLine());
			var Products = laptops;
			var JsonString = JsonConvert.SerializeObject(Products);
			File.WriteAllText(@"Product.xml", JsonString);
            Console.WriteLine("Товар успешно добавлен!");
			Console.WriteLine();
			Console.WriteLine("Нажмите Enter для перехода в главное меню!");
			Console.ReadLine();
			Console.Clear();
			Main();

		}

		public static void ShowProduct()
        {
			Laptop lap = new Laptop();
            try
            {
				var jsonString = File.ReadAllText(@"Product.xml");
				var Products = JsonConvert.DeserializeObject<Laptop>(jsonString);
				Console.WriteLine();
				Console.WriteLine($"Продавец:{Products.Vendor}\nПроизводитель: {Products.CompanyCreate}\nМодель: {Products.Model}\nДиоганаль экрана:{Products.Diagonal}\nПроцессор: {Products.CPU}\nВидеокарта: {Products.GPU}\nЦена: {Products.Cost}");
				Console.WriteLine();
				Console.WriteLine("Нажмите Enter для перехода в главное меню!");
				Console.ReadLine();
				Console.Clear();
				Main();
			}
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
				Console.WriteLine();
				Console.WriteLine("Нажмите Enter для перехода в главное меню!");
				Console.ReadLine();
				Console.Clear();
				Main();
			}

		}

		public static void EditProduct()
        {
            try
            {
				var jsonString = File.ReadAllText(@"Product.xml");
				var Products = JsonConvert.DeserializeObject<Laptop>(jsonString);
				Console.WriteLine();
				Console.WriteLine($"Продавец:{Products.Vendor}\nПроизводитель: {Products.CompanyCreate}\nМодель: {Products.Model}\nДиоганаль экрана:{Products.Diagonal}\nПроцессор: {Products.CPU}\nВидеокарта: {Products.GPU}\nЦена: {Products.Cost}");
				Console.WriteLine();
				Console.WriteLine("Что необходимо редактировать?:\n1 - Продавец\n2 - Производитель\n3 - Модель\n4 - Диоганаль экрана\n5 - Процессор\n6 - Видеокарта\n7 - Цена");
				int PointEdit = int.Parse(Console.ReadLine());
				switch (PointEdit)
				{
					case 1:
						Console.WriteLine("Введите магазин продовца:");
						Products.Vendor = Console.ReadLine();
						break;
					case 2:
						Console.WriteLine("Введите производителя ноутбука:");
						Products.CompanyCreate = Console.ReadLine();
						break;
					case 3:
						Console.WriteLine("Введите модель ноутбука:");
						Products.Model = Console.ReadLine();
						break;
					case 4:
						Console.WriteLine("Введите диагональ ноутбука:");
						Products.Diagonal = Double.Parse(Console.ReadLine());
						break;
					case 5:
						Console.WriteLine("Введите процессор ноутбука:");
						Products.CPU = Console.ReadLine();
						break;
					case 6:
						Console.WriteLine("Введите видеокарту ноутбука:");
						Products.GPU = Console.ReadLine();
						break;
					case 7:
						Console.WriteLine("Введите стоимость ноутбука:");
						Products.Cost = int.Parse(Console.ReadLine());
						break;
					default:
						Console.WriteLine("Такого параметра не существует!");
						break;
				}
				var JsonString = JsonConvert.SerializeObject(Products);
				File.WriteAllText(@"Product.xml", JsonString);
				Console.WriteLine();
				Console.WriteLine("Изменения применены успешно!");
				Console.WriteLine();
				Console.WriteLine("Нажмите Enter для перехода в главное меню!");
				Console.ReadLine();
				Console.Clear();
				Main();
			}
            catch (Exception ex)
            {

				Console.WriteLine(ex.Message);
				Console.WriteLine();
				Console.WriteLine("Нажмите Enter для перехода в главное меню!");
				Console.ReadLine();
				Console.Clear();
				Main();
			}
		}

		public static void DelateProduct()
        {
			File.Delete(@"Product.xml");
			Console.WriteLine();
			Console.WriteLine("Товар удален!");
			Console.WriteLine();
			Console.WriteLine("Нажмите Enter для перехода в главное меню!");
			Console.ReadLine();
			Console.Clear();
			Main();
		}
	}

	class Laptop
	{
		public string Vendor { get; set; }
		public string CompanyCreate { get; set; }
		public string Model { get; set; }
		public double Diagonal { get; set; }
		public string CPU { get; set; }
		public string GPU { get; set; }
		public double Cost { get; set; }
	}
}
