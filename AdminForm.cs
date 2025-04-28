using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Guna.UI2.WinForms;

namespace Kalimov_curs
{
    public partial class AdminForm : Form
    {
        private MySqlConnection connection;
        private int _currentUserId;
        private int _roleId;
        private bool isOverdueMessageShown = false;
        private Size _originalSize;
        private Dictionary<Control, Rectangle> _controlsData = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, Font> _originalFonts = new Dictionary<Control, Font>();

        public AdminForm(int currentUserId, int roleId)
        {
            InitializeComponent();
            _currentUserId = currentUserId;
            _roleId = roleId;

            // Сохраняем оригинальные размеры и шрифты
            _originalSize = this.Size;
            SaveControlDimensions(this);
            this.MinimumSize = new Size(908, 630);
            Database db = new Database(
                "///", /// сервер
                "///", /// название БД
                "///", /// имя пользователя
                "///" /// пароль
            );
            connection = db.GetConnection();

            DtpStartProduction.MinDate = DateTime.Today;
            DtpStartProduction.Value = DateTime.Today;
            DtpEndProduction.MinDate = DateTime.Today.AddDays(30);
            DtpEndProduction.Value = DateTime.Today.AddDays(120);
            DtpStartSuppliers.Value = DateTime.Today;
            DtpEndSuppliers.Value = DateTime.Today.AddYears(2);
            LoadDropdowns();
            LoadPurchases();
            LoadProducts();
            LoadProductionData();
            LoadSuppliers();
            ConfigureTabAccess();

            StyleDataGridView(dataGridViewProducts);
            StyleDataGridView(dataGridViewPurchases);
            StyleDataGridView(dataGridViewProduction);
            StyleDataGridView(dataGridViewSuppliers);

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
            dataGridViewProduction.SelectionChanged += dataGridViewProduction_SelectionChanged;
            ComboSupplierPurchases.SelectedIndexChanged += ComboSupplierPurchases_SelectedIndexChanged;

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
            float scaleX = (float)this.ClientSize.Width / _originalSize.Width;
            float scaleY = (float)this.ClientSize.Height / _originalSize.Height;
            float scale = Math.Min(scaleX, scaleY);

            foreach (Control ctrl in _controlsData.Keys)
            {
                Rectangle original = _controlsData[ctrl];
                ctrl.Left = (int)(original.Left * scaleX);
                ctrl.Top = (int)(original.Top * scaleY);
                ctrl.Width = (int)(original.Width * scaleX);
                ctrl.Height = (int)(original.Height * scaleY);

                if (_originalFonts.ContainsKey(ctrl))
                {
                    float fontSize = _originalFonts[ctrl].Size * scale;
                    ctrl.Font = new Font(_originalFonts[ctrl].FontFamily, fontSize, _originalFonts[ctrl].Style);
                }
            }
        }

