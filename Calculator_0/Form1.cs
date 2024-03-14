using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
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
                else
                {
                    if (operation == 5)
                    {
                        AddTextToLabel();
                        lblProcess.Text += "\r";
                        operation = 7;
                    }
                    txtResult.Text += (sender as Button).Text;
                }

            }
            else txtResult.Text += (sender as Button).Text;
        }
      
        //Add calculation operators("/","+"...) to textbox
        private bool AddToTextBox(string btnText)
        {
            try
            {
              
                if (string.IsNullOrEmpty(txtResult.Text) && string.IsNullOrEmpty(lblProcess.Text)) MessageBox.Show("Please first write number to calculate");
                //sayiyi zaten yakaladın else if'in amaci sadece operatoru degistirmek,yeni bir islem yapilmiyorsa.Labelda hic sayi girilmemisse hata cikarir (operation!=0) 
                #region ElseIfExp
                //if user didnt do any calculation,if new calculation startedand if user cleared the label(didnt click the ClearAll button),or user clicked the '.' button condition returns false 
                #endregion
                else if (operation!=0 && operation!=7 && operation!=6 && btnText != ".")
                {
                   
                    char last = lblProcess.Text[lblProcess.Text.Length - 1];
                    //Change the last entered operator with the new input 
                    if (last == '-' || last == '+' || last == 'x' || last == '/')
                    {
                        if (!string.IsNullOrEmpty(txtResult.Text))
                        {
                            MessageBox.Show("Please calculate one by one");
                            AreButtonsEnable(false);
                          

                        }
                        else
                        {
                            #region FailedAttempt
                            //Replaced all the values that have the same value as the 'last'  
                            //string replace = lblProcess.Text.Replace(last, Convert.ToChar(btnText));
                            //lblProcess.Text = replace; 
                            #endregion
                            string replace =lblProcess.Text.Remove(lblProcess.Text.Length-1);
                            replace += btnText;
                            lblProcess.Text = replace;
                        }
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

        private void AreButtonsEnable(bool button)
        {
            btnDivide.Enabled= button;
            btnMinus.Enabled = button;
            btnMultiply.Enabled = button;
            btnAdd.Enabled = button;
          
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
            //If number returns false than we already have an input
            if (number != false) number1 = GetText();

            if (btnDivide.Enabled != false)
            {
                AddTextToLabel();
                operation = 1;
            }
        }
        
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            bool number=AddToTextBox(btnMultiply.Text);
            //do we already have an input or not?
            if (number != false) number1 = GetText();

            //if the user tried to multiple calculation
            if (btnMultiply.Enabled != false)
            {
                AddTextToLabel();
                operation = 2;
            }
        }
         
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool number=AddToTextBox(btnAdd.Text);
           if(number!=false) number1 = GetText();

            if (btnAdd.Enabled != false)
            {
                AddTextToLabel();
                operation = 3;
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            bool number=AddToTextBox(btnMinus.Text);
            if (number != false) number1 = GetText();

            if (btnMinus.Enabled != false)
            {
                AddTextToLabel();
                operation = 4;
            }
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
                //enable operator buttons(+,-...)
                AreButtonsEnable(true);
                
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
