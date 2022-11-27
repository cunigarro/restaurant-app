using AppLogicDBCUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppLogicDBCUD.Controllers
{
    public class MenuFormService
    {
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
            Connection objConnection;
            objConnection = new Connection();

            objClientOrder.addClientOrder();
            string queryString = objClientOrder.readCommandString();
            objConnection.setSentence(queryString);
            objConnection.runSentence();
        }

        static public List<Int32> getDishesWithMenuId(int currentMenu)
        {
            Connection objConnection = new Connection();
            Menu_Dish objMenuDish = new Menu_Dish();

            string queryDishesWithMenuId;

            objMenuDish.getDishWithMenuId(currentMenu);
            queryDishesWithMenuId = objMenuDish.readCommandString();
            objConnection.setSentence(queryDishesWithMenuId);

            DataSet dishesIdDataSet = new DataSet();
            dishesIdDataSet = objConnection.Request();

            DataTable dishesIdTable = dishesIdDataSet.Tables[0];
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
            Connection objConnection = new Connection();
            Dish objDish = new Dish();

            string queryStringDishes;

            queryStringDishes = objDish.requestAllDishes();
            objConnection.setSentence(queryStringDishes);

            DataSet myDataSetDishes;
            myDataSetDishes = new DataSet();
            myDataSetDishes = objConnection.Request();

            DataTable firstTableDishes = myDataSetDishes.Tables[0];

            return firstTableDishes;
        }

        static public DataTable getAllMenus()
        {
            Connection objConnection = new Connection();
            Menu objMenu = new Menu();

            string queryString;

            queryString = objMenu.requestAllMenus();
            objConnection.setSentence(queryString);

            DataSet myDataSet;
            myDataSet = new DataSet();
            myDataSet = objConnection.Request();

            DataTable firstTableMenus = myDataSet.Tables[0];

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
