using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using newkilibraries;

namespace newki_inventory_box.Services
{
    public interface IBoxService
    {
        List<Box> GetBoxes();

        List<Box> GetAvailableBoxes();

        Box GetBoxByBarcode(string barcode);
        Box GetBox(int id);

        void Insert(Box box);

        void Update(Box box);

        void Remove(int id);
        List<Box> Search(List<string> keywords);
        List<string> GetYarnTypeFilters();
        void UpdateFilters();
    }
    public class BoxService : IBoxService
    {
        private readonly ApplicationDbContext _context;

        public BoxService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Box> GetBoxes()
        {
            return _context.Box.OrderByDescending(p => p.BoxId).ToList();
        }

        public List<Box> GetAvailableBoxes()
        {
            return _context.Box.OrderByDescending(p => p.BoxId).Where(p => p.Sold == false).ToList();
        }

        public Box GetBoxByBarcode(string barcode)
        {
            return _context.Box.FirstOrDefault(p => p.Barcode == barcode);
        }
        public Box GetBox(int id)
        {
            return _context.Box.FirstOrDefault(p => p.BoxId == id);
        }
        public void Insert(Box box)
        {
            box.Pallet = null;
            if (_context.Box.FirstOrDefault(p => p.Barcode == box.Barcode) == null)
            {
                _context.Box.Add(box);
            }
            _context.SaveChanges();
        }
        public void Update(Box box)
        {
            var existingBox = _context.Box.Find(box.BoxId);
            _context.Entry(existingBox).CurrentValues.SetValues(box);
            _context.SaveChanges();
        }
        public void Remove(int id)
        {
            var box = _context.Box
                .Where(x => x.BoxId == id)
                .FirstOrDefault();
            _context.Box.Remove(box);
            _context.SaveChanges();
        }
        public List<Box> Search(List<string> keywords)
        {
            var keyword = "";
            foreach (var key in keywords)
            {
                keyword = $"{keyword}{key},";
            }

            var Items = new List<Box>();
            var hasYarnType = false;
            var hasSold = false;

            var yarnTypes = GetYarnTypeFilters();


            hasYarnType = yarnTypes.Any(p => keywords.Contains(p));

            hasSold = keywords.Contains("Sold") || keywords.Contains("NotSold");

            if (!hasYarnType)
            {
                keyword = $"{keyword}{string.Join(",", yarnTypes)}";
            }
            if (!hasSold)
            {
                keyword = $"{keyword}False,True,";
            }
            if (hasSold)
            {
                if (keywords.Contains("Sold"))
                    keyword = $"{keyword}True,";
                if (keywords.Contains("NotSold"))
                    keyword = $"{keyword}False,";
            }

            return _context.Box.Where(p =>
                       keyword.Contains(p.YarnType)).ToList().Where(p => keyword.Contains(p.Sold.ToString())).OrderByDescending(p => p.BoxId).ToList();
        }
        public List<string> GetYarnTypeFilters()
        {
            var yarnTypes = _context.Box.Select(p => p.YarnType).Distinct().ToList();
            yarnTypes.RemoveAll(string.IsNullOrEmpty);
            return yarnTypes;

        }

        public void UpdateFilters()
        {
            _context.BoxFilter.RemoveRange(_context.BoxFilter);
            
            var yarnTypes = GetYarnTypeFilters();
            var yarnTypesFilter = new BoxFilter();
            yarnTypesFilter.ColumnName = "YarnType";
            yarnTypesFilter.Keywords = JsonSerializer.Serialize(yarnTypes);
            _context.BoxFilter.Add(yarnTypesFilter);

            var soldFilter = new BoxFilter();
            soldFilter.ColumnName = "Sold";
            var soldTypes = new List<bool> { true, false };
            soldFilter.Keywords = JsonSerializer.Serialize(soldTypes);
            _context.BoxFilter.Add(soldFilter);

            var deliverFilter = new BoxFilter();
            deliverFilter.ColumnName = "IsDelivered";
            var deliverTypes = new List<bool> { true, false };
            deliverFilter.Keywords = JsonSerializer.Serialize(deliverTypes);
            _context.BoxFilter.Add(deliverFilter);

            _context.SaveChanges();
        }

    }
}