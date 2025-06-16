using DemExTest.Common;
using DemExTest.Forms;
using DemExTest.Models;

namespace DemExTest
{
    public partial class MainForm : Form
    {
        private DatabaseService _db;
        public MainForm(DatabaseService db)
        {
            InitializeComponent();
            _db = db;
            LoadProducts();
        }

        private void ShowDetailInfo()
        {
            var currentProduct = dataGridView1.CurrentRow?.Tag as Product;
            ViewUtil.DisplayAllProperties(currentProduct, panel2);
        }

        private void LoadProducts()
        {
            dataGridView1.Rows.Clear();
            var products = SafeExecutor.TryExecute(() =>
                _db.ExecuteQuery(@"SELECT products.*, products_type.name as type_name,
                                   products_type.coefficient FROM products
                                   JOIN products_type ON products_type.id = product_type_id
                                  ORDER BY id DESC", r => new Product
                {
                    Id = r.GetInt32("id"),
                    Name = r.GetString("name"),
                    ProductTypeId = r.GetInt32("product_type_id"),
                    MinPrice = r.GetFloat("min_price"),
                    PriceReal = r.GetFloat("price_real"),
                    SizeYpak = r.GetString("size_ypak"),
                    WeightWithOutYpak = r.GetFloat("weight_without_ypak"),
                    WeightWithYpak = r.GetFloat("weight_with_ypak"),
                    HoursCreating = r.GetInt32("hours_creating"),
                    NumberChex = r.GetInt32("number_chex"),
                    AmountPeopleChex = r.GetInt32("amount_people_chex"),
                    ProductType = new ProductType
                    {
                        Id = r.GetInt32("product_type_id"),
                        Name = r.GetString("type_name"),
                        Coefficient = r.GetFloat("coefficient")
                    }
                }),
                ex => MessageBox.Show("Не удалсь получить продукцию",
                                      "Произошла ошибка",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error)
                );

            if (products != null)
            {
                foreach (var product in products)
                {
                    int rowIndex = dataGridView1.Rows.Add(
                        $"Артикул: {product.Id} | Тип: {product.ProductType.Name}\n" +
                        $"Наименование продукции: {product.Name}\n\n" +
                        $"Себестоимость: {product.PriceReal} руб.\n" +
                        $"Минимальная стоимость для партнера: {product.MinPrice} руб."
                    );
                    dataGridView1.Rows[rowIndex].Tag = product;
                }
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            ShowDetailInfo();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowDetailInfo();
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            var product = dataGridView1.CurrentRow?.Tag as Product;

            if (product != null)
            {
                var dialogResult = MessageBox.
                    Show($"Вы увернны, что хотите удалить продукт - \"{product.Name}\"?",
                          "Подтвердите действие",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    var parameters = new Dictionary<string, object>()
                    {
                        {"@id", product.Id }
                    };
                    int? rowsAffected = SafeExecutor.TryExecute<int?>(() =>
                        _db.ExecuteNonQuery("DELETE FROM products WHERE id = @id", parameters),
                        ex => MessageBox.Show("Не удалось удалить продукт. Возможно он был удален другим пользователем")
                    );

                    if (rowsAffected == null)
                    {
                        return;
                    }

                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    ShowDetailInfo();
                    MessageBox.Show("Продукт успешно удален",
                                    "Успех",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.Tag is Product product)
            {
                List<ProductType>? productsTypes = SafeExecutor.TryExecute(() =>
                    _db.ExecuteQuery("SELECT * FROM products_type", r => new ProductType
                    {
                        Id = r.GetInt32("id"),
                        Name = r.GetString("name"),
                        Coefficient = r.GetFloat("coefficient"),
                    }),
                    ex => MessageBox.Show("Не удалось получить список типа продукции")
                );

                if (productsTypes == null)
                {
                    return;
                }

                var form = new CEForm(productsTypes, product);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var updatedProduct = form.GetProduct();
                    var parameters = new Dictionary<string, object>()
                    {
                        {"@id", product.Id},
                        {"@product_type_id", product.ProductTypeId },
                        {"@name", product.Name },
                        {"@min_price", product.MinPrice },
                        {"@price_real", product.PriceReal },
                        {"@size_ypak", product.SizeYpak },
                        {"@weight_without_ypak", product.WeightWithOutYpak },
                        {"@weight_with_ypak", product.WeightWithYpak },
                        {"@hours_creating", product.HoursCreating },
                        {"@number_chex", product.NumberChex},
                        {"@amount_people_chex", product.AmountPeopleChex }
                    };

                    int? rowsAffected = SafeExecutor.TryExecute<int?>(() =>
                        _db.ExecuteNonQuery(@"UPDATE products SET product_type_id = @product_type_id,
                                                         name = @name, min_price = @min_price,
                                                         price_real = @price_real,
                                                         size_ypak = @size_ypak,
                                                         weight_without_ypak = @weight_without_ypak,
                                                         weight_with_ypak = @weight_with_ypak,
                                                         hours_creating = @hours_creating,
                                                         number_chex = @number_chex,
                                                         amount_people_chex = @amount_people_chex
                                            WHERE id = @id", parameters),
                        ex => MessageBox.Show("Произошла ошибка при обновлении продукта. Попробуйте позже",
                                              "Ошибка",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Error)
                    );

                    if (rowsAffected == null)
                    {
                        return;
                    }

                    dataGridView1.CurrentRow.Tag = updatedProduct;
                    dataGridView1.CurrentCell.Value = $"Артикул: {product.Id} | Тип: {product.ProductType!.Name}\n" +
                        $"Наименование продукции: {product.Name}\n\n" +
                        $"Себестоимость: {product.PriceReal} руб.\n" +
                        $"Минимальная стоимость для партнера: {product.MinPrice} руб.";

                    ShowDetailInfo();
                    MessageBox.Show("Продукт успешно обновлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            List<ProductType>? productsTypes = SafeExecutor.TryExecute(() =>
                _db.ExecuteQuery("SELECT * FROM products_type", r => new ProductType
                {
                    Id = r.GetInt32("id"),
                    Name = r.GetString("name"),
                    Coefficient = r.GetFloat("coefficient"),
                }),
                ex => MessageBox.Show("Не удалось получить список типа продукции")
            );

            if (productsTypes == null)
            {
                return;
            }

            var form = new CEForm(productsTypes);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var createdProduct = form.GetProduct();
                var parameters = new Dictionary<string, object>()
                {
                    {"@product_type_id", createdProduct.ProductTypeId },
                    {"@name", createdProduct.Name },
                    {"@min_price", createdProduct.MinPrice },
                    {"@price_real", createdProduct.PriceReal },
                    {"@size_ypak", createdProduct.SizeYpak },
                    {"@weight_without_ypak", createdProduct.WeightWithOutYpak },
                    {"@weight_with_ypak", createdProduct.WeightWithYpak },
                    {"@hours_creating", createdProduct.HoursCreating },
                    {"@number_chex", createdProduct.NumberChex},
                    {"@amount_people_chex", createdProduct.AmountPeopleChex }
                };

                int? rowsAffected = SafeExecutor.TryExecute<int?>(() =>
                    _db.ExecuteNonQuery(@"INSERT INTO products (name, product_type_id,
                                                                min_price, price_real,
                                                                size_ypak, weight_without_ypak,
                                                                weight_with_ypak, hours_creating,
                                                                number_chex, amount_people_chex)
                                                VALUES (@name, @product_type_id, @min_price, @price_real, @size_ypak,
                                                        @weight_without_ypak, @weight_with_ypak, @hours_creating,
                                                        @number_chex, @amount_people_chex)", 
                                        parameters),
                    ex => MessageBox.Show("Произошла ошибка при добавлении продукта. Попробуйте позже",
                                            "Ошибка",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error)
                );

                if (rowsAffected == null)
                {
                    return;
                }

                LoadProducts();
                ShowDetailInfo();
                MessageBox.Show("Продукт успешно добавлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
