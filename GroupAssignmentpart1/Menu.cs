using System;
using System.Collections.Generic;
using System.Linq;

namespace GruppArbeteFUB.Menus
{
    public static class Constants
    {
        public const char MENU_ITEMS_SEPARATOR = '\t';
    }

    public class Menu
    {
        private List<string> lstTitles = new List<string> { "Please select an entry:" };
        private Dictionary<string, string> dicMenuItems = null;
        private List<string> lstColumns = null;
        private List<int> lstMaxLengthsColumns = null;

        /// <summary>
        /// Displays the title and the items of the menu, and ask the user to choose from the menu items until the chosen entry is correct
        /// </summary>
        /// <returns>Returns the value of the chosen menu item</returns>
        protected internal virtual string Show()
        {
            // Preparation of the menu
            List<string> lstMenuItems = new List<string>();

            //      Columns management
            if (lstColumns == null)
                lstColumns = new List<string> { string.Empty };

            lstMenuItems = PrepareMenuItems();
            //      Columns managed
            // Menu prepared

            // Display of the menu until the user chose a correct entry
            bool boolOK = false;

            string strInput = string.Empty;
            do
            {
                Console.Clear();
                foreach (string menuItem in lstMenuItems)
                    Console.WriteLine(menuItem);

                strInput = Console.ReadLine();

                if (dicMenuItems.ContainsKey(strInput.ToUpper()))
                    boolOK = true;
                else
                {
                    Console.WriteLine("The entry you chose is incorrect!");
                    Console.ReadKey();
                }
            }
            while (!boolOK);
            // Menu displayed until right entry selected

            return strInput;
        }

