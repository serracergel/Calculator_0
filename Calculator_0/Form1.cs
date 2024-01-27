using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Channels;
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



        #region Deneme
        //int number=0;
        //int count;
        //int number2;
        //int result;

        //private void btnMultiply_Click(object sender, EventArgs e)
        //{
        //    count++;
        //}

        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    count++;
        //}

        //private void btnCalculate_Click(object sender, EventArgs e)
        //{

        //    Calculate(symbol);
        //}


        //#region
        ////foreach (control i in controls)
        ////{
        ////    if (i is button)
        ////    {
        ////        if ((sender as button).text == i.text)
        ////        {
        ////            sayi = convert.toınt32(i.text);
        ////        }
        ////    }
        ////}
        ////if (toplam == 0) findthenumber(sender, sayi);

        ////else findthenumber(sender, sayi2);
        //#endregion

        //string symbol;
        //#region MyRegion
        ////private void FindTheNumber(object sender,int number)
        ////{
        ////    for (int i = 0; i < 9; i++)
        ////    {
        ////        if ((sender as Button).Text == i.ToString())
        ////        {
        ////            number = i;
        ////           Text= number.ToString();
        ////        }
        ////    }
        ////} 
        //#endregion

        //private void btnMinus_Click(object sender, EventArgs e)
        //{
        //    count++;
        //}

        //private void btnDivide_Click(object sender, EventArgs e)
        //{
        //    count++;
        //}

        //private void btn2_Click(object sender, EventArgs e)
        //{
        //    //FindingTheNumber((sender as Button).Text);
        //    symbol=(sender as Button).Text;
        //    FindNumber(2, symbol);


        //}

        //private void FindNumber(int sayi,string text)
        //{
        //    if (count == 0|| number==0)
        //    {
        //        number += sayi;
        //        Text = number.ToString();
        //    }
        //    else
        //    {

        //        number2 = Convert.ToInt32(text);
        //        Text= number2.ToString();   
        //    }


        //}

        ////private void FindingTheNumber(string text)
        ////{
        ////    if (count!=0)
        ////    number = Convert.ToInt32(text);
        ////    else
        ////    {

        ////    }
        ////    lblResult.Text=number.ToString();
        ////}

        //private void btn3_Click(object sender, EventArgs e)
        //{
        //    //FindingTheNumber((sender as Button).Text);
        //    symbol=(sender as Button).Text;
        //    FindNumber(3, symbol); 
        //}

        //private void btn4_Click(object sender, EventArgs e)
        //{
        //    //FindingTheNumber((sender as Button).Text); 
        //    FindNumber(4,symbol);
        //}

        //private void btn1_Click(object sender, EventArgs e)
        //{
        //    FindNumber(1, symbol);

        //}

        //private void btn5_Click(object sender, EventArgs e)
        //{
        //    //FindingTheNumber((sender as Button).Text);
        //    FindNumber(5,symbol);
        //}

        //private void btn6_Click(object sender, EventArgs e)
        //{
        //    //FindingTheNumber((sender as Button).Text);
        //    FindNumber(6,symbol);
        //}

        //private void btn7_Click(object sender, EventArgs e)
        //{
        //    FindNumber(7,symbol);
        //}

        //private void btn8_Click(object sender, EventArgs e)
        //{
        //    //FindingTheNumber((sender as Button).Text);
        //    FindNumber(8, symbol);
        //}

        //private void btn9_Click(object sender, EventArgs e)
        //{
        //    FindNumber(9, symbol);
        //}

        //private void btn0_Click(object sender, EventArgs e)
        //{
        //    FindNumber(0,symbol);
        //}

        //public void Calculate(string text)
        //{
        //    switch (text)
        //    {
        //        case "/":
        //         result =  number / number2;
        //            break;
        //        case "+":
        //            result = number + number2;
        //            break;
        //            case "-":
        //                result = number - number2;
        //            break; 
        //        case "x":
        //            result = number * number2; 
        //            break;
        //        default:
        //            break;
        //    }

        //}

        //private void btnReset_Click(object sender, EventArgs e)
        //{
        //    count = 0;
        //} 




        // number1= float.Parse(firstN);
        //nmr1 +=(sender as Button).Text;
        //    number1=Convert.ToSingle(nmr1);


        //else //operation != 0
        //{

        //    //foreach?
        //    List<>
        //    number2 =Convert.ToSingle((sender as Button).Text);






        //}
        #endregion
        byte operation;

        
       
        private void btnReset_Click(object sender, EventArgs e)
        {
           
            txtResult.Clear();
        }

        
        float number1;
        float number2;
        
        private void btn1_Click(object sender, EventArgs e)
        {
           

            txtResult.Text += (sender as Button).Text;

            

        }

       
        //TODO : Refactoring


        //.If first charachter is 0 than write that character on to zero 

        private void GetText(float number,string text)
        {
            string nmr1 = null;

            for (int i = 0; i < txtResult.Text.Length - 1; i++)
            {
                nmr1 += txtResult.Text[i];
            }
            try
            {   
                if (string.IsNullOrEmpty(lblProcess.Text)) 
                {
                   
                        number1 = Convert.ToSingle(nmr1,CultureInfo.InvariantCulture);
                    if (number1 != 0 && txtResult.Text[txtResult.Text.Length - 2] == '-')
                        number1 = number1 * -1;
                        Text = number1.ToString();
                    
                }
                else
                {
                   
                        number2 = (Convert.ToSingle(nmr1, CultureInfo.InvariantCulture)) ;
                    if (number2 != 0 && txtResult.Text[txtResult.Text.Length - 2] == '-')
                        number2 = number2 * -1;
                    Text = number2.ToString();
                }


                if (text!="-")
                {
                    lblProcess.Text += txtResult.Text;
                    txtResult.Clear();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

     
        private void btnDivide_Click(object sender, EventArgs e)
        {
            operation = 4;
            SymbolCheck();
            AddToTextBox((sender as Button).Text);
            GetText(number1,(sender as Button).Text);  
        }

        private void SymbolCheck()
        {
            try
            {
                char ch = txtResult.Text[txtResult.Text.Length - 1];

               
                //if (ch == '+' || ch == 'x' || ch == '/' || ch=='-' )
                //{
                //    //TODO:or dont show anything on messagebox and catch(Length) last symbol(item) and put it rather than that symbol
                //    MessageBox.Show("There is already an ongoing process ");
                //    return;
                //}

            }
            catch (IndexOutOfRangeException)
            {

                MessageBox.Show("Wrong usage of a symbol");
               
            }
         

        }

        private void AddToTextBox(string message)
        {
            txtResult.Text += message;
        }

        //Event binding?
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            operation = 3;
            SymbolCheck();
            AddToTextBox((sender as Button).Text);

            GetText(number1, (sender as Button).Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            operation = 1;
            SymbolCheck();
            AddToTextBox((sender as Button).Text);
            GetText(number1, (sender as Button).Text);
            
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            
            if (operation==0)
            {
                operation = 2;
            }
            
            AddToTextBox((sender as Button).Text);
            GetText(number1,(sender as Button).Text);
          
        }
        float result;
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            txtResult.Text += "=";

            GetText(number2, (sender as Button).Text);

            switch (operation)
            {
                case 1:
                    result = number1 + number2;
                    break;
                case 2:
                    result = number1 - number2;
                    break;
                case 3:
                    result = number1 * number2;
                    break;
                case 4:
                    result = number1 / number2;
                    break;

            }
            number1 = result;

            txtResult.Text = result.ToString();
           
            operation = 0;
        }

      
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
            lblProcess.Text = "";
        }
    }
}
