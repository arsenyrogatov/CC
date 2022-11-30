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
    public partial class UpdateWorkerForm : Form
    {
        public UpdateWorkerForm()
        {
            InitializeComponent();
            ewId_label.Text = CurrentWorker.Id.ToString();
            ewFio_textBox.Text = CurrentWorker.Name;
            ewPas1_maskedTextBox.Text = CurrentWorker.Passport.Split(new char[] {' '})[0];
            ewPas2_maskedTextBox.Text = CurrentWorker.Passport.Split(new char[] {' '})[1];
            ewBirth_dateTimePicker.Value = CurrentWorker.Birth;
            ewMale_radioButton.Checked = CurrentWorker.Gen == 'м';
            ewFem_radioButton.Checked = CurrentWorker.Gen == 'ж';
            ewJob_textBox.Text = CurrentWorker.Job;
            ewStage_numericUpDown.Value = CurrentWorker.Stage;
            ewPhone_maskedTextBox.Text = CurrentWorker.Phone;
            ewMail_textBox.Text = CurrentWorker.Mail;
        }

        private void updateWorker_button_Click(object sender, EventArgs e)
        {
            
            if (ewFio_textBox.Text.Length > 0 && ewPas1_maskedTextBox.MaskCompleted
                && ewPas2_maskedTextBox.MaskCompleted && ewJob_textBox.Text.Length > 0
                && ewPhone_maskedTextBox.MaskCompleted && ewMail_textBox.Text.Length > 0)
            {
                Worker worker = new Worker(CurrentWorker.Id,
                    ewFio_textBox.Text, int.Parse(ewPas1_maskedTextBox.Text),
                    int.Parse(ewPas2_maskedTextBox.Text), ewBirth_dateTimePicker.Value,
                    ewFem_radioButton.Checked ? 'ж' : 'м', ewJob_textBox.Text,
                    ((int)ewStage_numericUpDown.Value), ewPhone_maskedTextBox.Text,
                    ewMail_textBox.Text);

                if (worker.Update())
                {
                    MessageBox.Show("Данные обновлены!");
                    CurrentWorker.Login(worker.Phone, worker.Id.ToString());
                    Close();
                }
                else
                {
                    MessageBox.Show("Такие данные уже существуют!");
                }
            }
        }
    }
}
