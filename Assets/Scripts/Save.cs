using UnityEngine;
using System.Collections;
using System.IO; // Используем библиотеку ввода вывода

public class Save : MonoBehaviour {
   
   public string filename;
   public bool Db;

   public void DebugToggle()
   {
      Db = true;
   } // Путь сохранения
   
   
   void Start () // Данный скрипт выполняется при инициализации объекта.
   {
      if ( filename == "" ) filename = "Data/Save/AppliedSettings.mps"; 
      // Если название файла не указанно то пишем по умолчанию
   }
   
   public void Apply () // Создаем ГУИ элементы, текстовое поле и 2 кнопки
   {
         StreamWriter sw = new StreamWriter(filename); // Создаем файл
         sw.WriteLine(Db); // Пишем координаты
			Debug.Log("Save" + Db);
         sw.Close(); // Закрываем(сохраняем)
   }
}