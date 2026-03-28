**Wypożyczalnia Sprzętu**

## Opis projektu

Ten projekt to konsolowa aplikacja do obsługi uczelnianej wypożyczalni sprzętu.  
System pozwala na:

1. Dodanie nowego użytkownika do systemu.
2. Dodanie nowego sprzętu danego typu.
3. Wyświetlenie listy całego sprzętu z aktualnym statusem.
4. Wyświetlenie wyłącznie sprzętu dostępnego do wypożyczenia.
5. Wypożyczenie sprzętu użytkownikowi.
6. Zwrot sprzętu wraz z przeliczeniem ewentualnej kary za opóźnienie.
7. Oznaczenie sprzętu jako niedostępnego, np. z powodu uszkodzenia lub serwisu.
8. Wyświetlenie aktywnych wypożyczeń danego użytkownika.
9. Wyświetlenie listy przeterminowanych wypożyczeń.
10. Wygenerowanie krótkiego raportu podsumowującego stan wypożyczalni.

## Struktura klas

  - `Equipment.cs` to klasa bazowa dla:
  - `Laptop.cs`,
  - `Projector.cs`,
  - `Camera.cs` – gdzie każdy ma swoje specyficzne pola
  
  - `Person.cs` - to klasa bazowa dla:
  - `Student.cs`,
  - `Employee.cs` - gdzie każdy ma swoje specyficzne pola
    
  - `Rent.cs` – przechowuje informacje o sprzęcie, osobie i terminie w jakim należy zwrócić rzecz
  - `RentManage.cs` – zarządza wypożyczeniami i zwrotami
  
  - `Report.cs` – generuje raporty z ostatnich wypożyczeń
  - `Program.cs` – służy do uruchamiania aplikacji

## Uzasadnienie decyzji projektowych
Podział klas został stworzony w oparciu o przejrzystość kodu, aby cały nie zawierał się w jednej klasie.
 
