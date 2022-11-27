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

        static public DataSet getDishesWithPrice(int currentMenu)
        {
            Connection objConnection = new Connection();
            Dish objDish = new Dish();

            string queryString;

            objDish.requestAllDishes();
            queryString = objDish.readCommandString();
            objConnection.setSentence(queryString);

            DataSet myDataSetDishes = new DataSet();
            myDataSetDishes = objConnection.Request();

            return myDataSetDishes;
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
    }
}
