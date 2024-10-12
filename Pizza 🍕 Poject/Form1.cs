using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza____Poject
{
    public partial class frmPizzaOrder : Form
    {
        public frmPizzaOrder()
        {
            InitializeComponent();
        }

        void UpdateSize()
        {
            UpdateTotalPrice();

            if (rbSmall.Checked)
            {
                lblSize.Text = "Small";
                return;
            }
               
            if (rbMedium.Checked)
            {
                lblSize.Text = "Medium";
                return;
            }

            if (rbLarge.Checked)
            {
                lblSize.Text = "Large";
                return;
            }
        }

        void UpdateCrustType()
        {
            UpdateTotalPrice();

            if (rbThin.Checked)
            {
                lblCrustType.Text = "Thin Crust";
                return;
            }
            
            if (rbThick.Checked)
            {
                lblCrustType.Text = "Thick Crust";
                return;
            } 
        }

        void UpdateWhereToEat()
        {
            if (rbEatIn.Checked)
            {
                lblWhereToEat.Text = "Eat In";
                return;
            }
            else
            {
                lblWhereToEat.Text = "Take Out";
                return;
            }
              
        }

        void UpdateTopping()
        {
            UpdateTotalPrice();

            string sToppings = "";

            if (chkExtraCheese.Checked)
                sToppings += "Extra Cheese";

            if (chkMushrooms.Checked)
                sToppings += ", Mushrooms";

            if (chkTomatos.Checked)
                sToppings += ", Tomatoes";

            if (chkOnion.Checked)
                sToppings += ", Onion";

            if (chkOlives.Checked)
                sToppings += ", Olives";

            if (chkGreenPeppers.Checked)
                sToppings += ", Green Peppers";

            if (sToppings.StartsWith(","))
            {
                sToppings = sToppings.Substring(1, sToppings.Length - 1).Trim();
            }

            if(sToppings == "")
            {
                sToppings = "No Toppings";
            }

            lblToppings.Text = sToppings;
        }


        float GetSelectedSizePrice()
        {
            if (rbSmall.Checked)

                return Convert.ToSingle(rbSmall.Tag);

            else if (rbMedium.Checked)

                return Convert.ToSingle(rbMedium.Tag);

            else
                return Convert.ToSingle(rbLarge.Tag);

        }

        float GetSelectedCrustTypePrice()
        {
            if (rbThin.Checked)
                return Convert.ToSingle(rbThin.Tag);

            else
                return Convert.ToSingle(rbThick.Tag);

        }

        float CalculateToppingsPrice()
        {
            float TotalPrice = 0;

            if (chkExtraCheese.Checked)
                TotalPrice += Convert.ToSingle(chkExtraCheese.Tag);

            if (chkMushrooms.Checked)
                TotalPrice += Convert.ToSingle(chkMushrooms.Tag);

            if (chkTomatos.Checked)
                TotalPrice += Convert.ToSingle(chkTomatos.Tag);

            if (chkOnion.Checked)
                TotalPrice += Convert.ToSingle(chkOnion.Tag);

            if (chkOlives.Checked)
                TotalPrice += Convert.ToSingle(chkOlives.Tag);

            if (chkGreenPeppers.Checked)
                TotalPrice += Convert.ToSingle(chkGreenPeppers.Tag);


            return TotalPrice;
        }

        float CalculatTotalPrice()
        {
            return (GetSelectedSizePrice() + GetSelectedCrustTypePrice() + CalculateToppingsPrice()) * Convert.ToSByte(nudPizzaAmount.Value);
        }

        void UpdateTotalPrice()
        {
            lblTotalPrice.Text = "$ " + CalculatTotalPrice().ToString();
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }


        private void rbThin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void rbThick_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }


        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void chkExtraCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTopping();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTopping();
        }

        private void chkTomatos_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTopping();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTopping();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTopping();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTopping();
        }

        void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateTopping();
            UpdateCrustType();
            UpdateWhereToEat();
            UpdateTotalPrice();
        }

        private void frmPizzaOrder_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }

        private void btOrderPizza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do you want to order?", "Confirm Order", MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                MessageBox.Show("You Ordered Successfuly", "Success", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

                gbSize.Enabled = false;
                gbCrustType.Enabled = false;
                gbToppings.Enabled = false;
                gbWhereToEat.Enabled = false;
                btOrderPizza.Enabled = false;
                nudPizzaAmount.Enabled = false;
                txtCustomerName.Enabled = false;
                txtPhoneNumber.Enabled = false;
            }
        }

        void ResetForm()
        {
            gbSize.Enabled = true;
            gbCrustType.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;

            rbMedium.Checked = true;
            rbThin.Checked = true;
            rbEatIn.Checked = true;

            chkExtraCheese.Checked = false;
            chkMushrooms.Checked = false;
            chkTomatos.Checked = false;
            chkOnion.Checked = false;
            chkOlives.Checked = false;
            chkGreenPeppers.Checked = false;

            nudPizzaAmount.Value = 1;
            nudPizzaAmount.Enabled = true;

            errorProvider1.SetError(txtCustomerName, "");
            errorProvider1.SetError(txtPhoneNumber, "");
            txtCustomerName.Enabled = true;
            txtPhoneNumber.Enabled = true;

            //UpdateTotalPrice();

            btOrderPizza.Enabled = true;


        }

        private void btResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void lblTotalPrice_Click(object sender, EventArgs e)
        {

        }

        private void nudPizzaAmount_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }

        private void txtCustomerName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                //e.Cancel = true;

                errorProvider1.SetError(txtCustomerName, "Customer Name must have a value");
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(txtCustomerName, "");
            }
        }

        private void txtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                errorProvider1.SetError(txtPhoneNumber, "Phone Number must have a value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPhoneNumber, "");
            }
        }
    }
}