        private List<string> PrepareMenuItems()
        {
            // Adding an extra column in order to display the menu item choices
            lstColumns.Insert(0, string.Empty);
            List<List<string>> lstLstColumnMenu = new List<List<string>> { lstColumns };

            bool boolColumnName = false;

            lstMaxLengthsColumns = new List<int>();
            foreach (string column in lstColumns)
            {
                lstMaxLengthsColumns.Add(column.Length);
                if (column.Length > 0)
                    boolColumnName = true;
            }

            int intNoColumn = 0;
            foreach (string menuItem in dicMenuItems.Keys)
            {
                intNoColumn = 0;
                List<string> lstMenuItem = new List<string> { string.Empty };
                if (menuItem.First() != '-')
                    lstMenuItem[intNoColumn] = menuItem + ".";

                if (lstMaxLengthsColumns[intNoColumn] < lstMenuItem[intNoColumn].Length)
                    lstMaxLengthsColumns[intNoColumn] = lstMenuItem[intNoColumn].Length;

                List<string> lstSubItems = dicMenuItems[menuItem].Split(Constants.MENU_ITEMS_SEPARATOR).ToList();

                // Make sure that each line has the right amount of columns
                while (lstSubItems.Count < lstColumns.Count - 1)
                    lstSubItems.Add(string.Empty);

                while (lstColumns.Count < lstSubItems.Count)
                {
                    lstColumns.Add(string.Empty);
                    lstMaxLengthsColumns.Add(0);
                }
                // Each line has now the right amount of columns

                // Computation of the max column length
                foreach (string subItem in lstSubItems)
                {
                    intNoColumn += 1;
                    if (lstMaxLengthsColumns[intNoColumn] < subItem.Length)
                        lstMaxLengthsColumns[intNoColumn] = subItem.Length;

                    lstMenuItem.Add(subItem);
                }
                // Max column length computed

                lstLstColumnMenu.Add(lstMenuItem);
            }

            // The space between columns must be taken into account
            intNoColumn = 0;
            foreach (int columnWidth in lstMaxLengthsColumns.ToList())
            {
                lstMaxLengthsColumns[intNoColumn] += 1;
                intNoColumn += 1;
            }
            // Space taken into account

            List<string> lstMenu = new List<string>();

            int intMaxLength = 0;
            foreach (int columnLength in lstMaxLengthsColumns)
                intMaxLength += columnLength;

            foreach (string titre in lstTitles)
                if (intMaxLength < titre.Length + 1)
                    intMaxLength = titre.Length + 1;

            // Formating the title lines
            foreach (string strTitle in lstTitles)
            {
                int nbSpacesLeft = (intMaxLength - strTitle.Length) / 2;
                int nbSpacesRight = intMaxLength - strTitle.Length - nbSpacesLeft;
                lstMenu.Add(string.Format("# {0}{1}{2}#",
                                          new string(' ', nbSpacesLeft),
                                          strTitle,
                                          new string(' ', nbSpacesRight)));
            }
            // Title lines formated

            // Formating the menu items
            bool titleLine = true;
            foreach (List<string> menuItem in lstLstColumnMenu)
            {
                intNoColumn = 0;
                string strMenuItem = string.Empty;
                foreach (string column in menuItem)
                {
                    if (intNoColumn == 0)
                        strMenuItem += new string(' ', lstMaxLengthsColumns[intNoColumn] - column.Length - 1) + column + " ";
                    else
                    {
                        // Attempt to convert string into double, in order to alter alignment
                        double dblTmp = 0;
                        if (double.TryParse(column, out dblTmp))
                            strMenuItem += new string(' ', lstMaxLengthsColumns[intNoColumn] - column.Length - 1) + column + " ";
                        else
                            strMenuItem += column + new string(' ', lstMaxLengthsColumns[intNoColumn] - column.Length);
                    }
                    intNoColumn += 1;
                }

                if (!titleLine || strMenuItem.Trim().Length > 0)
                {
                    lstMenu.Add(string.Format("# {0}{1}#",
                                              strMenuItem,
                                              new string(' ', intMaxLength - strMenuItem.Length)));
                    titleLine = false;
                }
            }
            // Menu items formated

            /* Insertion of separators on top of the menu, between the title lines and the column names
             * and on the bottom of the menu */
            //      +3 because of "# " in the beginning of the string and "#" in the end of the string
            string strSeparator = new string('#', intMaxLength + 3);
            lstMenu.Insert(0, strSeparator);
            lstMenu.Insert(lstTitles.Count + 1, strSeparator);

            if (boolColumnName)
                lstMenu.Insert(lstTitles.Count + 3, strSeparator);
            lstMenu.Add(strSeparator);
            // Separators inserted

            return lstMenu;
        }

        /// <summary>
        /// Instanciates a new Menu with the list of menu items
        /// </summary>
        /// <param name="menuItems">Items of the menu. For the item numbers not to be displayed, they must start with '-'</param>
        /// <param name="titles">Alternative title, displayed on several lines</param>
        /// <param name="columns">Columns those must be displayed. Expects the menu items to be splitted by '\t'</param>
        protected internal Menu(Dictionary<string, string> menuItems, List<string> titles, List<string> columns = null)
        {
            dicMenuItems = new Dictionary<string, string>();

            foreach (string choice in menuItems.Keys)
                dicMenuItems.Add(choice.ToUpper(), menuItems[choice]);

            lstTitles = titles;
            lstColumns = columns;
        }

        /// <summary>
        /// Instanciates a new Menu with the list of menu items
        /// </summary>
        /// <param name="menuItems">Items of the menu. For the item numbers not to be displayed, they must start with '-'</param>
        /// <param name="title">Alternative title of the menu</param>
        /// <param name="columns">Columns those must be displayed. Expects the menu items to be splitted by '\t'</param>
        protected internal Menu(Dictionary<string, string> menuItems, string title = "", List<string> columns = null)
        {
            dicMenuItems = new Dictionary<string, string>();

            foreach (string choice in menuItems.Keys)
                dicMenuItems.Add(choice.ToUpper(), menuItems[choice]);

            if (title.Length > 0)
                lstTitles = new List<string> { title };
            lstColumns = columns;
        }
    }
}
