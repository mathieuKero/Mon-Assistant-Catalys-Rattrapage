using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_Radzen_Treeview.Data
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<Category> Categories { get; set; }

        public Category(int categoryID, string categoryName, List<Category> categories)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
            Categories = categories;
        }

        public Category(int categoryID, string categoryName)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
        }
    }
}
