using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Smith_13._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // try statement to try the input file of the random.txt file
            try
            {
                // declare predicate to find negatives
                Predicate<int> IsNegative = delegate (int z)
                {
                    // bool type to determine a negative number
                    bool isNegativeNum = false;

                    // is statement to find negative numbers
                    if (z < 0)
                    {
                        // setting bool to true if number is negative
                        isNegativeNum = true;
                    }
                    // return the negative number
                    return isNegativeNum;

                };

                // declare predicate to find the number between 1 and 10
                Predicate<int> isBtwOneAndTen = delegate (int z)
                {
                    // boolean to set the state of each number
                    bool isValue = false;

                    // if statement to determine if the number meets the criteria
                    if (z >= 1 && z <= 10)
                    {
                        // set the boolean if value is true
                        isValue = true;
                    }
                    // retun the value
                    return isValue;
                };
                // stream reader to read text file
                StreamReader inputFileNums;
                // get the file
                inputFileNums = File.OpenText("..\\..\\random.txt");
                // declare a list for the items from the file
                List<int> randomInts = new List<int>();

                // while loop to read each of the items in the list
                while (!inputFileNums.EndOfStream)
                {
                    // parse each item to make them intergers
                    int parseNum =int.Parse(inputFileNums.ReadLine());
                    // add the items to a the list
                    randomInts.Add(parseNum);
                    // add the items to the list box
                    numBox.Items.Add(parseNum);
                }

                // declare new list for the value of the numbers between 1 and 10
                List<int> valueBtw = randomInts.FindAll(isBtwOneAndTen);
                // loop through each item in the list 
                foreach (int i in valueBtw) 
                {
                    // add numbers to the list box
                    btwBox.Items.Add(i);
                }

                // remove all the negative numbers from the previous list
                randomInts.RemoveAll(IsNegative);

                // loop through the list
                foreach (int i in randomInts) 
                {
                    // add the numbers to the list box
                    negBox.Items.Add(i);
                }
            }
            // catch statment if error is thrown
            catch (Exception ex)
            {
                // alert message
                MessageBox.Show(ex.Message);
            };
        }
    }
}
