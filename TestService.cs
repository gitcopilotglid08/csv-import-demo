using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CsvImportDemo.Test
{
    public class TestService
    {
        private readonly List<string> _items;

        public TestService()
        {
            _items = new List<string>();
        }

        public async Task<bool> AddItemAsync(string item)
        {
            if (string.IsNullOrEmpty(item)) return false;

            _items.Add(item);
            await Task.Delay(100);
            return true;
        }

        public List<string> GetAllItems()
        {
            return _items;
        }

        public int GetCount() => _items.Count;

        public void ClearItems()
        {
            _items.Clear();
        }
    }
}
