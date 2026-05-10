namespace LinqPlayground;

/// <summary>
/// Песочница для отработки LINQ. Один запрос (№1) написан как образец —
/// сразу в method-syntax и query-syntax. Остальные 9 — задания: убери
/// TODO, напиши запрос и присвой его переменной, имя которой подставлено
/// в Console.WriteLine ниже. Чем больше из них напишешь обоими способами —
/// тем лучше прочувствуешь, что это одно и то же дерево вызовов.
/// </summary>
internal static class Program
{
    private static void Main()
    {
        List<Book> books = Library.Books();
        List<Genre> genres = Library.Genres();

        // ============================================================
        // 1. Where — отфильтровать книги дороже 700 ₽.
        //    Образец: ниже одна и та же выборка двумя синтаксисами.
        // ============================================================
        Console.WriteLine("--- 1. Where: книги дороже 700 ₽ ---");

        IEnumerable<Book> expensiveMethod = books.Where(b => b.Price > 700);

        IEnumerable<Book> expensiveQuery =
            from b in books
            where b.Price > 700
            select b;

        foreach (Book book in expensiveMethod)
        {
            Console.WriteLine(book);
        }

        Console.WriteLine();

        // ============================================================
        // 2. Where + Select — вывести только НАЗВАНИЯ книг Толкина.
        //    Подсказка: books.Where(...).Select(b => b.Title) вернёт IEnumerable<string>.
        // ============================================================
        Console.WriteLine("--- 2. Названия книг Толкина ---");

        // TODO: IEnumerable<string> tolkienTitles = ...
        // foreach (string title in tolkienTitles) Console.WriteLine(title);

        Console.WriteLine();

        // ============================================================
        // 3. OrderBy + ThenBy — отсортировать по году по убыванию,
        //    при равенстве — по названию по возрастанию.
        //    Подсказка: OrderByDescending(b => b.Year).ThenBy(b => b.Title)
        // ============================================================
        Console.WriteLine("--- 3. Сортировка по году (desc), затем по названию ---");

        // TODO: IEnumerable<Book> sorted = ...
        // foreach (Book book in sorted) Console.WriteLine(book);

        Console.WriteLine();

        // ============================================================
        // 4. GroupBy — сгруппировать по автору, вывести "автор: количество".
        //    Подсказка: books.GroupBy(b => b.Author) даёт IGrouping<string, Book>.
        //    У группы есть Key (ключ) и она сама по себе IEnumerable<Book>,
        //    так что .Count() работает прямо на ней.
        // ============================================================
        Console.WriteLine("--- 4. Количество книг по авторам ---");

        // TODO: IEnumerable<IGrouping<string, Book>> byAuthor = ...
        // foreach (var group in byAuthor) Console.WriteLine($"{group.Key}: {group.Count()}");

        Console.WriteLine();

        // ============================================================
        // 5. Агрегаты — общая стоимость каталога, средняя цена, минимальный год.
        //    Подсказка: Sum, Average, Min — каждый принимает селектор-лямбду.
        // ============================================================
        Console.WriteLine("--- 5. Агрегаты по каталогу ---");

        // TODO: decimal total = ...
        // TODO: decimal average = ...
        // TODO: int oldestYear = ...
        // Console.WriteLine($"Сумма: {total:0.00} ₽");
        // Console.WriteLine($"Средняя цена: {average:0.00} ₽");
        // Console.WriteLine($"Самая старая книга: {oldestYear} год");

        Console.WriteLine();

        // ============================================================
        // 6. Any / All — есть ли книги дороже 1000 ₽?
        //                все ли книги изданы после 1900 года?
        //    Возвращают bool.
        // ============================================================
        Console.WriteLine("--- 6. Any / All ---");

        // TODO: bool hasPremium = ...
        // TODO: bool allModern  = ...
        // Console.WriteLine($"Есть книги дороже 1000 ₽: {hasPremium}");
        // Console.WriteLine($"Все книги после 1900 года: {allModern}");

        Console.WriteLine();

        // ============================================================
        // 7. First / FirstOrDefault — первая книга Азимова;
        //    попытка найти книгу несуществующего автора (должен прийти null).
        //    First бросает InvalidOperationException, если ничего не найдено,
        //    FirstOrDefault — возвращает default (для ссылочных типов = null).
        // ============================================================
        Console.WriteLine("--- 7. First / FirstOrDefault ---");

        // TODO: Book firstAsimov = ...
        // TODO: Book? missing    = ...
        // Console.WriteLine($"Первая книга Азимова: {firstAsimov}");
        // Console.WriteLine($"Кинг найден? {(missing is null ? "нет" : missing.ToString())}");

        Console.WriteLine();

        // ============================================================
        // 8. Distinct — список уникальных авторов, отсортированный по алфавиту.
        //    Подсказка: Select(b => b.Author).Distinct().OrderBy(a => a)
        // ============================================================
        Console.WriteLine("--- 8. Уникальные авторы ---");

        // TODO: IEnumerable<string> authors = ...
        // foreach (string author in authors) Console.WriteLine(author);

        Console.WriteLine();

        // ============================================================
        // 9. Skip + Take — пагинация: страница 2 размером 3 (книги 4–6),
        //    предварительно отсортировав по названию.
        //    Подсказка: OrderBy(b => b.Title).Skip((page - 1) * size).Take(size)
        // ============================================================
        Console.WriteLine("--- 9. Пагинация: страница 2 по 3 книги ---");

        // TODO: int page = 2; int size = 3;
        // TODO: IEnumerable<Book> pageBooks = ...
        // foreach (Book book in pageBooks) Console.WriteLine(book);

        Console.WriteLine();

        // ============================================================
        // 10. Join — соединить книги с жанрами по Book.GenreId == Genre.Id,
        //     вывести "Название — Жанр".
        //     Подсказка: books.Join(genres, b => b.GenreId, g => g.Id, (b, g) => ...)
        //     В query-syntax это тот же запрос через "join g in genres on ... equals ...".
        // ============================================================
        Console.WriteLine("--- 10. Книги с названиями жанров ---");

        // TODO: IEnumerable<string> withGenres = ...
        // foreach (string line in withGenres) Console.WriteLine(line);

        Console.WriteLine();
    }
}
