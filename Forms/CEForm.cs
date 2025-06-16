using DemExTest.Common;
using DemExTest.Models;

namespace DemExTest.Forms
{
    public partial class CEForm : Form
    {
        private Product? product;
        private bool isEditMode;

        public CEForm(List<ProductType> product_types, Product? product = null)
        {
            InitializeComponent();

            isEditMode = product != null;

            if (!isEditMode)
            {
                this.product = new Product();
                comboBox1.DataSource = product_types;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                this.product = product;
                textBox1.Text = product!.Name;
                textBox2.Text = product!.MinPrice.ToString();
                textBox3.Text = product!.PriceReal.ToString();
                textBox4.Text = product!.SizeYpak;
                textBox5.Text = product!.WeightWithOutYpak.ToString();
                textBox6.Text = product!.WeightWithYpak.ToString();
                textBox7.Text = product!.HoursCreating.ToString();
                textBox8.Text = product!.NumberChex.ToString();
                textBox9.Text = product!.AmountPeopleChex.ToString();
                comboBox1.DataSource = product_types;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
                comboBox1.SelectedValue = product.ProductTypeId;
            }
        }

        public Product GetProduct()
        {
            return product!;
        }

        private void SaveChangesBtn_Click(object sender, EventArgs e)
        {
            product!.Name = textBox1.Text;
            product!.ProductTypeId = int.Parse(comboBox1.SelectedValue.ToString());
            product!.MinPrice = float.Parse(textBox2.Text);
            product!.PriceReal = float.Parse(textBox3.Text);
            product!.SizeYpak = textBox4.Text;
            product!.WeightWithOutYpak = float.Parse(textBox5.Text);
            product!.WeightWithYpak = int.Parse(textBox6.Text);
            product!.HoursCreating = int.Parse(textBox7.Text);
            product!.NumberChex = int.Parse(textBox8.Text);
            product!.AmountPeopleChex = int.Parse(textBox9.Text);

            if (!CustomValidator.TryValidate(product!, out var validationErrors))
            {
                string message = string.Join("\n", validationErrors.Select(e => e.ErrorMessage));
                MessageBox.Show(message, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
