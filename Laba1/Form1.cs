using Laba1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Laba1
{
    public partial class IDE : Form
    {

        public IDE()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text.File(*.txt)|*.txt|Notepad File (*.tnf)|*tnf";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void создатьToolStripButton_Click(object sender, EventArgs e)
        {

        }


        private void справкаToolStripButton_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Paste();
            }
        }

        private void открытьToolStripButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создать новый файл
            richTextBox1.Text = "";
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Сохранение файла
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Paste();
            }
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Отменить последнее действие
            richTextBox1.Undo();
        }

        private void повторитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Повторить последнее отмененное действие
            richTextBox1.Redo();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Удалить выделенный текст
            richTextBox1.SelectedText = "";
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.SelectAll();
            }
            // Выделить весь текст
        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                richTextBox1.ContextMenuStrip = contextMenuStrip1;
            }
        }

        private void копироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void вставитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Paste();
            }
        }

        private void вырезатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void выделитьВсеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.SelectAll();
            }
            // Выделить весь текст
        }

        private void сохранитьToolStripButton_Click(object sender, EventArgs e)
        {
            // Сохранение файла
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
        }

        private void печатьToolStripButton_Click(object sender, EventArgs e)
        {
            // Вернуться к предыдущему состоянию документа
            richTextBox1.Undo();
        }

        private void вырезатьToolStripButton_Click(object sender, EventArgs e)
        {
            // Вернуться к следующему состоянию документа
            richTextBox1.Redo();
        }

        private void вставкаToolStripButton_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void копироватьToolStripButton_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void вызовСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ПРОГРАММА 2024", "Компилятор");


        }

        private void пускToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Сканер_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void парсерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем текст из RichTextBox
                string inputText = richTextBox1.Text;

                // Создаем экземпляр парсера
                PHPCommentParser parser = new PHPCommentParser(inputText);

                // Вызываем метод ParseComments
                List<PHPCommentParser.Error> errors = parser.ParseComments();

                // Очищаем DataGridView перед добавлением новых данных
                dataGridView2.Rows.Clear();

                // Добавляем каждую ошибку в DataGridView
                if (errors.Count == 0)
                {
                    // Создаем новую строку для DataGridView
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridView2);

                    // Устанавливаем значение "Ошибок нету" в колонку "Сообщение"
                    row.Cells[2].Value = "Ошибок нету";

                    // Устанавливаем цвет текста в черный для всех ячеек
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.ForeColor = Color.Black;
                    }

                    // Добавляем строку в DataGridView
                    dataGridView2.Rows.Add(row);
                }
                else
                {
                    foreach (PHPCommentParser.Error error in errors)
                    {
                        // Создаем новую строку для DataGridView
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dataGridView2);

                        // Заполняем ячейки строки значениями
                        row.Cells[0].Value = error.Number; // №
                        row.Cells[1].Value = $"С {error.StartIndex} по {error.EndIndex}"; // Местоположение
                        row.Cells[2].Value = error.Message; // Сообщение

                        // Устанавливаем цвет текста в черный для всех ячеек
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cell.Style.ForeColor = Color.Black;
                        }

                        // Добавляем строку в DataGridView
                        dataGridView2.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                // В случае ошибки выводим сообщение
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void сканерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем входной текст из TextBox
                string input = richTextBox1.Text;

                // Создаем экземпляр лексера с входным текстом
                Lexer lexer = new Lexer(input);

                // Вызываем метод Tokenize для анализа текста
                List<Token> tokens = lexer.Tokenize();

                // Очищаем предыдущие результаты
                dataGridView1.Rows.Clear();

                // Устанавливаем начальные позиции для форматирования
                int start = 0;

                // Добавляем токены в DataGridView и форматируем комментарии
                foreach (var token in tokens)
                {
                    string commentType = ""; // Переменная для хранения названия комментария

                    // Определяем название комментария в зависимости от типа токена
                    switch (token.Type)
                    {
                        case TokenType.Kommentariy:
                            commentType = "Однострочный комментарий";
                            break;
                        case TokenType.Kommentar1y:
                            commentType = "Хэш-комментарий";
                            break;
                        case TokenType.Dvuxstrochniykomm:
                            commentType = "Многострочный комментарий - начало";
                            break;
                        case TokenType.Konecdvuxstrochnogo:
                            commentType = "Многострочный комментарий - конец";
                            break;
                        case TokenType.Perexodnanovuyustroky:
                            commentType = "Переход на новую строку";
                            break;
                        case TokenType.Symbol:
                            commentType = "Символ";
                            break;
                        default:
                            commentType = "Неизвестный тип";
                            break;
                    }

                    // Добавляем строку в DataGridView
                    dataGridView1.Rows.Add(new object[] { token.Code, commentType, token.Value, token.Column, token.StartIndex + 1, token.EndIndex + 1 });

                    // Форматируем текст после однострочных комментариев "#" в черный цвет
                    if (token.Type == TokenType.Kommentar1y && token.Value == "#")
                    {
                        richTextBox1.Select(token.EndIndex + 1, input.Length - (token.EndIndex + 1));
                        richTextBox1.SelectionColor = Color.Black;
                    }
                }

                // Восстанавливаем форматирование для оставшейся части текста
                richTextBox1.Select(start, input.Length - start);
                richTextBox1.SelectionColor = Color.Black;
            }
            catch (Exception ex)
            {
                // В случае ошибки выводим сообщение
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Очищаем предыдущие результаты
                dataGridView1.Rows.Clear();
            }
        }
    }
}