==================================================
    ЛАБОРАТОРНА РОБОТА №14 | ВАРІАНТ №4
    Студент: Гродійчук Максим
    Тема: Обробка веб-запитів (HashSet, Queue, Stack)
==================================================

--- 1. ДЕМОНСТРАЦІЯ HASHSET<T> (Унікальні URL) ---
Спроба додавання URLs до HashSet:
  Додаємо 'https://example.com/home': Успішно
  Додаємо 'https://example.com/about': Успішно
  Додаємо 'https://example.com/home': Проігноровано (Дублікат)
  Додаємо 'https://example.com/products': Успішно
  Додаємо 'https://example.com/about': Проігноровано (Дублікат)

Всього унікальних сайтів у базі: 3
Перевірка наявності URL 'https://example.com/home': True

--- 2. ДЕМОНСТРАЦІЯ QUEUE<T> (Черга запитів - FIFO) ---
Запитів у черзі: 3
Наступний запит на обробку (Peek): [19:30:15] GET -> https://example.com/home

Обробка запитів у порядку надходження (FIFO):
  [ОБРОБЛЕНО] [19:30:15] GET -> https://example.com/home
  [ОБРОБЛЕНО] [19:30:15] POST -> https://example.com/api/login
  [ОБРОБЛЕНО] [19:30:15] GET -> https://example.com/products

--- 3. ДЕМОНСТРАЦІЯ STACK<T> (Історія навігації - LIFO) ---
Користувач переходить по сторінках:
  1. Відкрито: https://example.com/home
  2. Відкрито: https://example.com/products
  3. Відкрито: https://example.com/products/item123

Поточна сторінка (Peek): https://example.com/products/item123

Користувач натискає кнопку 'Назад' (Back):
  Залишили сторінку: https://example.com/products/item123
  Поточна сторінка після повернення: https://example.com/products
  Залишили сторінку: https://example.com/products
  Поточна сторінка після повернення: https://example.com/home

==================================================
    РОБОТУ ПРОГРАМИ ЗАВЕРШЕНО УСПІШНО
==================================================
