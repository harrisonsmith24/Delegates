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

namespace Smith_13._5
{
    public partial class Form1 : Form
    {
        // Create a list that will hole the data from the csv
        List<DowJones> dowData = new List<DowJones>();
        // SEt initial closing value
        double closingValue = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load the Dow data on form load
            LoadDowData();
        }

        private void LoadDowData()
        {
            // try statement to catch errors
            try
            {
                // read the file
                StreamReader inputFiles = File.OpenText("../../DJIA.csv");

                // loop to iterate through each line and add to list.
                while (!inputFiles.EndOfStream)
                {
                    // read each line
                    string line = inputFiles.ReadLine();
                    // split on tokens
                    string[] tokens = line.Split(',');

                    // If the check the length of the tokens array and add it to the list once it reaches 5
                    if (tokens.Length == 5)
                    {
                        // Create a new instance of the DowJones class
                        DowJones stock = new DowJones()
                        {
                            // Setting each value to the parameter of the class
                            Date = tokens[0],
                            Closing = double.Parse(tokens[1]),
                            Opening = double.Parse(tokens[2]),
                            HighestForDay = double.Parse(tokens[3]),
                            LowestForDay = double.Parse(tokens[4]), 
                        };
                        // add the item to the list
                        dowData.Add(stock);
                        
                    }
                    // run error message if need to
                    else
                    {
                        MessageBox.Show("Bad Data Encountered in File");
                    }
                }
            }
            // run error message if need to
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void startDateBtn_Click(object sender, EventArgs e)
        {
            // Initiate try statement to catch errors
            try
            {
                // Set closing values to the value entered by the user
                closingValue = double.Parse(enteredValue.Text.ToString());
                // Create a new list to hold only the values needed using lambda expression
                List<DowJones> results = dowData.FindAll(items => items.Closing >= closingValue);
                // Clear the items in the listbox
                dowValuesBox.Items.Clear();

                // Throw error if value entered is too high
                if (closingValue > 24719.82)
                {
                    MessageBox.Show("Value too high");
                }
                // Setting the combo box choice to run on selected result
                if (typeBox.SelectedIndex == 0)
                {
                    // Showing the fist item in the list
                    dowValuesBox.Items.Add(results[0].Date);
                }
                else
                {
                    // itterate through each item in new list
                    foreach (DowJones item in results)
                    {
                        // display the values in the list box
                        dowValuesBox.Items.Add(item.Date);
                    }
                }
            }
            // thorw error message if need be
            catch
            {
                MessageBox.Show("Make sure you enter a value");
            }
            
        }
    }
}
