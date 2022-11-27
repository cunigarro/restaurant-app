using AppLogicDBCUD.Models;
using System.Data;
using System.Text;

namespace AppLogicDBCUD.Services
{
    public class MenuFormService
    {
        public MenuFormService()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        static public Int32 calculateCost(List<Int32> valuesSelected)
        {
            Int32 total = 0;

            foreach (Int32 itemChecked in valuesSelected)
            {
                total += itemChecked;
            }

            return total;
        }

        static public void registerOrder(ClientOrder objClientOrder)
        {
            objClientOrder.insert();
        }

        static public List<Int32> getDishesWithMenuId(int currentMenu)
        {
            Menu_Dish objMenuDish = new Menu_Dish();

            DataTable dishesIdTable = objMenuDish.getARegister(currentMenu);
            List<Int32> dishesIdList = new List<Int32>();

            foreach (DataRow row in dishesIdTable.Rows)
            {
                Int32 dishId = Int32.Parse(row["ID_Dish"].ToString());
                dishesIdList.Add(dishId);
            }

            return dishesIdList;
        }

        static public DataTable getAllDishes()
        {
            Dish objDish = new Dish();

            DataTable firstTableDishes = objDish.getAllRegisters();

            return firstTableDishes;
        }

        static public DataTable getAllMenus()
        {
            Menu objMenu = new Menu();

            DataTable firstTableMenus = objMenu.getAllRegisters();

            return firstTableMenus;
        }

        static public DataTable getDishesWithPrice(int currentMenu)
        {
            List<Int32> dishesIdList = getDishesWithMenuId(currentMenu);
            DataTable allDishes = getAllDishes();

            DataTable newDataTable = new DataTable();

            newDataTable.Columns.Add("ID_Dish", typeof(string));
            newDataTable.Columns.Add("Name", typeof(string));
            newDataTable.Columns.Add("Name_Price", typeof(string));
            newDataTable.Columns.Add("Description", typeof(string));
            newDataTable.Columns.Add("Price", typeof(string));

            foreach (DataRow row in allDishes.Rows)
            {
                if (dishesIdList.Contains(Int32.Parse(row["ID_Dish"].ToString())))
                {
                    newDataTable.Rows.Add(new object[] { row["ID_Dish"], row["Name"], row["Name"] + " - " + row["Price"], row["Description"], row["Price"] });
                }
            }

            return newDataTable;
        }
    }
}
