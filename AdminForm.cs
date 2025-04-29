using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Guna.UI2.WinForms;
using System.Diagnostics;

namespace Kalimov_curs
{
    public partial class AdminForm : Form
    {
        private MySqlConnection connection;
        private int userId;
        private int _roleId;
        private bool isOverdueMessageShown = false;
        private Size _originalSize;
        private Dictionary<Control, Rectangle> _controlsData = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, Font> _originalFonts = new Dictionary<Control, Font>();
        private const float MaxComboBoxFontSize = 13f; 

        public AdminForm(int userId, int roleId)
        {
            InitializeComponent();
            _roleId = roleId;
            this.userId = userId; 

            _originalSize = this.Size;
            SaveControlDimensions(this);
            this.MinimumSize = new Size(850, 525);
            Database db = new Database(
                "///",
                "///",
                "///",
                "///"
            );
            connection = db.GetConnection();


            DtpStartSuppliers.Value = DateTime.Today;
            DtpEndSuppliers.Value = DateTime.Today.AddYears(2);
            LoadDropdowns();
            LoadPurchases();
            LoadProducts();
            LoadSuppliers();
            ConfigureTabAccess();
            LoadWriteOffs();
            LoadStockData();
            StyleDataGridView(dataGridViewProducts);
            StyleDataGridView(dataGridViewPurchases);
            StyleDataGridView(dataGridViewSuppliers);
            StyleDataGridView(dataGridViewWriteOffs); 
            StyleDataGridView(dataGridViewStock);
            this.Resize += AdminForm_Resize;
            this.Load += AdminForm_Load;
        }

