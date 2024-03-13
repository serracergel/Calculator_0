using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(txtResult.Text))
            {
                //If the first character entered in the tbox is "0"
                if (txtResult.Text[0] == '0')
                {
                    string replace = txtResult.Text.Replace("0", (sender as Button).Text);
                    txtResult.Text = replace;
                }
                else if (operation == 5) MessageBox.Show("Please enter a calculation sign");
                else txtResult.Text += (sender as Button).Text;

            }
            else txtResult.Text += (sender as Button).Text;
        }
      
        //Add calculation operators("/","+"...) to textbox
        private bool AddToTextBox(string btnText)
        {
            try
            {
              
                if (string.IsNullOrEmpty(txtResult.Text) && string.IsNullOrEmpty(lblProcess.Text)) MessageBox.Show("Please first write number to calculate");

                else if (!string.IsNullOrEmpty(lblProcess.Text))
                {
                   
                    char last = lblProcess.Text[lblProcess.Text.Length - 1];
                    //Change the last entered operator with the new input 
                    if (last == '-' || last == '+' || last == 'x' || last == '/')
                    {
                        string replace = lblProcess.Text.Replace(last, Convert.ToChar(btnText));
                        lblProcess.Text = replace;

                    }
                    else txtResult.Text += btnText;
                    return false;
                    #region WhyReturningFalse?
                    //If user changed the operator dont try to catch the input/number(you already have it).I made an algorithm that if there is an already existing operator ,when User clicks the another operator just change the operator and return false to catch any number(we already have input in that time)
                    #endregion
                }
                else txtResult.Text += btnText;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
         
            return true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResult.Text) || operation == 5) MessageBox.Show("Wrong character usage");
            
            else AddToTextBox((sender as Button).Text);
        }

        //Clear textbox(last input)
        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
        }

        byte operation;
        
        private void btnDivide_Click(object sender, EventArgs e)
        {
            bool number=AddToTextBox(btnDivide.Text);
            if (number != false) number1 = GetText();
           
            AddTextToLabel();
            operation = 1;
        }
        
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            bool number=AddToTextBox(btnMultiply.Text);
            if (number != false) number1 = GetText();
           //do we already have an input or not?
            AddTextToLabel();
            operation = 2;
        }
         
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool number=AddToTextBox(btnAdd.Text);
           if(number!=false) number1 = GetText();

            AddTextToLabel();
            operation = 3;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            bool number=AddToTextBox(btnMinus.Text);
            if (number != false) number1 = GetText();
          
            AddTextToLabel();
            operation = 4;
        }
        //Main input 
        float number1;
      

        //Get the input from the textbox
        private float GetText()
        {
           //if user already calculated, return result as first number but if User clicked C(clear all) get a new input(dont return result as first number) 
            if (operation == 5 && operation!=6) return number1;
            
            string numbers=null;
            foreach(char item in txtResult.Text)
            {
                if (item != '-' && item != '+' && item != 'x' && item != '/')
                {
                    numbers += item;
                }
            }
           
            if (operation!=0 &&numbers==null)
            {
                MessageBox.Show("Please enter input");
            }
                float number = Convert.ToSingle(numbers, CultureInfo.InvariantCulture);
                return number;
        }
      

        private void AddTextToLabel()
        {
            lblProcess.Text += txtResult.Text;
            txtResult.Clear();
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                float number2 = GetText();

                AddTextToLabel();

                lblProcess.Text += "=";

                switch (operation)
                {
                  
                    case 1:
                        if (number2 != 0) number1 /= number2;

                        else
                        {
                            MessageBox.Show("Cannot divide by zero!");
                            return;
                        }
                        break;
                  
                    case 2:
                        number1 *= number2;
                        break;
                   
                    case 3:
                        number1 += number2;
                        break;
                   
                    case 4:
                        number1 -= number2;

                        break;
                    default:
                        //operation=0 
                        if (number1 != 0) MessageBox.Show("Please write a calculation");
                        break;
                }
                txtResult.Text = $"{number1}";

                string checkedNumber = txtResult.Text.Replace(',', '.');
                number1 = Convert.ToSingle(checkedNumber, CultureInfo.InvariantCulture);
                //InvariantCulture(prop of CultureInfo):Enables calculation according to the format of float numbers(ex:5.6,346.2)
                operation = 5; 
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            operation = 6;
            lblProcess.Text = null;
            txtResult.Text = null;
        }


     
    }
}