        private void ConfigureTabAccess()
        {

            var tabAccess = new Dictionary<string, bool>
    {
        {"Production", _roleId == 1 || _roleId == 3}, 
        {"Product", _roleId == 1 || _roleId == 2},    
        {"Purchases", _roleId == 1 || _roleId == 2},  
        {"Supplier", _roleId == 1 || _roleId == 2}    
    };

            List<TabPage> allTabs = new List<TabPage>
    {
        Production,
        Product,
        Purchases,
        Supplier
    };

            guna2TabControl1.TabPages.Clear();

            foreach (var tab in allTabs)
            {
                if (tabAccess.TryGetValue(tab.Name, out bool allowed) && allowed)
                {
                    guna2TabControl1.TabPages.Add(tab);
                }
            }

            if (guna2TabControl1.TabPages.Count > 0)
            {
                guna2TabControl1.SelectedTab = guna2TabControl1.TabPages[0];
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
            LoadComboBox("SELECT suppliers_id, suppliers_name FROM suppliers", ComboSupplierPurchases);
            LoadComboBox("SELECT suppliers_id, suppliers_name FROM suppliers", ComboSuppliersProduct);
            LoadComboBox("SELECT products_id, products_name FROM products", comboProductProduction);
            LoadComboBox("SELECT products_id, products_name FROM products", ComboProductPurchases);
            LoadComboBox("SELECT contract_id, contract_name FROM contracts", ComboContractPurchases);
            LoadComboBox("SELECT contract_id, contract_name FROM contracts", ComboContractSupplier);
            LoadComboBox("SELECT production_stage_id, production_stage_name FROM production_stage", comboStageProduction);
            LoadComboBox("SELECT status_production_id, status_production_name FROM status_production", comboStatusProduction);

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
        c.contract_name AS contract_name,
        pr.products_name AS product_name,
        p.purchases_quantity, 
        p.unit_price,
        p.purchases_total_price, 
        p.purchases_date
    FROM purchases p
    LEFT JOIN users u ON p.purchases_user_id = u.users_id
    LEFT JOIN suppliers s ON p.suppliers_id = s.suppliers_id
    LEFT JOIN contracts c ON p.contract_id = c.contract_id
    LEFT JOIN products pr ON p.products_id = pr.products_id
    ORDER BY p.purchases_id DESC
";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewPurchases.DataSource = dt.Rows.Count > 0 ? dt : null;

                if (dt.Rows.Count > 0)
                {
                    if (dataGridViewPurchases.Columns.Contains("ID"))
                    {
                        dataGridViewPurchases.Columns["ID"].Visible = false;
                    }
                    if (dataGridViewPurchases.Columns.Contains("user_name"))
                        dataGridViewPurchases.Columns["user_name"].HeaderText = "Пользователь";
                    if (dataGridViewPurchases.Columns.Contains("supplier_id"))
                        dataGridViewPurchases.Columns["supplier_id"].HeaderText = "Поставщик";
                    if (dataGridViewPurchases.Columns.Contains("contract_name"))
                        dataGridViewPurchases.Columns["contract_name"].HeaderText = "Контракт";
                    if (dataGridViewPurchases.Columns.Contains("product_name"))
                        dataGridViewPurchases.Columns["product_name"].HeaderText = "Товар";
                    if (dataGridViewPurchases.Columns.Contains("purchases_quantity"))
                        dataGridViewPurchases.Columns["purchases_quantity"].HeaderText = "Количество";
                    if (dataGridViewPurchases.Columns.Contains("unit_price"))
                        dataGridViewPurchases.Columns["unit_price"].HeaderText = "Цена за единицу";
                    if (dataGridViewPurchases.Columns.Contains("purchases_total_price"))
                        dataGridViewPurchases.Columns["purchases_total_price"].HeaderText = "Общая стоимость";
                    if (dataGridViewPurchases.Columns.Contains("purchases_date"))
                        dataGridViewPurchases.Columns["purchases_date"].HeaderText = "Дата закупки";
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

        private void LoadProducts()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = "SELECT p.products_id, p.products_name, p.products_price, p.products_quantity, " +
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
                dataGridViewProducts.Columns["products_quantity"].HeaderText = "Количество";
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

        private void LoadProductionData()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = @"
            SELECT
                pr.production_id,
                pr.products_id,
                pr.stage,
                pr.status,
                pr.start_date AS 'Начало',
                pr.plan_date AS 'Плановая дата окончания',
                pr.fact_date AS 'Фактическая дата окончания',
                p.products_name AS 'Товар',
                ps.production_stage_name AS 'Этап',
                sp.status_production_name AS 'Статус'
            FROM production pr
            JOIN products p ON pr.products_id = p.products_id
            JOIN production_stage ps ON pr.stage = ps.production_stage_id
            JOIN status_production sp ON pr.status = sp.status_production_id
            ORDER BY
                CASE 
                    WHEN pr.plan_date < NOW() 
                         AND sp.status_production_name <> 'Завершено'
                         AND pr.fact_date IS NULL 
                    THEN 0 
                    ELSE 1 
                END,
                pr.production_id DESC";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewProduction.DataSource = dt;

                string[] hiddenColumns = { "production_id", "products_id", "stage", "status" };
                foreach (string col in hiddenColumns)
                {
                    if (dataGridViewProduction.Columns.Contains(col))
                        dataGridViewProduction.Columns[col].Visible = false;
                }

                dataGridViewProduction.Columns["Товар"].HeaderText = "Товар";
                dataGridViewProduction.Columns["Этап"].HeaderText = "Этап";
                dataGridViewProduction.Columns["Начало"].HeaderText = "Начало";
                dataGridViewProduction.Columns["Плановая дата окончания"].HeaderText = "Плановая дата окончания";
                dataGridViewProduction.Columns["Фактическая дата окончания"].HeaderText = "Фактическая дата окончания";
                dataGridViewProduction.Columns["Статус"].HeaderText = "Статус";

                int delayedCount = 0;
                foreach (DataGridViewRow row in dataGridViewProduction.Rows)
                {
                    if (row.Cells["Плановая дата окончания"].Value == null || row.Cells["Плановая дата окончания"].Value == DBNull.Value)
                        continue;

                    if (!DateTime.TryParse(row.Cells["Плановая дата окончания"].Value.ToString(), out DateTime planDate))
                        continue;

                    bool isFactDateNull = row.Cells["Фактическая дата окончания"].Value == null || row.Cells["Фактическая дата окончания"].Value == DBNull.Value;
                    string status = row.Cells["Статус"].Value?.ToString();

                    if (planDate < DateTime.Now && status != "Завершено" && isFactDateNull)
                    {
                        row.DefaultCellStyle.BackColor = Color.RosyBrown;
                        delayedCount++;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.Empty;
                    }
                }

                if (!isOverdueMessageShown && delayedCount > 0)
                {
                    lblDedline.Text = $"Просрочено этапов: {delayedCount}";
                    isOverdueMessageShown = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            comboProductProduction.SelectedIndex = -1;
            comboStageProduction.SelectedIndex = -1;
            comboStatusProduction.SelectedIndex = -1;
            DtpStartProduction.Value = DateTime.Today;
            DtpEndProduction.Value = DateTime.Today.AddDays(120);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduction.SelectedRows.Count > 0)
            {
                int productionId = Convert.ToInt32(
                    dataGridViewProduction.SelectedRows[0].Cells["production_id"].Value);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    if (DtpEndProduction.Value.Date < DateTime.Today)
                    {
                        MessageBox.Show("Плановая дата должна быть в будущем!");
                        return;
                    }

                    string query = @"UPDATE production
                             SET products_id = @prod,
                                 stage       = @stage,
                                 start_date  = @start,
                                 plan_date   = @plan,
                                 fact_date   = @fact,
                                 status      = @status
                             WHERE production_id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", productionId);
                        cmd.Parameters.AddWithValue("@prod", comboProductProduction.SelectedValue);
                        cmd.Parameters.AddWithValue("@stage", comboStageProduction.SelectedValue);
                        cmd.Parameters.AddWithValue("@start", DtpStartProduction.Value);
                        cmd.Parameters.AddWithValue("@plan", DtpEndProduction.Value);

                        if (comboStatusProduction.Text == "Завершено")
                        {
                            cmd.Parameters.AddWithValue("@fact", DateTime.Now);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@fact", DBNull.Value);
                        }

                        cmd.Parameters.AddWithValue("@status", comboStatusProduction.SelectedValue);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Запись успешно обновлена.", "Успех",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadProductionData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка редактирования записи: " + ex.Message,
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для редактирования.", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduction.SelectedRows.Count > 0)
            {
                int productionId = Convert.ToInt32(dataGridViewProduction.SelectedRows[0].Cells["production_id"].Value);
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        string query = "DELETE FROM production WHERE production_id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@id", productionId);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Запись успешно удалена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadProductionData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка удаления записи: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Выберите запись для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                if (DtpEndProduction.Value.Date < DateTime.Today)
                {
                    MessageBox.Show("Плановая дата должна быть в будущем!");
                    return;
                }

                string query = @"INSERT INTO production 
                            (products_id, stage, start_date, plan_date, fact_date, status) 
                         VALUES 
                            (@prodId, @stage, @start, @plan, @fact, @status)";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@prodId", comboProductProduction.SelectedValue);
                    cmd.Parameters.AddWithValue("@stage", comboStageProduction.SelectedValue);
                    cmd.Parameters.AddWithValue("@start", DtpStartProduction.Value);
                    cmd.Parameters.AddWithValue("@plan", DtpEndProduction.Value);


                    if (comboStatusProduction.Text == "Завершено")
                    {
                        cmd.Parameters.AddWithValue("@fact", DateTime.Now);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@fact", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@status", comboStatusProduction.SelectedValue);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Запись успешно добавлена.", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadProductionData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления записи: " + ex.Message,
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                TbQuantityProduct.Clear();
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
            if (ComboSupplierPurchases.SelectedValue == null || comboProductProduction.SelectedValue == null ||
               ComboContractPurchases.SelectedValue == null)
            {
                MessageBox.Show("Заполните все обязательные поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(TbQauntityPurchases.Text, out decimal quantity) ||
                !decimal.TryParse(TbPricePurchases.Text, out decimal unitPrice))
            {
                MessageBox.Show("Проверьте числовые поля (кол-во, цена)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            decimal totalPrice = quantity * unitPrice;

            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();

                connection.Open();
                string query = @"
                    INSERT INTO purchases 
                        (suppliers_id, products_id, purchases_user_id, purchases_quantity, 
                         purchases_date, purchases_total_price, contract_id, unit_price) 
                    VALUES 
                        (@sup, @prod, @user, @qty, @date, @price, @contract, @unit)
                ";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@sup", ComboSupplierPurchases.SelectedValue);
                cmd.Parameters.AddWithValue("@prod", comboProductProduction.SelectedValue);
                cmd.Parameters.AddWithValue("@user", _currentUserId);
                cmd.Parameters.AddWithValue("@contract", ComboContractPurchases.SelectedValue);
                cmd.Parameters.AddWithValue("@qty", quantity);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@price", totalPrice);
                cmd.Parameters.AddWithValue("@unit", unitPrice);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Закупка успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPurchases(); 
                }
                else
                {
                    MessageBox.Show("Не удалось добавить закупку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Ошибка добавления: {ex.Message}\nКод ошибки: {ex.Number}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void BtnEditPurcahses_Click(object sender, EventArgs e)
        {

            int? purchaseId = GetSelectedId(dataGridViewPurchases, "ID", "Выберите закупку для редактирования.");
            if (purchaseId == null) return;

            if (!decimal.TryParse(TbQauntityPurchases.Text, out decimal quantity) ||
                !decimal.TryParse(TbPricePurchases.Text, out decimal unitPrice))
            {
                MessageBox.Show("Проверьте числовые поля (кол-во, цена)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalPrice = quantity * unitPrice;

            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();

                connection.Open();

                string query = @"UPDATE purchases 
        SET 
            suppliers_id          = @sup, 
            products_id           = @prod, 
            purchases_user_id     = @user, 
            purchases_quantity    = @qty, 
            purchases_date        = @date, 
            purchases_total_price = @price, 
            contract_id           = @contract, 
            unit_price            = @unit 
        WHERE 
            purchases_id          = @id";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", purchaseId);
                cmd.Parameters.AddWithValue("@sup", ComboSupplierPurchases.SelectedValue);
                cmd.Parameters.AddWithValue("@prod", ComboProductPurchases.SelectedValue);
                cmd.Parameters.AddWithValue("@user", _currentUserId);
                cmd.Parameters.AddWithValue("@contract", ComboContractPurchases.SelectedValue);
                cmd.Parameters.AddWithValue("@qty", quantity);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@price", totalPrice);
                cmd.Parameters.AddWithValue("@unit", unitPrice);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Закупка успешно обновлена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPurchases();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка редактирования закупки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }


        private void BtnDeletePurchases_Click(object sender, EventArgs e)
        {

            int? purchaseId = GetSelectedId(dataGridViewPurchases, "ID", "Выберите закупку для удаления.");
            if (purchaseId == null) return;

            if (MessageBox.Show("Вы уверены, что хотите удалить эту закупку?",
                                "Подтверждение",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();

                connection.Open();

                string query = "DELETE FROM purchases WHERE purchases_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", purchaseId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Закупка успешно удалена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPurchases();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }


        private void BtnCleanPurchases_Click(object sender, EventArgs e)
        {

            ComboSupplierPurchases.SelectedIndex = -1;
            ComboProductPurchases.SelectedIndex = -1;
            ComboContractPurchases.SelectedIndex = -1;
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
                var (price, quantity, minQty) = ParseProductValues();
                int supplierId = Convert.ToInt32(ComboSuppliersProduct.SelectedValue); // предполагается, что comboBoxSuppliers содержит список поставщиков

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = "INSERT INTO products (products_name, products_price, products_quantity, min_quantity, suppliers_id) " +
                               "VALUES (@name, @price, @quantity, @min, @supplierId)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", TbNameProducts.Text.Trim());
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@quantity", quantity);
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
        private (decimal price, int quantity, int minQty) ParseProductValues()
        {
            decimal price = decimal.Parse(TbPriceProduct.Text);
            int quantity = int.Parse(TbQuantityProduct.Text);
            int minQty = int.Parse(TbMinProduct.Text);
            return (price, quantity, minQty);
        }
        private bool ValidateProductInput()
        {
            if (string.IsNullOrWhiteSpace(TbNameProducts.Text) ||
                string.IsNullOrWhiteSpace(TbPriceProduct.Text) ||
                string.IsNullOrWhiteSpace(TbQuantityProduct.Text) ||
                string.IsNullOrWhiteSpace(TbMinProduct.Text))
            {
                MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(TbPriceProduct.Text, out _) ||
                !int.TryParse(TbQuantityProduct.Text, out _) ||
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
                (decimal price, int quantity, int minQty) = ParseProductValues();
                int supplierId = Convert.ToInt32(ComboSuppliersProduct.SelectedValue);

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = "UPDATE products SET products_name=@name, products_price=@price, " +
                               "products_quantity=@quantity, min_quantity=@min, suppliers_id=@supplierId " +
                               "WHERE products_id=@id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", productId);
                cmd.Parameters.AddWithValue("@name", TbNameProducts.Text.Trim());
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@quantity", quantity);
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

        private void BtnCleanSupplier_Click(object sender, EventArgs e)
        {
            ComboContractPurchases.SelectedIndex = -1;
            ComboProductPurchases.SelectedIndex = -1;
            TbAddressSupplier.Clear();
            TbPhoneSupplier.Clear();
            TbNameSupplier.Clear();
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


        private void dataGridViewProduction_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProduction.SelectedRows.Count == 0) return;

            var row = dataGridViewProduction.SelectedRows[0];

            try
            {

                if (row.Cells["products_id"].Value != null)
                {
                    comboProductProduction.SelectedValue = row.Cells["products_id"].Value;
                }

                if (row.Cells["stage"].Value != null)
                {
                    comboStageProduction.SelectedValue = row.Cells["stage"].Value;
                }

                if (row.Cells["status"].Value != null)
                {
                    comboStatusProduction.SelectedValue = row.Cells["status"].Value;
                }


                if (row.Cells["Начало"].Value != null && row.Cells["Начало"].Value != DBNull.Value)
                {
                    DtpStartProduction.Value = Convert.ToDateTime(row.Cells["Начало"].Value);
                }

                if (row.Cells["Плановая дата окончания"].Value != null && row.Cells["Плановая дата окончания"].Value != DBNull.Value)
                {
                    DtpEndProduction.Value = Convert.ToDateTime(row.Cells["Плановая дата окончания"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при заполнении данных производства: {ex.Message}");
            }
        }

        private void dataGridViewPurchases_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPurchases.SelectedRows.Count == 0) return;

            var row = dataGridViewPurchases.SelectedRows[0];

            try
            {
                if (row.Cells["supplier_id"].Value != null && !string.IsNullOrEmpty(row.Cells["supplier_id"].Value.ToString()))
                {
                    string supplierName = row.Cells["supplier_id"].Value.ToString();
                    foreach (var item in ComboSupplierPurchases.Items)
                    {
                        if (item is DataRowView drv && drv["suppliers_name"].ToString() == supplierName)

                        {
                            ComboSupplierPurchases.SelectedItem = item;
                            break;
                        }
                    }
                }
                else
                {
                    ComboSupplierPurchases.SelectedIndex = -1;
                }

                if (row.Cells["product_name"].Value != null)
                {

                    string productName = row.Cells["product_name"].Value.ToString();
                    foreach (var item in ComboProductPurchases.Items)
                    {
                        if (item is DataRowView drv && drv["products_name"].ToString() == productName)
                        {
                            ComboProductPurchases.SelectedItem = item;
                            break;
                        }
                    }
                }

                if (row.Cells["contract_name"].Value != null)
                {
                    string contractName = row.Cells["contract_name"].Value.ToString();
                    foreach (var item in ComboContractPurchases.Items)
                    {
                        if (item is DataRowView drv && drv["contract_name"].ToString() == contractName)
                        {
                            ComboContractPurchases.SelectedItem = item;
                            break;
                        }
                    }
                }

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
                TbQuantityProduct.Text = row.Cells["products_quantity"].Value?.ToString() ?? "";
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
        private void ComboSupplierPurchases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboSupplierPurchases.SelectedValue == null || ComboSupplierPurchases.SelectedIndex == -1)
            {
                ComboProductPurchases.DataSource = null;
                return;
            }

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                int supplierId = Convert.ToInt32(ComboSupplierPurchases.SelectedValue);

                string query = "SELECT products_id, products_name FROM products WHERE suppliers_id = @supplierId";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@supplierId", supplierId);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                ComboProductPurchases.DataSource = dt;
                ComboProductPurchases.DisplayMember = "products_name";
                ComboProductPurchases.ValueMember = "products_id";

                ComboProductPurchases.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки товаров поставщика: {ex.Message}");
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
    }
}
