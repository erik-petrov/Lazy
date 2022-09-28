using Lazy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

using (ApplicationContext db = new ApplicationContext())
{
    // создаем два объекта User
    User tom = new User("Tom", 33);
    User alice = new User("Alice",26);

    //db.Database.Migrate();

    // добавляем их в бд
    db.Users.Add(tom);// ! ошибка Microsoft.EntityFrameworkCore.DbUpdateException
    db.Users.Add(alice);
    db.SaveChanges();
    Console.WriteLine("Объекты успешно сохранены");

    // получаем объекты из бд и выводим на консоль
    var users = db.Users.ToList();
    Console.WriteLine("Список объектов:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}
// получение
using (ApplicationContext db = new ApplicationContext())
{
    // получаем объекты из бд и выводим на консоль
    var users = db.Users.ToList();
    Console.WriteLine("Данные после добавления:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}

// Редактирование
using (ApplicationContext db = new ApplicationContext())
{
    // получаем первый объект
    User? user = db.Users.FirstOrDefault();
    if (user != null)
    {
        user.Name = "Alice";
        user.Age = 1;
        //обновляем объект
        //db.Users.Update(user);
        db.SaveChanges();
    }
    // выводим данные после обновления
    Console.WriteLine("\nДанные после редактирования:");
    var users = db.Users.ToList();
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}

// Удаление
using (ApplicationContext db = new ApplicationContext())
{
    // получаем первый объект
    User? user = db.Users.FirstOrDefault();
    if (user != null)
    {
        //удаляем объект
        db.Users.Remove(user);
        db.SaveChanges();
    }
    // выводим данные после обновления
    Console.WriteLine("\nДанные после удаления:");
    var users = db.Users.ToList();
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}
