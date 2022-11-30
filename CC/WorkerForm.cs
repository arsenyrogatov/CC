using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC
{
    public partial class WorkerForm : Form
    {
        public WorkerForm()
        {
            InitializeComponent();
            UpdateCurrentWorker();
            ewBirth_dateTimePicker.MaxDate = DateTime.Now.AddYears(-18);
            matEd_comboBox.SelectedIndex = 0;

            if (CurrentWorker.Job == "Менеджер по продажам") //salesman
            {
                tabControl1.TabPages.Remove(Workers_tabPage);
                tabControl1.TabPages.Remove(clients_tabPage);
                tabControl1.TabPages.Remove(Supplier_tabPage);
                tabControl1.TabPages.Remove(brigade_tabPage);
                tabControl1.TabPages.Remove(work_tabPage);
                tabControl1.TabPages.Remove(matCon_tabPage);
                worker_pictureBox.Image = Properties.Resources.salesman;
            }
            else if (CurrentWorker.Job == "Аритектор") //architect
            {
                tabControl1.TabPages.Remove(Workers_tabPage);
                tabControl1.TabPages.Remove(Materials_tabPage);
                tabControl1.TabPages.Remove(clients_tabPage);
                tabControl1.TabPages.Remove(Supplier_tabPage);
                tabControl1.TabPages.Remove(brigade_tabPage);
                tabControl1.TabPages.Remove(work_tabPage);
                tabControl1.TabPages.Remove(matCon_tabPage);
                worker_pictureBox.Image = Properties.Resources.architect;
            }
            else if (CurrentWorker.Job == "Главный инженер") //engineer
            {
                tabControl1.TabPages.Remove(Workers_tabPage);
                tabControl1.TabPages.Remove(Supplier_tabPage);
                worker_pictureBox.Image = Properties.Resources.engineer;
            }
            else if (CurrentWorker.Job == "Генеральный директор") //director
            {
                tabControl1.TabPages.Remove(Materials_tabPage);
                tabControl1.TabPages.Remove(Supplier_tabPage);
                tabControl1.TabPages.Remove(brigade_tabPage);
                tabControl1.TabPages.Remove(work_tabPage);
                worker_pictureBox.Image = Properties.Resources.director;
            }
            else if (CurrentWorker.Job == "Главный бухгалтер")
            {
                tabControl1.TabPages.Remove(Workers_tabPage);
                tabControl1.TabPages.Remove(Materials_tabPage);
                tabControl1.TabPages.Remove(Supplier_tabPage);
                tabControl1.TabPages.Remove(brigade_tabPage);
                tabControl1.TabPages.Remove(work_tabPage);
                worker_pictureBox.Image = Properties.Resources.accountant;
            }
            else
            {
                tabControl1.Visible = false;
                Size = new Size(286, 726);
                //1344; 726
            }

        }

            Worker worker;
        Client client;
        Material material;
        Supplier supplier;
        Brigade brigade;
        Project project;
        Work work;
        CompletedWork workCompleted;
        MatCon matCon;

        private void UpdateCurrentWorker()
        {
            FIO_label.Text = CurrentWorker.Name;
            Id_label.Text = CurrentWorker.Id.ToString();
            Passport_label.Text = CurrentWorker.Passport;
            Birth_label.Text = CurrentWorker.Birth.ToString("d");
            Gender_label.Text = CurrentWorker.Gen == 'м' ? "Мужской" : "Женский";
            Job_label.Text = CurrentWorker.Job;
            Stage_label.Text = CurrentWorker.Stage.ToString();
            Phone_label.Text = CurrentWorker.Phone;
            Mail_label.Text = CurrentWorker.Mail;
        }

        private void UpdateWorkers()
        {
            workers_dataGridView.DataSource = Workers.GetAll();
        }

        private void UpdateClients()
        {
            clients_dataGridView.DataSource = Clients.GetAll();
        }

        private void UpdateMaterials()
        {
            var materials = Materials.GetAll();
            materials_dataGridView.DataSource = materials;
            deliveries_dataGridView.DataSource = Deliveries.GetAll();
            var suppliers = Suppliers.GetAll();
            delMat_comboBox.Items.Clear();
            for (int i = 0; i < materials.Rows.Count; i++)
            {
                delMat_comboBox.Items.Add($"({materials.Rows[i][0].ToString()}) {materials.Rows[i][1].ToString()}");
            }
            delSup_comboBox.Items.Clear();
            for (int i = 0; i < suppliers.Rows.Count; i++)
            {
                delSup_comboBox.Items.Add($"({suppliers.Rows[i][0].ToString()}) {suppliers.Rows[i][1].ToString()}, {suppliers.Rows[i][2].ToString()}");
            }
            delMat_comboBox.SelectedIndex = 0;
            delSup_comboBox.SelectedIndex = 0;
        }

        private void UpdateSuppliers()
        {
            suppliers_dataGridView.DataSource = Suppliers.GetAll();
        }

        private void UpdateBrigade()
        {
            brigade_dataGridView.DataSource = Brigades.GetAll();
            brWorker_comboBox.Items.Clear();
            var workers = Workers.GetAll();
            for (int i = 0; i < workers.Rows.Count; i++)
            {
                brWorker_comboBox.Items.Add($"({workers.Rows[i][0].ToString()}) {workers.Rows[i][1].ToString()}");
            }
        }

        private void UpdateWork()
        {
            var works = Works.GetAll();
            work_dataGridView.DataSource = works;
            cmpWork_dataGridView.DataSource = CompletedWorks.GetAll();

            cWr_comboBox.Items.Clear();
            for (int i = 0; i < works.Rows.Count; i++)
            {
                cWr_comboBox.Items.Add($"({works.Rows[i][0].ToString()}) {works.Rows[i][4].ToString()}");
            }

            cPr_comboBox.Items.Clear();
            var projects = Projects.GetAll();
            for (int i = 0; i < projects.Rows.Count; i++)
            {
                cPr_comboBox.Items.Add($"({projects.Rows[i][0].ToString()}) {projects.Rows[i][5].ToString()}");
            }

            wrBr_comboBox.Items.Clear();
            var brigades = Brigades.GetAll();
            for (int i = 0; i < brigades.Rows.Count; i++)
            {
                wrBr_comboBox.Items.Add($"({brigades.Rows[i][0].ToString()}) {brigades.Rows[i][1].ToString()}");
            }
        }

        private void UpdateProject()
        {
            projects_dataGridView.DataSource = Projects.GetAll();
            projects_dataGridView.Columns[1].Visible = false;
            projects_dataGridView.Columns[2].Visible = false;

            prWorker_comboBox.Items.Clear();
            var workers = Workers.GetAll();
            for (int i = 0; i < workers.Rows.Count; i++)
            {
                prWorker_comboBox.Items.Add($"({workers.Rows[i][0].ToString()}) {workers.Rows[i][1].ToString()}");
            }

            prClient_comboBox.Items.Clear();
            var clients = Clients.GetAll();
            for (int i = 0; i < clients.Rows.Count; i++)
            {
                prClient_comboBox.Items.Add($"({clients.Rows[i][0].ToString()}) {clients.Rows[i][1].ToString()}");
            }
        }

        private void UpdateMatCon()
        {
            Rash_dataGridView.DataSource = MatCons.GetAll();

            var works = Works.GetAll();

            RashWork_comboBox.Items.Clear();
            for (int i = 0; i < works.Rows.Count; i++)
            {
                RashWork_comboBox.Items.Add($"({works.Rows[i][0].ToString()}) {works.Rows[i][4].ToString()}");
            }

            var materials = Materials.GetAll();
            RashMat_comboBox.Items.Clear();
            for (int i = 0; i < materials.Rows.Count; i++)
            {
                RashMat_comboBox.Items.Add($"({materials.Rows[i][0].ToString()}) {materials.Rows[i][1].ToString()}");
            }
        }

        private void workerFind_button_Click(object sender, EventArgs e)
        {
            UpdateWorkers();
            ((DataTable)workers_dataGridView.DataSource).DefaultView.RowFilter = $"[ФИО] LIKE '%{workerFind_textBox.Text}%' OR [Должность] LIKE '%{workerFind_textBox.Text}%'";
        }

        private void Workers_tabPage_Enter(object sender, EventArgs e)
        {
            UpdateWorkers();
        }

        private void clients_tabPage_Enter(object sender, EventArgs e)
        {
            UpdateClients();
        }

        private void Materials_tabPage_Enter(object sender, EventArgs e)
        {
            UpdateMaterials();
        }

        private void Supplier_tabPage_Enter(object sender, EventArgs e)
        {
            UpdateSuppliers();
        }

        private void brigade_tabPage_Enter(object sender, EventArgs e)
        {
            UpdateBrigade();
        }

        private void brigade_dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (brigade_dataGridView.Rows.Count > 0)
            {
                brWorkers_dataGridView.DataSource = Workers.GetByBrigadeId(int.Parse(brigade_dataGridView.CurrentRow.Cells[0].Value.ToString()));

                brigade = new Brigade(int.Parse(brigade_dataGridView.CurrentRow.Cells[0].Value.ToString()),
                    brigade_dataGridView.CurrentRow.Cells[1].Value.ToString());

                brigId_label.Text = brigade.Id.ToString();
                brigName_textBox.Text = brigade.Name;

            }
        }

        private void projects_tabPage_Enter(object sender, EventArgs e)
        {
            UpdateProject();
        }

        private void workers_dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (workers_dataGridView.Rows.Count > 0)
            {
                worker = new Worker(int.Parse(workers_dataGridView.CurrentRow.Cells[0].Value.ToString()),
                    workers_dataGridView.CurrentRow.Cells[1].Value.ToString(),
                    int.Parse(workers_dataGridView.CurrentRow.Cells[2].Value.ToString()),
                    int.Parse(workers_dataGridView.CurrentRow.Cells[3].Value.ToString()),
                    DateTime.Parse(workers_dataGridView.CurrentRow.Cells[4].Value.ToString()),
                    char.Parse(workers_dataGridView.CurrentRow.Cells[5].Value.ToString()),
                    workers_dataGridView.CurrentRow.Cells[6].Value.ToString(),
                    int.Parse(workers_dataGridView.CurrentRow.Cells[7].Value.ToString()),
                    workers_dataGridView.CurrentRow.Cells[8].Value.ToString(),
                    workers_dataGridView.CurrentRow.Cells[9].Value.ToString());
                ewId_label.Text = worker.Id.ToString();
                ewFio_textBox.Text = worker.Name;
                ewPas1_maskedTextBox.Text = worker.PasSeries.ToString();
                ewPas2_maskedTextBox.Text = worker.PasNum.ToString();
                ewBirth_dateTimePicker.Value = worker.Birth;
                ewFem_radioButton.Checked = worker.Gen == 'ж' ? true : false;
                ewMale_radioButton.Checked = worker.Gen == 'м' ? true : false;
                ewJob_textBox.Text = worker.Job;
                ewStage_numericUpDown.Value = worker.Stage;
                ewPhone_maskedTextBox.Text = worker.Phone;
                ewMail_textBox.Text = worker.Mail;
            }
        }

        private void updateWorker_button_Click(object sender, EventArgs e)
        {
            if (ewFio_textBox.Text.Length > 0 && ewPas1_maskedTextBox.MaskCompleted
                && ewPas2_maskedTextBox.MaskCompleted && ewJob_textBox.Text.Length > 0
                && ewPhone_maskedTextBox.MaskCompleted && ewMail_textBox.Text.Length > 0)
            {
                worker.Name = ewFio_textBox.Text;
                worker.PasSeries = int.Parse(ewPas1_maskedTextBox.Text);
                worker.PasNum = int.Parse(ewPas2_maskedTextBox.Text);
                worker.Birth = ewBirth_dateTimePicker.Value;
                worker.Gen = ewFem_radioButton.Checked ? 'ж' : 'м';
                worker.Job = ewJob_textBox.Text;
                worker.Stage = ((int)ewStage_numericUpDown.Value);
                worker.Phone = ewPhone_maskedTextBox.Text;
                worker.Mail = ewMail_textBox.Text;
                if (worker.Update())
                {
                    MessageBox.Show("Данные обновлены!");
                    UpdateWorkers();
                }
                else
                {
                    MessageBox.Show("Такие данные уже существуют!");
                }
            }

            else
            {
                MessageBox.Show("Проверьте введенные данные!");
            }
        }

        private void deleteWorker_button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Отменить действие будет невозможно! Продолжить?","Внимание",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                worker.Delete();
                MessageBox.Show("Сотрудник удален!");
                UpdateWorkers();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Workers.Add();
            MessageBox.Show("Сотрудник добавлен!");
            UpdateWorkers();
        }

        private void clients_dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (clients_dataGridView.SelectedRows.Count > 0)
            {
                client = new Client(int.Parse(clients_dataGridView.CurrentRow.Cells[0].Value.ToString()),
                   clients_dataGridView.CurrentRow.Cells[1].Value.ToString(),
                   int.Parse(clients_dataGridView.CurrentRow.Cells[2].Value.ToString()),
                   int.Parse(clients_dataGridView.CurrentRow.Cells[3].Value.ToString()),
                   DateTime.Parse(clients_dataGridView.CurrentRow.Cells[4].Value.ToString()),
                   char.Parse(clients_dataGridView.CurrentRow.Cells[5].Value.ToString()),
                   clients_dataGridView.CurrentRow.Cells[6].Value.ToString(),
                   clients_dataGridView.CurrentRow.Cells[7].Value.ToString());
                ecId_label.Text = client.Id.ToString();
                ecFio_textBox.Text = client.Name;
                ecPas1_maskedTextBox.Text = client.PasSeries.ToString();
                ecPas2_maskedTextBox.Text = client.PasNum.ToString();
                ecBirth_dateTimePicker.Value = client.Birth;
                ecFem_radioButton.Checked = client.Gen == 'ж' ? true : false;
                ecMale_radioButton.Checked = client.Gen == 'м' ? true : false;
                ecPhone_maskedTextBox.Text = client.Phone;
                ecMail_textBox.Text = client.Mail;
            }
        }

        private void updateClient_button_Click(object sender, EventArgs e)
        {
            if (ecFio_textBox.Text.Length > 0 && ecPas1_maskedTextBox.MaskCompleted
                && ecPas2_maskedTextBox.MaskCompleted
                && ecPhone_maskedTextBox.MaskCompleted && ecMail_textBox.Text.Length > 0)
            {
                client.Name = ecFio_textBox.Text;
                client.PasSeries = int.Parse(ecPas1_maskedTextBox.Text);
                client.PasNum = int.Parse(ecPas2_maskedTextBox.Text);
                client.Birth = ecBirth_dateTimePicker.Value;
                client.Gen = ecFem_radioButton.Checked ? 'ж' : 'м';
                client.Phone = ecPhone_maskedTextBox.Text;
                client.Mail = ecMail_textBox.Text;
                if (client.Update())
                {
                    MessageBox.Show("Данные обновлены!");
                    UpdateClients();
                }
                else
                {
                    MessageBox.Show("Такие данные уже существуют!");
                }
            }
        }

        private void deleteClient_button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Отменить действие будет невозможно! Продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                client.Delete();
                MessageBox.Show("Заказчик удален!");
                UpdateClients();
            }
        }

        private void addClient_button_Click(object sender, EventArgs e)
        {
            Clients.Add();
            MessageBox.Show("Заказчик добавлен!");
            UpdateClients();
        }

        private void matUpdate_button_Click(object sender, EventArgs e)
        {
            if (matName_textBox.Text.Length > 0)
            {
                material.Name = matName_textBox.Text;
                material.Ed = matEd_comboBox.Text;
                material.Price = matPrice_numericUpDown.Value;

                material.Update();
                    MessageBox.Show("Данные обновлены!");
                    UpdateMaterials();

            }
        }

        private void materials_dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (materials_dataGridView.SelectedRows.Count > 0)
            {
                material = new Material(int.Parse(materials_dataGridView.CurrentRow.Cells[0].Value.ToString()),
                   materials_dataGridView.CurrentRow.Cells[1].Value.ToString(),
                   materials_dataGridView.CurrentRow.Cells[2].Value.ToString(),
                   decimal.Parse(materials_dataGridView.CurrentRow.Cells[4].Value.ToString()),
                   int.Parse(materials_dataGridView.CurrentRow.Cells[3].Value.ToString()));

                matId_label.Text = material.Id.ToString();
                matName_textBox.Text = material.Name;
                matEd_comboBox.Text = material.Ed;
                matPrice_numericUpDown.Value = material.Price;
                matCount_label.Text = material.Count.ToString();
               
            }
        }

        private void matDelete_button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Отменить действие будет невозможно! Продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                material.Delete();
                MessageBox.Show("Материал удален!");
                UpdateMaterials();
            }
        }

        private void matAdd_button_Click(object sender, EventArgs e)
        {
            Materials.Add();
            MessageBox.Show("Материал добавлен!");
            UpdateMaterials();
        }

        private void delAdd_button_Click(object sender, EventArgs e)
        {
            var supId = int.Parse(delSup_comboBox.Text.Substring(1).Split(new char[] { ')' })[0]);
            var matId = int.Parse(delMat_comboBox.Text.Substring(1).Split(new char[] { ')' })[0]);
            Deliveries.Add(supId, matId, ((int)delCount_numericUpDown.Value));
            MessageBox.Show("Поставка добавлена!");
            UpdateMaterials();
        }

        private void supUpdate_button_Click(object sender, EventArgs e)
        {
            if (supName_textBox.Text.Length >0 && supComp_textBox.Text.Length > 0 &&
                supAddr_textBox.Text.Length > 0 && supPhone_maskedTextBox.MaskCompleted &&
                supMail_textBox.Text.Length > 0)
            {
                supplier.Name = supName_textBox.Text;
                supplier.Company = supComp_textBox.Text;
                supplier.Address = supAddr_textBox.Text;
                supplier.Phone = supPhone_maskedTextBox.Text;
                supplier.Mail = supMail_textBox.Text;

                supplier.Update();
                MessageBox.Show("Данные обновлены!");
                UpdateSuppliers();
            }
        }

        private void supDel_button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Отменить действие будет невозможно! Продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                supplier.Delete();
                MessageBox.Show("Поставщик удален!");
                UpdateSuppliers();
            }
        }

        private void supAdd_button_Click(object sender, EventArgs e)
        {
            Suppliers.Add();
            MessageBox.Show("Поставщик добавлен!");
            UpdateSuppliers();
        }

        private void suppliers_dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (suppliers_dataGridView.SelectedRows.Count > 0)
            {
                supplier = new Supplier(int.Parse(suppliers_dataGridView.CurrentRow.Cells[0].Value.ToString()),
                   suppliers_dataGridView.CurrentRow.Cells[1].Value.ToString(),
                   suppliers_dataGridView.CurrentRow.Cells[2].Value.ToString(),
                   suppliers_dataGridView.CurrentRow.Cells[3].Value.ToString(),
                   suppliers_dataGridView.CurrentRow.Cells[4].Value.ToString(),
                   suppliers_dataGridView.CurrentRow.Cells[5].Value.ToString());

                supId_label.Text = supplier.Id.ToString();
                supName_textBox.Text = supplier.Name;
                supComp_textBox.Text = supplier.Company;
                supAddr_textBox.Text = supplier.Address;
                supPhone_maskedTextBox.Text = supplier.Phone;
                supMail_textBox.Text = supplier.Mail;

            }
        }

        private void brigUpdate_button_Click(object sender, EventArgs e)
        {
            if (brigName_textBox.Text.Length > 0)
            {
                brigade.Name = brigName_textBox.Text;
                brigade.Update();
                MessageBox.Show("Данные обновлены!");
                UpdateBrigade();
            }
        }

        private void brigAdd_button_Click(object sender, EventArgs e)
        {
            Brigades.Add();
            MessageBox.Show("Бригада добавлена!");
            UpdateBrigade();
        }

        private void brWorkerAdd_button_Click(object sender, EventArgs e)
        {
            if (brWorker_comboBox.SelectedIndex != -1)
            {
                brigade.AddWorker(int.Parse(brWorker_comboBox.Text.Substring(1).Split(new char[] { ')' })[0]));
                UpdateBrigade();
            }
        }

        private void brWorkerDel_button_Click(object sender, EventArgs e)
        {
            if (brWorkers_dataGridView.Rows.Count > 0)
            {
                brigade.DeleteWorker(int.Parse(brWorkers_dataGridView.CurrentRow.Cells[0].Value.ToString()));
                UpdateBrigade();
            }
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void prAdd_button_Click(object sender, EventArgs e)
        {
            Projects.Add();
            MessageBox.Show("Проект добавлен!");
            UpdateProject();
        }

        private void projects_dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (projects_dataGridView.SelectedRows.Count > 0)
            {
                project = new Project(int.Parse(projects_dataGridView.CurrentRow.Cells[0].Value.ToString()),
                   int.Parse(projects_dataGridView.CurrentRow.Cells[1].Value.ToString()),
                   int.Parse(projects_dataGridView.CurrentRow.Cells[2].Value.ToString()),
                   projects_dataGridView.CurrentRow.Cells[5].Value.ToString(),
                   projects_dataGridView.CurrentRow.Cells[6].Value.ToString(),
                   decimal.Parse(projects_dataGridView.CurrentRow.Cells[7].Value.ToString()),
                   DateTime.Parse(projects_dataGridView.CurrentRow.Cells[8].Value.ToString()),
                   DateTime.Parse(projects_dataGridView.CurrentRow.Cells[9].Value.ToString()),
                   projects_dataGridView.CurrentRow.Cells[10].Value.ToString(),
                   projects_dataGridView.CurrentRow.Cells[11].Value.ToString(),
                   projects_dataGridView.CurrentRow.Cells[12].Value.ToString());

                prId_label.Text = project.Id.ToString();
                prWorker_comboBox.Text = $"({project.WorkerId}) {projects_dataGridView.CurrentRow.Cells[4].Value.ToString()}";
                prClient_comboBox.Text = $"({project.ClientId}) {projects_dataGridView.CurrentRow.Cells[3].Value.ToString()}";
                prDescr_textBox.Text = project.Descr;
                prAddr_textBox.Text = project.Addr;
                prPrice_numericUpDown.Value = project.Price;
                prBegin_dateTimePicker.Value = project.Start;
                prEnd_dateTimePicker.Value = project.End;
                prStatus_comboBox.Text = project.Status;
                prType_textBox.Text = project.Type;
                prDoc_textBox.Text = project.Doc;
            }
        }

        private void prUpdate_button_Click(object sender, EventArgs e)
        {
            if (prDescr_textBox.Text.Length > 0 && prAddr_textBox.Text.Length >0 &&
                prBegin_dateTimePicker.Value < prEnd_dateTimePicker.Value && prType_textBox.Text.Length > 0 &&
                prDoc_textBox.Text.Length > 0 && prWorker_comboBox.SelectedIndex != -1 && prClient_comboBox.SelectedIndex != -1)
            {
                project.ClientId = int.Parse(prClient_comboBox.Text.Substring(1).Split(new char[] { ')' })[0]);
                project.WorkerId = int.Parse(prWorker_comboBox.Text.Substring(1).Split(new char[] { ')' })[0]);
                project.Descr = prDescr_textBox.Text;
                project.Addr = prAddr_textBox.Text;
                project.Price =  prPrice_numericUpDown.Value;
                project.Start = prBegin_dateTimePicker.Value;
                project.End = prEnd_dateTimePicker.Value;
                project.Status = prStatus_comboBox.Text;
                project.Type = prType_textBox.Text;
                project.Doc = prDoc_textBox.Text;
                if (project.Update())
                {
                    MessageBox.Show("Данные обновлены!");
                    UpdateProject();
                }
                else
                {
                    MessageBox.Show("Такой договор уже есть в базе!");
                }
            }
        }

        private void clientFind_button_Click(object sender, EventArgs e)
        {
            UpdateClients();
            ((DataTable)clients_dataGridView.DataSource).DefaultView.RowFilter = $"[ФИО] LIKE '%{clientFind_textBox.Text}%'";
        }

        private void matFind_button_Click(object sender, EventArgs e)
        {
            UpdateMaterials();
            ((DataTable)materials_dataGridView.DataSource).DefaultView.RowFilter = $"[Название] LIKE '%{matFind_textBox.Text}%'";
            ((DataTable)deliveries_dataGridView.DataSource).DefaultView.RowFilter = $"[Материал] LIKE '%{matFind_textBox.Text}%' OR [ФИО поставщика] LIKE '%{matFind_textBox.Text}%' OR [Фирма] LIKE '%{matFind_textBox.Text}%'";
        }

        private void supFind_button_Click(object sender, EventArgs e)
        {
            UpdateSuppliers();
            ((DataTable)suppliers_dataGridView.DataSource).DefaultView.RowFilter = $"[ФИО] LIKE '%{supFind_textBox.Text}%' OR [Фирма] LIKE '%{supFind_textBox.Text}%'";
        }

        private void brFind_button_Click(object sender, EventArgs e)
        {
            UpdateBrigade();
            ((DataTable)brigade_dataGridView.DataSource).DefaultView.RowFilter = $"[Название] LIKE '%{brFind_textBox.Text}%'";
        }

        private void prFind_button_Click(object sender, EventArgs e)
        {
            UpdateProject();
            ((DataTable)projects_dataGridView.DataSource).DefaultView.RowFilter = $"[Заказчик] LIKE '%{prFind_textBox.Text}%' OR [Сотрудник] LIKE '%{prFind_textBox.Text}%' OR [Описание] LIKE '%{prFind_textBox.Text}%'";
        }

        private void work_tabPage_Enter(object sender, EventArgs e)
        {
            UpdateWork();
        }

        private void work_dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (work_dataGridView.SelectedRows.Count > 0)
            {
                work = new Work(int.Parse(work_dataGridView.CurrentRow.Cells[0].Value.ToString()),
                    int.Parse(work_dataGridView.CurrentRow.Cells[1].Value.ToString()),
                    work_dataGridView.CurrentRow.Cells[3].Value.ToString(),
                    work_dataGridView.CurrentRow.Cells[4].Value.ToString());

                wrId_label.Text = work.Id.ToString();
                wrBr_comboBox.Text = $"({work.BrId}) {work_dataGridView.CurrentRow.Cells[2].Value.ToString()}";
                wrType_textBox.Text = work.Type;
                wrName_textBox.Text = work.Name;
            }
        }

        private void wrUpdate_button_Click(object sender, EventArgs e)
        {
            if (wrBr_comboBox.SelectedIndex != -1 && wrType_textBox.Text.Length > 0 && 
                wrName_textBox.Text.Length > 0)
            {
                work.Id = int.Parse(wrId_label.Text);
                work.BrId = int.Parse(wrBr_comboBox.Text.Substring(1).Split(new char[] {')'})[0]);
                work.Type = wrType_textBox.Text;
                work.Name = wrName_textBox.Text;

                work.Update();
                UpdateWork();
            }
        }

        private void wrAdd_button_Click(object sender, EventArgs e)
        {
            if (wrBr_comboBox.SelectedIndex != -1 && wrType_textBox.Text.Length > 0 &&
                wrName_textBox.Text.Length > 0)
            {
                work.Id = int.Parse(wrId_label.Text);
                work.BrId = int.Parse(wrBr_comboBox.Text.Substring(1).Split(new char[] { ')' })[0]);
                work.Type = wrType_textBox.Text;
                work.Name = wrName_textBox.Text;

                work.Add();
                UpdateWork();
            }
        }

        private void cmpWork_dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (cmpWork_dataGridView.SelectedRows.Count > 0)
            {
                workCompleted = new CompletedWork(int.Parse(cmpWork_dataGridView.CurrentRow.Cells[0].Value.ToString()),
                    int.Parse(cmpWork_dataGridView.CurrentRow.Cells[1].Value.ToString()),
                    DateTime.Parse(cmpWork_dataGridView.CurrentRow.Cells[2].Value.ToString()),
DateTime.Parse(                    cmpWork_dataGridView.CurrentRow.Cells[3].Value.ToString()),
                    cmpWork_dataGridView.CurrentRow.Cells[4].Value.ToString());

                cStatus_comboBox.Text = workCompleted.Status;
                cEnd_dateTimePicker.Value = workCompleted.End;
                cBegin_dateTimePicker.Value = workCompleted.Start;
                for (int i = 0; i < cPr_comboBox.Items.Count; i++)
                {
                    if (cPr_comboBox.Items[i].ToString().Contains($"({workCompleted.ProjId})"))
                        cPr_comboBox.SelectedIndex = i;
                }
                for (int i = 0; i < cWr_comboBox.Items.Count; i++)
                {
                    if (cWr_comboBox.Items[i].ToString().Contains($"({workCompleted.WorkId})"))
                        cWr_comboBox.SelectedIndex = i;
                }
            }
        }

        private void cUpdate_button_Click(object sender, EventArgs e)
        {
            if (cWr_comboBox.SelectedIndex != -1 && cPr_comboBox.SelectedIndex != -1 && cStatus_comboBox.SelectedIndex != -1)
            {
                workCompleted.Status = cStatus_comboBox.Text;
                workCompleted.End = cEnd_dateTimePicker.Value;
                workCompleted.Start = cBegin_dateTimePicker.Value;
                workCompleted.ProjId = int.Parse(cPr_comboBox.Text.Substring(1).Split(new char[] { ')' })[0]);
                workCompleted.WorkId = int.Parse(cWr_comboBox.Text.Substring(1).Split(new char[] { ')' })[0]);
                workCompleted.Update();
                UpdateWork();
            }
        }

        private void cAdd_button_Click(object sender, EventArgs e)
        {
            if (cWr_comboBox.SelectedIndex != -1 && cPr_comboBox.SelectedIndex != -1 && cStatus_comboBox.SelectedIndex != -1)
            {
                workCompleted.Status = cStatus_comboBox.Text;
                workCompleted.End = cEnd_dateTimePicker.Value;
                workCompleted.Start = cBegin_dateTimePicker.Value;
                workCompleted.ProjId = int.Parse(cPr_comboBox.Text.Substring(1).Split(new char[] { ')' })[0]);
                workCompleted.WorkId = int.Parse(cWr_comboBox.Text.Substring(1).Split(new char[] { ')' })[0]);
                workCompleted.Add();
                UpdateWork();
            }
        }

        private void matCon_tabPage_Enter(object sender, EventArgs e)
        {
            UpdateMatCon();
        }

        private void Rash_dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (Rash_dataGridView.Rows.Count > 0)
            {
                matCon = new MatCon(int.Parse(Rash_dataGridView.CurrentRow.Cells[2].Value.ToString()),
                   int.Parse(Rash_dataGridView.CurrentRow.Cells[0].Value.ToString()),
                   int.Parse(Rash_dataGridView.CurrentRow.Cells[4].Value.ToString()));

                RashCount_numericUpDown.Value = matCon.Count;
                
                for (int i = 0; i < RashMat_comboBox.Items.Count; i++)
                {
                    if (RashMat_comboBox.Items[i].ToString().Contains($"({matCon.MatId})"))
                        RashMat_comboBox.SelectedIndex = i;
                }
                for (int i = 0; i < RashWork_comboBox.Items.Count; i++)
                {
                    if (RashWork_comboBox.Items[i].ToString().Contains($"({matCon.WorkId})"))
                        RashWork_comboBox.SelectedIndex = i;
                }
            }
        }

        private void RashUpdate_button_Click(object sender, EventArgs e)
        {
            if (RashMat_comboBox.SelectedIndex != -1 && RashWork_comboBox.SelectedIndex != -1)
            {
                matCon.MatId = int.Parse(RashMat_comboBox.Text.Substring(1).Split(new char[] { ')' })[0]);
                matCon.WorkId = int.Parse(RashWork_comboBox.Text.Substring(1).Split(new char[] { ')' })[0]);
                matCon.Count = ((int)RashCount_numericUpDown.Value);
                matCon.Update();
                UpdateMatCon();
            }
        }

        private void RashAdd_button_Click(object sender, EventArgs e)
        {
            if (RashMat_comboBox.SelectedIndex != -1 && RashWork_comboBox.SelectedIndex != -1)
            {
                matCon.MatId = int.Parse(RashMat_comboBox.Text.Substring(1).Split(new char[] { ')' })[0]);
                matCon.WorkId = int.Parse(RashWork_comboBox.Text.Substring(1).Split(new char[] { ')' })[0]);
                matCon.Count = ((int)RashCount_numericUpDown.Value);
                matCon.Add();
                UpdateMatCon();
            }
        }

        private void RashDel_button_Click(object sender, EventArgs e)
        {
            if (RashMat_comboBox.SelectedIndex != -1 && RashWork_comboBox.SelectedIndex != -1)
            {
                matCon.MatId = int.Parse(RashMat_comboBox.Text.Substring(1).Split(new char[] { ')' })[0]);
                matCon.WorkId = int.Parse(RashWork_comboBox.Text.Substring(1).Split(new char[] { ')' })[0]);
                matCon.Count = ((int)RashCount_numericUpDown.Value);
                matCon.Delete();
                UpdateMatCon();
            }
        }

        private void edit_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateWorkerForm updateWorkerForm = new UpdateWorkerForm();
            updateWorkerForm.FormClosed += (object se, FormClosedEventArgs ee) => { UpdateCurrentWorker(); };
            updateWorkerForm.ShowDialog();
        }

        private void ewFio_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }         
        
        }
    }
}