        private void SaveControlDimensions(Control container)
        {
            foreach (Control ctrl in container.Controls)
            {
                _controlsData[ctrl] = new Rectangle(ctrl.Location, ctrl.Size);
                _originalFonts[ctrl] = ctrl.Font;

                if (ctrl.HasChildren)
                    SaveControlDimensions(ctrl);
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // Устанавливаем форму на весь экран
            this.WindowState = FormWindowState.Maximized;

            dataGridViewPurchases.SelectionChanged += dataGridViewPurchases_SelectionChanged;
            dataGridViewSuppliers.SelectionChanged += dataGridViewSuppliers_SelectionChanged;
            dataGridViewProducts.SelectionChanged += dataGridViewProducts_SelectionChanged;
            ComboProductWithSupplier.SelectedIndexChanged += ComboProductPurchases_SelectedIndexChanged;
            BtnFilterPurchases.Click += BtnFilterPurchases_Click;
            Stock.Enter += Stock_Enter;

        }
        private void Stock_Enter(object sender, EventArgs e)
        {
            LoadStockData();
        }
        private int? GetSelectedId(DataGridView gridView, string columnName, string errorMessage = "Выберите запись.")
        {
            if (gridView.SelectedRows.Count == 0)
            {
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            var row = gridView.SelectedRows[0];


            string[] possibleColumnNames = { columnName, "ID", columnName.ToLower() };

            foreach (var name in possibleColumnNames)
            {
                if (gridView.Columns.Contains(name))
                {
                    var cell = row.Cells[name];
                    if (cell?.Value != null && int.TryParse(cell.Value.ToString(), out int id))
                    {
                        return id;
                    }
                }
            }

            MessageBox.Show($"Не удалось найти ID выбранной записи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        private void AdminForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized || this.ClientSize.Width <= 0 || this.ClientSize.Height <= 0)
                return;

            try
            {
                float scaleX = (float)this.ClientSize.Width / _originalSize.Width;
                float scaleY = (float)this.ClientSize.Height / _originalSize.Height;
                float scale = Math.Min(scaleX, scaleY);

                foreach (Control ctrl in _controlsData.Keys.ToList())
                {
                    try
                    {
                        if (ctrl == null || !_controlsData.ContainsKey(ctrl)) continue;

                        Rectangle original = _controlsData[ctrl];
                        ctrl.Left = (int)(original.Left * scaleX);
                        ctrl.Top = (int)(original.Top * scaleY);
                        ctrl.Width = Math.Max(1, (int)(original.Width * scaleX));
                        ctrl.Height = Math.Max(1, (int)(original.Height * scaleY));

                        if (_originalFonts.ContainsKey(ctrl) && _originalFonts[ctrl] != null)
                        {
                            float fontSize = _originalFonts[ctrl].Size * scale;

                            if (ctrl is ComboBox || ctrl is Guna2ComboBox) 
                            {
                                fontSize = Math.Min(fontSize, MaxComboBoxFontSize); 
                            }

                            fontSize = Math.Max(6, fontSize); 
                            ctrl.Font = new Font(_originalFonts[ctrl].FontFamily, fontSize, _originalFonts[ctrl].Style);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Ошибка масштабирования {ctrl.Name}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка в Resize: {ex.Message}");
            }
        }

        private void ConfigureTabAccess()
        {

            var tabAccess = new Dictionary<string, bool>
    {
        {"Stock", _roleId == 1 || _roleId == 3},
        {"Write_offs", _roleId == 1 || _roleId == 3},
        {"Product", _roleId == 1 || _roleId == 2},    
        {"Purchases", _roleId == 1 || _roleId == 2},  
        {"Supplier", _roleId == 1 || _roleId == 2}    
    };

            List<TabPage> allTabs = new List<TabPage>
    {
        Stock,
        Write_offs,
        Product,
        Purchases,
        Supplier
    };

            TabControl.TabPages.Clear();

            foreach (var tab in allTabs)
            {
                if (tabAccess.TryGetValue(tab.Name, out bool allowed) && allowed)
                {
                    TabControl.TabPages.Add(tab);
                }
            }

            if (TabControl.TabPages.Count > 0)
            {
                TabControl.SelectedTab = TabControl.TabPages[0];
            }
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            DataGridViewCellStyle rowsStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(59, 163, 208),
                ForeColor = Color.FromArgb(2, 74, 104),
                SelectionBackColor = Color.FromArgb(2, 74, 104),
                SelectionForeColor = Color.FromArgb(59, 163, 208)
            };
            dgv.DefaultCellStyle = rowsStyle;
            dgv.AlternatingRowsDefaultCellStyle = rowsStyle;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                BackColor = Color.Teal,
                ForeColor = Color.FromArgb(0, 0, 64),
                SelectionBackColor = Color.Teal,
                SelectionForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                WrapMode = DataGridViewTriState.True
            };
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersHeight = 100;

            DataGridViewCellStyle rowHeaderStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(59, 163, 208),
                ForeColor = SystemColors.WindowText,
                SelectionBackColor = Color.FromArgb(59, 163, 208),
                SelectionForeColor = SystemColors.HighlightText
            };
            dgv.RowHeadersDefaultCellStyle = rowHeaderStyle;

            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.FromArgb(59, 163, 208);
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.RowTemplate.Height = 28;
            dgv.EnableHeadersVisualStyles = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadComboBox(string query, ComboBox comboBox)
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();

                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboBox.DataSource = dt.Rows.Count > 0 ? dt : null;
                if (dt.Columns.Count >= 2)
                {
                    comboBox.DisplayMember = dt.Columns[1].ColumnName;
                    comboBox.ValueMember = dt.Columns[0].ColumnName;
                }
                comboBox.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных в {comboBox.Name}: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
        private void LoadDropdowns()
        {
            LoadComboBox("SELECT suppliers_id, suppliers_name FROM suppliers", ComboSuppliersProduct);
            LoadComboBox("SELECT products_id, products_name FROM products", ComboProductWithSupplier);
            LoadComboBox("SELECT contract_id, contract_name FROM contracts", ComboContractSupplier);
            LoadComboBox("SELECT products_id, products_name FROM products", comboBoxProducts);
            LoadProductsWithSuppliers();

        }


       
        private void LoadSuppliers()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = @"
            SELECT 
                s.suppliers_id, 
                s.suppliers_name, 
                s.suppliers_phone, 
                s.suppliers_address, 
                s.start_date, 
                s.end_date,
                c.contract_name
            FROM suppliers s
            LEFT JOIN contracts c ON s.contract = c.contract_id
            ORDER BY s.start_date DESC";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Columns.Contains("suppliers_id") && dt.Columns.Contains("suppliers_name") &&
                    dt.Columns.Contains("suppliers_phone") && dt.Columns.Contains("suppliers_address") &&
                    dt.Columns.Contains("start_date") && dt.Columns.Contains("end_date") &&
                    dt.Columns.Contains("contract_name"))
                {
                    dataGridViewSuppliers.DataSource = dt;
                    dataGridViewSuppliers.Columns["suppliers_id"].Visible = false;
                    dataGridViewSuppliers.Columns["suppliers_name"].HeaderText = "Наименование";
                    dataGridViewSuppliers.Columns["suppliers_phone"].HeaderText = "Телефон";
                    dataGridViewSuppliers.Columns["suppliers_address"].HeaderText = "Адрес";
                    dataGridViewSuppliers.Columns["contract_name"].HeaderText = "Контракт";
                    dataGridViewSuppliers.Columns["start_date"].HeaderText = "Дата начала";
                    dataGridViewSuppliers.Columns["end_date"].HeaderText = "Дата окончания";
                }
                else
                {
                    MessageBox.Show("Один или несколько столбцов отсутствуют в таблице.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        private void LoadPurchases()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();

                connection.Open();

                string query = @"
            SELECT 
                p.purchases_id AS ID,
                u.username AS user_name,
                s.suppliers_name AS supplier_id,
                pr.products_name AS product_name,
                p.purchases_quantity, 
                p.unit_price,
                p.purchases_total_price, 
                p.purchases_date,
                ps.purchases_status_name AS status_name
            FROM purchases p
            LEFT JOIN users u ON p.purchases_user_id = u.users_id
            LEFT JOIN suppliers s ON p.suppliers_id = s.suppliers_id
            LEFT JOIN products pr ON p.products_id = pr.products_id
            LEFT JOIN purchases_status ps ON p.status = ps.purchases_status_id
            ORDER BY p.purchases_id DESC";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewPurchases.DataSource = dt.Rows.Count > 0 ? dt : null;

                if (dt.Rows.Count > 0)
                {
                    if (dataGridViewPurchases.Columns.Contains("ID"))
                        dataGridViewPurchases.Columns["ID"].Visible = false;

                    dataGridViewPurchases.Columns["user_name"].HeaderText = "Пользователь";
                    dataGridViewPurchases.Columns["supplier_id"].HeaderText = "Поставщик";
                    dataGridViewPurchases.Columns["product_name"].HeaderText = "Товар";
                    dataGridViewPurchases.Columns["purchases_quantity"].HeaderText = "Количество";
                    dataGridViewPurchases.Columns["unit_price"].HeaderText = "Цена за единицу";
                    dataGridViewPurchases.Columns["purchases_total_price"].HeaderText = "Общая стоимость";
                    dataGridViewPurchases.Columns["purchases_date"].HeaderText = "Дата закупки";
                    dataGridViewPurchases.Columns["status_name"].HeaderText = "Статус";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки закупок: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
        private void LoadStockData()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = @"
            SELECT 
                p.products_name AS 'Товар',
                s.quantity AS 'Количество',
                p.min_quantity AS 'Мин. запас',
                CASE 
                    WHEN s.quantity <= p.min_quantity THEN 'Низкий запас'
                    ELSE 'Достаточно'
                END AS 'Статус',
                p.products_id
            FROM stock s
            JOIN products p ON s.product_id = p.products_id
            ORDER BY p.products_name";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewStock.DataSource = dt;

                if (dataGridViewStock.Columns.Contains("products_id"))
                    dataGridViewStock.Columns["products_id"].Visible = false;


                if (dataGridViewStock.Columns.Contains("Товар"))
                    dataGridViewStock.Columns["Товар"].DisplayIndex = 0;

                if (dataGridViewStock.Columns.Contains("Количество"))
                    dataGridViewStock.Columns["Количество"].DisplayIndex = 1;

                if (dataGridViewStock.Columns.Contains("Мин. запас"))
                    dataGridViewStock.Columns["Мин. запас"].DisplayIndex = 2;

                if (dataGridViewStock.Columns.Contains("Статус"))
                {
                    dataGridViewStock.Columns["Статус"].DisplayIndex = 3;
                }


                if (dataGridViewStock.Columns.Contains("Количество"))
                    dataGridViewStock.Columns["Количество"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                if (dataGridViewStock.Columns.Contains("Мин. запас"))
                    dataGridViewStock.Columns["Мин. запас"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных склада: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void LoadProducts()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = "SELECT p.products_id, p.products_name, p.products_price, " +
                               "p.min_quantity, s.suppliers_name " +
                               "FROM products p " +
                               "LEFT JOIN suppliers s ON p.suppliers_id = s.suppliers_id " +
                               "ORDER BY p.products_id DESC";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewProducts.DataSource = dt;

                if (dataGridViewProducts.Columns.Contains("products_id"))
                    dataGridViewProducts.Columns["products_id"].Visible = false;

                dataGridViewProducts.Columns["products_name"].HeaderText = "Название товара";
                dataGridViewProducts.Columns["products_price"].HeaderText = "Цена";
                dataGridViewProducts.Columns["min_quantity"].HeaderText = "Мин. кол-во";
                dataGridViewProducts.Columns["suppliers_name"].HeaderText = "Поставщик";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            try
            {
                TbNameProducts.Clear();
                TbPriceProduct.Clear();
                TbMinProduct.Clear();
                txtSearch.Clear();
                ComboSuppliersProduct.SelectedIndex = -1;

                if (dataGridViewProducts.DataSource is DataTable dt)
                {
                    dt.DefaultView.RowFilter = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при очистке полей: {ex.Message}");
            }
        }

        private void BtnAddPurchases_Click(object sender, EventArgs e)
        {
            // Проверка заполнения обязательных полей
            if (ComboProductWithSupplier.SelectedValue == null ||
                string.IsNullOrWhiteSpace(TbQauntityPurchases.Text) ||
                string.IsNullOrWhiteSpace(TbPricePurchases.Text))
            {
                MessageBox.Show("Заполните все обязательные поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                // Проверка минимального количества
                int selectedProductId = Convert.ToInt32(ComboProductWithSupplier.SelectedValue);
                int quantity = int.Parse(TbQauntityPurchases.Text);
                decimal unitPrice = decimal.Parse(TbPricePurchases.Text);

                string checkMinQtyQuery = @"
            SELECT min_quantity 
            FROM products 
            WHERE products_id = @id";

                MySqlCommand checkCmd = new MySqlCommand(checkMinQtyQuery, connection);
                checkCmd.Parameters.AddWithValue("@id", selectedProductId);

                int minQty = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (quantity < minQty)
                {
                    MessageBox.Show($"Минимальный объем закупки - {minQty} единиц.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Получаем supplier_id для выбранного продукта
                string getSupplierQuery = @"
            SELECT suppliers_id 
            FROM products 
            WHERE products_id = @productId";

                MySqlCommand supplierCmd = new MySqlCommand(getSupplierQuery, connection);
                supplierCmd.Parameters.AddWithValue("@productId", selectedProductId);
                int supplierId = Convert.ToInt32(supplierCmd.ExecuteScalar());

                // Расчет общей стоимости
                decimal totalPrice = quantity * unitPrice;

                // Добавление закупки
                string insertQuery = @"
            INSERT INTO purchases 
                (suppliers_id, products_id, purchases_user_id, purchases_quantity, 
                 purchases_date, purchases_total_price, unit_price, status) 
            VALUES 
                (@sup, @prod, @user, @qty, @date, @price, @unit, 1)";

                MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);
                insertCmd.Parameters.AddWithValue("@sup", supplierId);
                insertCmd.Parameters.AddWithValue("@prod", selectedProductId);
                insertCmd.Parameters.AddWithValue("@user", userId);
                insertCmd.Parameters.AddWithValue("@qty", quantity);
                insertCmd.Parameters.AddWithValue("@date", DateTime.Now);
                insertCmd.Parameters.AddWithValue("@price", totalPrice);
                insertCmd.Parameters.AddWithValue("@unit", unitPrice);

                int rowsAffected = insertCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Закупка успешно добавлена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPurchases();

                    // Очистка полей
                    TbQauntityPurchases.Clear();
                    TbPricePurchases.Clear();
                }
                else
                {
                    MessageBox.Show("Не удалось добавить закупку.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Проверьте числовые поля (кол-во, цена)!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void BtnCompletePurchase_Click(object sender, EventArgs e)
        {
            int? purchaseId = GetSelectedId(dataGridViewPurchases, "ID", "Выберите закупку для завершения.");
            if (purchaseId == null) return;

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();


                string checkStatusQuery = @"
            SELECT status, products_id, purchases_quantity 
            FROM purchases 
            WHERE purchases_id = @id";

                MySqlCommand checkCmd = new MySqlCommand(checkStatusQuery, connection);
                checkCmd.Parameters.AddWithValue("@id", purchaseId);

                using (MySqlDataReader reader = checkCmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        MessageBox.Show("Закупка не найдена.", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int currentStatus = reader.GetInt32("status");
                    int productId = reader.GetInt32("products_id");
                    int quantity = reader.GetInt32("purchases_quantity");

                    reader.Close();

                    if (currentStatus != 1)
                    {
                        string statusMessage = currentStatus == 2 ? "уже завершена" : "отменена";
                        MessageBox.Show($"Эта закупка {statusMessage} и не может быть обработана.", "Предупреждение",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    if (MessageBox.Show("Вы уверены, что хотите завершить эту закупку? Товары будут добавлены на склад.",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }


                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string updatePurchase = @"
                        UPDATE purchases 
                        SET status = 2 
                        WHERE purchases_id = @id AND status = 1"; 

                            MySqlCommand updateCmd = new MySqlCommand(updatePurchase, connection, transaction);
                            updateCmd.Parameters.AddWithValue("@id", purchaseId);
                            int rowsUpdated = updateCmd.ExecuteNonQuery();

                            if (rowsUpdated == 0)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Не удалось обновить статус закупки. Возможно, она была изменена другим пользователем.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            string updateStock = @"
                        INSERT INTO stock (product_id, quantity)
                        VALUES (@productId, @quantity)
                        ON DUPLICATE KEY UPDATE quantity = quantity + @quantity";

                            MySqlCommand stockCmd = new MySqlCommand(updateStock, connection, transaction);
                            stockCmd.Parameters.AddWithValue("@productId", productId);
                            stockCmd.Parameters.AddWithValue("@quantity", quantity);
                            stockCmd.ExecuteNonQuery();

                            string insertWriteOff = @"
                        INSERT INTO write_offs 
                            (products_id, quantity, user_id, write_on_date) 
                        VALUES 
                            (@productId, @quantity, @userId, NOW())";

                            MySqlCommand writeOffCmd = new MySqlCommand(insertWriteOff, connection, transaction);
                            writeOffCmd.Parameters.AddWithValue("@productId", productId);
                            writeOffCmd.Parameters.AddWithValue("@quantity", quantity);
                            writeOffCmd.Parameters.AddWithValue("@userId", userId);
                            writeOffCmd.ExecuteNonQuery();

                            transaction.Commit();

                            MessageBox.Show("Закупка успешно завершена! Товары добавлены на склад.", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadPurchases();
                            LoadWriteOffs();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Фатальная ошибка при обработке закупки: {ex.Message}", "Критическая ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при завершении закупки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        private void BtnDeletePurchases_Click(object sender, EventArgs e)
        {
            int? purchaseId = GetSelectedId(dataGridViewPurchases, "ID", "Выберите закупку для отмены.");
            if (purchaseId == null) return;

            if (MessageBox.Show("Вы уверены, что хотите отменить эту закупку?",
                                "Подтверждение",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();

                connection.Open();

                string cancelQuery = "UPDATE purchases SET status = 3 WHERE purchases_id = @id";
                MySqlCommand cmd = new MySqlCommand(cancelQuery, connection);
                cmd.Parameters.AddWithValue("@id", purchaseId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Закупка отменена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPurchases();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отмене закупки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }


        private void BtnCleanPurchases_Click(object sender, EventArgs e)
        {
            txtSearchPurchases.Clear();
            ComboProductWithSupplier.SelectedIndex = -1;
            TbQauntityPurchases.Clear();
            TbPricePurchases.Clear();

        }

        private void BtnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                int productId = Convert.ToInt32(dataGridViewProducts.SelectedRows[0].Cells["products_id"].Value);
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить товар?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        string deleteProductionQuery = "DELETE FROM production WHERE products_id = @id";
                        MySqlCommand deleteProductionCmd = new MySqlCommand(deleteProductionQuery, connection);
                        deleteProductionCmd.Parameters.AddWithValue("@id", productId);
                        deleteProductionCmd.ExecuteNonQuery();

                        string deleteProductQuery = "DELETE FROM products WHERE products_id = @id";
                        MySqlCommand deleteProductCmd = new MySqlCommand(deleteProductQuery, connection);
                        deleteProductCmd.Parameters.AddWithValue("@id", productId);
                        deleteProductCmd.ExecuteNonQuery();

                        MessageBox.Show("Товар и связанные записи успешно удалены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка удаления товара: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            if (!ValidateProductInput()) return;

            try
            {
                var (price,  minQty) = ParseProductValues();
                int supplierId = Convert.ToInt32(ComboSuppliersProduct.SelectedValue); 

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = "INSERT INTO products (products_name, products_price, min_quantity, suppliers_id) " +
                               "VALUES (@name, @price, @min, @supplierId)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", TbNameProducts.Text.Trim());
                cmd.Parameters.AddWithValue("@price", price);

                cmd.Parameters.AddWithValue("@min", minQty);
                cmd.Parameters.AddWithValue("@supplierId", supplierId);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Товар успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления товара: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        private int GetSelectedProductId()
        {
            return Convert.ToInt32(dataGridViewProducts.SelectedRows[0].Cells["products_id"].Value);
        }
        private (decimal price, int minQty) ParseProductValues()
        {
            decimal price = decimal.Parse(TbPriceProduct.Text);
            int minQty = int.Parse(TbMinProduct.Text);
            return (price, minQty);
        }
        private bool ValidateProductInput()
        {
            if (string.IsNullOrWhiteSpace(TbNameProducts.Text) ||
                string.IsNullOrWhiteSpace(TbPriceProduct.Text) ||
                string.IsNullOrWhiteSpace(TbMinProduct.Text))
            {
                MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(TbPriceProduct.Text, out _) ||
                !int.TryParse(TbMinProduct.Text, out _))
            {
                MessageBox.Show("Неверный формат числовых значений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void BtnEditProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateProductInput()) return;

            try
            {
                int productId = GetSelectedProductId();
                (decimal price, int minQty) = ParseProductValues();
                int supplierId = Convert.ToInt32(ComboSuppliersProduct.SelectedValue);

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = "UPDATE products SET products_name=@name, products_price=@price, " +
                               "min_quantity=@min, suppliers_id=@supplierId " +
                               "WHERE products_id=@id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", productId);
                cmd.Parameters.AddWithValue("@name", TbNameProducts.Text.Trim());
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@min", minQty);
                cmd.Parameters.AddWithValue("@supplierId", supplierId);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Товар успешно обновлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка редактирования товара: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void BtnAddSupplier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbNameSupplier.Text) ||
                string.IsNullOrWhiteSpace(TbPhoneSupplier.Text) ||
                string.IsNullOrWhiteSpace(TbAddressSupplier.Text) ||
                ComboContractSupplier.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля, включая выбор контракта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string phone = TbPhoneSupplier.Text.Trim();
            if (phone.Length != 10 || !phone.StartsWith("9") || !phone.All(char.IsDigit))
            {
                MessageBox.Show("Номер телефона должен состоять из 10 цифр и начинаться с цифры 9.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();


                int contractId;
                if (ComboContractSupplier.SelectedValue is DataRowView drv)
                {
                    contractId = Convert.ToInt32(drv["contract_id"]);
                }
                else
                {
                    contractId = Convert.ToInt32(ComboContractSupplier.SelectedValue);
                }

                string query = @"INSERT INTO suppliers 
        (suppliers_name, suppliers_phone, suppliers_address, start_date, end_date, contract) 
        VALUES (@name, @phone, @address, @startDate, @endDate, @contractId)";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", TbNameSupplier.Text);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@address", TbAddressSupplier.Text);
                cmd.Parameters.AddWithValue("@startDate", DtpStartSuppliers.Value);
                cmd.Parameters.AddWithValue("@endDate", DtpEndSuppliers.Value);
                cmd.Parameters.AddWithValue("@contractId", contractId);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Поставщик успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSuppliers();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка добавления поставщика: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void BtnEditSupplier_Click(object sender, EventArgs e)
        {
            if (dataGridViewSuppliers.SelectedRows.Count > 0)
            {
                if (!dataGridViewSuppliers.Columns.Contains("suppliers_id"))
                {
                    MessageBox.Show("Столбец 'suppliers_id' отсутствует в таблице.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int supplierId = Convert.ToInt32(dataGridViewSuppliers.SelectedRows[0].Cells["suppliers_id"].Value);

                if (string.IsNullOrWhiteSpace(TbNameSupplier.Text) ||
                    string.IsNullOrWhiteSpace(TbPhoneSupplier.Text) ||
                    string.IsNullOrWhiteSpace(TbAddressSupplier.Text))
                {
                    MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string phone = TbPhoneSupplier.Text.Trim();
                if (phone.Length != 10 || !phone.StartsWith("9") || !phone.All(char.IsDigit))
                {
                    MessageBox.Show("Номер телефона должен состоять из 10 цифр и начинаться с цифры 9.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    string query = "UPDATE suppliers SET suppliers_name=@name, suppliers_phone=@phone, suppliers_address=@address " +
                                   "WHERE suppliers_id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", supplierId);
                    cmd.Parameters.AddWithValue("@name", TbNameSupplier.Text);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@address", TbAddressSupplier.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Поставщик успешно обновлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSuppliers();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Ошибка редактирования поставщика: " + ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Выберите поставщика для редактирования.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnDeleteSupplier_Click(object sender, EventArgs e)
        {
            if (dataGridViewSuppliers.SelectedRows.Count > 0)
            {
                if (!dataGridViewSuppliers.Columns.Contains("suppliers_id"))
                {
                    MessageBox.Show("Столбец 'suppliers_id' отсутствует в таблице.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int supplierId = Convert.ToInt32(dataGridViewSuppliers.SelectedRows[0].Cells["suppliers_id"].Value);
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить поставщика?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (connection.State == ConnectionState.Closed)
                            connection.Open();


                        string deleteSupplierQuery = "DELETE FROM suppliers WHERE suppliers_id = @id";
                        MySqlCommand deleteSupplierCmd = new MySqlCommand(deleteSupplierQuery, connection);
                        deleteSupplierCmd.Parameters.AddWithValue("@id", supplierId);
                        deleteSupplierCmd.ExecuteNonQuery();

                        MessageBox.Show("Поставщик и связанные записи успешно удалены.", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSuppliers();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Ошибка удаления поставщика: " + ex.Message, "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите поставщика для удаления.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void dataGridViewSuppliers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewSuppliers.SelectedRows.Count == 0) return;

            var row = dataGridViewSuppliers.SelectedRows[0];

            try
            {

                TbNameSupplier.Text = row.Cells["suppliers_name"].Value?.ToString() ?? "";
                TbPhoneSupplier.Text = row.Cells["suppliers_phone"].Value?.ToString() ?? "";
                TbAddressSupplier.Text = row.Cells["suppliers_address"].Value?.ToString() ?? "";

                if (row.Cells["contract_name"].Value != null)
                {
                    string contractName = row.Cells["contract_name"].Value.ToString();
                    foreach (var item in ComboContractSupplier.Items)
                    {
                        if (item is DataRowView drv && drv["contract_name"].ToString() == contractName)
                        {
                            ComboContractSupplier.SelectedItem = item;
                            break;
                        }
                    }
                }

                if (row.Cells["start_date"].Value != null && row.Cells["start_date"].Value != DBNull.Value)
                {
                    DtpStartSuppliers.Value = Convert.ToDateTime(row.Cells["start_date"].Value);
                }
                else
                {
                    DtpStartSuppliers.Value = DateTime.Now;
                }

                if (row.Cells["end_date"].Value != null && row.Cells["end_date"].Value != DBNull.Value)
                {
                    DtpEndSuppliers.Value = Convert.ToDateTime(row.Cells["end_date"].Value);
                }
                else
                {
                    DtpEndSuppliers.Value = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при заполнении данных поставщика: {ex.Message}");
            }
        }




        private void dataGridViewPurchases_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPurchases.SelectedRows.Count == 0) return;

            var row = dataGridViewPurchases.SelectedRows[0];

            try
            {

                


                TbQauntityPurchases.Text = row.Cells["purchases_quantity"].Value?.ToString() ?? "";
                TbPricePurchases.Text = row.Cells["unit_price"].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при заполнении данных закупки: {ex.Message}");
            }
        }


        private void BtnFilterProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.Trim();
                DataTable dt = (DataTable)dataGridViewProducts.DataSource;

                if (dt != null)
                {
                    if (string.IsNullOrEmpty(searchText))
                    {
                        dt.DefaultView.RowFilter = "";
                    }
                    else
                    {
                        dt.DefaultView.RowFilter = $"products_name LIKE '%{searchText}%'";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка фильтрации: {ex.Message}");
            }
        }

        private void dataGridViewProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0) return;

            var row = dataGridViewProducts.SelectedRows[0];

            try
            {
                TbNameProducts.Text = row.Cells["products_name"].Value?.ToString() ?? "";
                TbPriceProduct.Text = row.Cells["products_price"].Value?.ToString() ?? "";
                TbMinProduct.Text = row.Cells["min_quantity"].Value?.ToString() ?? "";

                if (row.Cells["suppliers_name"].Value != null && !string.IsNullOrEmpty(row.Cells["suppliers_name"].Value.ToString()))
                {
                    var supplierName = row.Cells["suppliers_name"].Value.ToString();
                    foreach (var item in ComboSuppliersProduct.Items)
                    {
                        if (item is DataRowView drv && drv["suppliers_name"].ToString() == supplierName)
                        {
                            ComboSuppliersProduct.SelectedItem = item;
                            break;
                        }
                    }
                }
                else
                {
                    ComboSuppliersProduct.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при заполнении данных товара: {ex.Message}");
            }
        }
        private void LoadProductsWithSuppliers()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = @"
            SELECT 
                p.products_id,
                CONCAT(p.products_name, ' (', s.suppliers_name, ')') AS display_name,
                p.min_quantity
            FROM products p
            JOIN suppliers s ON p.suppliers_id = s.suppliers_id";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                ComboProductWithSupplier.DataSource = dt;
                ComboProductWithSupplier.DisplayMember = "display_name";
                ComboProductWithSupplier.ValueMember = "products_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки товаров с поставщиками: {ex.Message}");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void ComboProductPurchases_SelectedIndexChanged(object sender, EventArgs e)
        {


            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                int productId = Convert.ToInt32(ComboProductWithSupplier.SelectedValue);

                string query = @"
            SELECT s.suppliers_id, s.suppliers_name
            FROM suppliers s
            JOIN products p ON s.suppliers_id = p.suppliers_id
            WHERE p.products_id = @productId";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@productId", productId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int supplierId = reader.GetInt32("suppliers_id");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выборе поставщика по товару: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }


        private void BtnCleanSupplier_Click_1(object sender, EventArgs e)
        {
            try
            {
                TbNameSupplier.Clear();
                TbPhoneSupplier.Clear();
                TbAddressSupplier.Clear();
                ComboContractSupplier.SelectedIndex = -1;
                DtpStartSuppliers.Value = DateTime.Today;
                DtpEndSuppliers.Value = DateTime.Today.AddYears(2);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при очистке полей: {ex.Message}");
            }
        }
        private void LoadWriteOffs()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = @"
SELECT 
    w.write_off_id,
    w.products_id,
u.username AS 'Пользователь',
p.products_name AS 'Товар',
    w.quantity AS 'Количество',
    w.reason AS 'Причина',
    w.write_on_date AS 'Дата внесения',
    w.write_off_date AS 'Дата списания',
    w.user_id
FROM write_offs w
JOIN products p ON w.products_id = p.products_id
JOIN users u ON w.user_id = u.users_id
ORDER BY w.write_off_date DESC";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewWriteOffs.DataSource = dt;

                // Скрытие внутренних ID-столбцов
                string[] hiddenColumns = { "write_off_id", "products_id", "user_id" };
                foreach (string col in hiddenColumns)
                {
                    if (dataGridViewWriteOffs.Columns.Contains(col))
                        dataGridViewWriteOffs.Columns[col].Visible = false;
                }

                // Настройка заголовков (если нужно изменить)
                dataGridViewWriteOffs.Columns["Товар"].HeaderText = "Наименование товара";
                dataGridViewWriteOffs.Columns["Пользователь"].HeaderText = "Списал";
                dataGridViewWriteOffs.Columns["Дата списания"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dataGridViewWriteOffs.Columns["Дата внесения"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки списаний: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }


        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            if (comboBoxProducts.SelectedItem == null ||
                string.IsNullOrWhiteSpace(tbQuantity.Text) ||
                string.IsNullOrWhiteSpace(tbReason.Text))
            {
                MessageBox.Show("Заполните все поля: выберите товар, укажите количество и причину.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(tbQuantity.Text.Trim(), out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Количество должно быть положительным числом.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    int productId = Convert.ToInt32(comboBoxProducts.SelectedValue);
                    string reason = tbReason.Text.Trim();
                    DateTime writeOffDate = DateTime.Today;

                    // Проверка доступного количества на складе
                    string checkQuery = "SELECT quantity FROM stock WHERE product_id = @productId;";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection, transaction);
                    checkCmd.Parameters.AddWithValue("@productId", productId);

                    object result = checkCmd.ExecuteScalar();
                    if (result == null || Convert.ToInt32(result) < quantity)
                    {
                        MessageBox.Show("Недостаточное количество на складе для списания.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        transaction.Rollback();
                        return;
                    }

                    // Вставка в таблицу списаний
                    string insertQuery = @"
                INSERT INTO write_offs (products_id, quantity, reason, write_off_date,  user_id)
                VALUES (@productId, @quantity, @reason, @writeOffDate,  @userId);";

                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection, transaction);
                    insertCmd.Parameters.AddWithValue("@productId", productId);
                    insertCmd.Parameters.AddWithValue("@quantity", quantity);
                    insertCmd.Parameters.AddWithValue("@reason", reason);
                    insertCmd.Parameters.AddWithValue("@writeOffDate", writeOffDate);
                    insertCmd.Parameters.AddWithValue("@userId", userId);
                    insertCmd.ExecuteNonQuery();

                    // Обновление количества на складе
                    string updateQuery = "UPDATE stock SET quantity = quantity - @quantity WHERE product_id = @productId;";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection, transaction);
                    updateCmd.Parameters.AddWithValue("@productId", productId);
                    updateCmd.Parameters.AddWithValue("@quantity", quantity);
                    updateCmd.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Списание успешно добавлено.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadWriteOffs();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка добавления списания: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        private void FilterProductsInComboBox(string search)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = @"
            SELECT 
                p.products_id,
                CONCAT(p.products_name, ' (', s.suppliers_name, ')') AS display_name,
                p.min_quantity
            FROM products p
            JOIN suppliers s ON p.suppliers_id = s.suppliers_id
            WHERE LOWER(p.products_name) LIKE @search";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + search.ToLower() + "%");

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                ComboProductWithSupplier.DataSource = dt;
                ComboProductWithSupplier.DisplayMember = "display_name";
                ComboProductWithSupplier.ValueMember = "products_id";

                if (dt.Rows.Count > 0)
                    ComboProductWithSupplier.SelectedIndex = 0;
                else
                    ComboProductWithSupplier.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при фильтрации товаров: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void BtnFilterPurchases_Click(object sender, EventArgs e)
        {
            string searchText = txtSearchPurchases.Text.Trim();
            FilterProductsInComboBox(searchText);
        }
    }
}
