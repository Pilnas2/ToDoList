using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.ViewModel
{
    internal class ToDoItemCollection : IEnumerable<ToDoItem>
    {
        private List<ToDoItem> items;

        public ToDoItemCollection()
        {
            items = new List<ToDoItem>();
        }

        // Metoda pro načtení dat (např. z databáze)
        public async Task LoadItemsAsync()
        {
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            items = await database.GetItemsAsync();
        }

        // Přidání položky do kolekce
        public void Add(ToDoItem item)
        {
            items.Add(item);
        }

        // Implementace rozhraní IEnumerable pro projití kolekcí
        public IEnumerator<ToDoItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
