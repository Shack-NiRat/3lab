using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Windows.Forms;

namespace laba_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();

            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }
        public int currentID = 1;

        private void InitializeDataGridView()
        {
            // Создание столбцов
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Product", "Товар");
            dataGridView1.Columns.Add("Quantity", "Количество");
            dataGridView1.Columns.Add("Price", "Цена");
            dataGridView1.Columns.Add("Total", "Сумма");

            // Установка столбца ID как только для чтения
            dataGridView1.Columns["ID"].ReadOnly = true;
            dataGridView1.Columns["Total"].ReadOnly = true;

            // Установка автогенерации идентификатора
            dataGridView1.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["ID"].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            dataGridView1.Columns["Total"].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;

            dataGridView1.Rows.Add(1, "", "", "", "");
        }

        private void addRow_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(++currentID, "", "", "", "");
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, что изменена конкретная ячейка в столбцах "Price" или "Quantity"
            if (e.RowIndex >= 0 && (e.ColumnIndex == 2 || e.ColumnIndex == 3))
            {
                // Получаем значения ячеек "Price" и "Quantity" текущей строки
                string priceStr = dataGridView1.Rows[e.RowIndex].Cells[2].Value?.ToString();
                string quantityStr = dataGridView1.Rows[e.RowIndex].Cells[3].Value?.ToString();

                // Проверяем, что значения не пусты и корректно преобразуются в числа
                if (!string.IsNullOrEmpty(priceStr) && !string.IsNullOrEmpty(quantityStr))
                {
                    // Пытаемся преобразовать значения в числа
                    bool isPriceValid = int.TryParse(priceStr, out int price);
                    bool isQuantityValid = int.TryParse(quantityStr, out int quantity);

                    if (isPriceValid && isQuantityValid)
                    {
                        // Вычисляем и устанавливаем значение в столбец "Total"
                        int total = price * quantity;
                        dataGridView1.Rows[e.RowIndex].Cells[4].Value = total;

                        changeTotlaDocumentPrice();
                    }
                    else
                    {
                        // Если значения не могут быть преобразованы, можно вывести сообщение об ошибке или предпринять другие меры.
                    }
                }
            }
        }

        private void changeTotlaDocumentPrice()
        {
            int totalDocumentPrice = 0;

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                totalDocumentPrice += int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());

            res.Text = $"{totalDocumentPrice}, руб";
        }

        private void go_Click(object sender, EventArgs e)
        {
            Word.Application winword = new Word.Application();
            Word.Document document = winword.Documents.Add();
            winword.Visible = true;

            Word.Paragraph invoicePar = document.Content.Paragraphs.Add();
            DateTime selectDate = dateTimePicker2.Value;

            if (selectDate != null)
            {
                string orderNumberText = order_number.Text;
                string formattedDate = selectDate.ToString("dd.MM.yyyy");

                // Форматирование всей строки
                string fullText = $"Расходная накладная № {orderNumberText} от {formattedDate}";
                invoicePar.Range.Text = fullText;

                // Настройка форматирования для номера заказа
                int orderNumberStart = fullText.IndexOf(orderNumberText);
                Word.Range boldUnderlineRangeOrderNumber = invoicePar.Range.Duplicate;
                boldUnderlineRangeOrderNumber.SetRange(orderNumberStart, orderNumberStart + orderNumberText.Length);
                boldUnderlineRangeOrderNumber.Font.Bold = 1; // 1 - для включения жирного шрифта
                boldUnderlineRangeOrderNumber.Font.Underline = Word.WdUnderline.wdUnderlineSingle;

                // Настройка форматирования для даты
                int dateStart = fullText.IndexOf(formattedDate);
                Word.Range boldUnderlineRangeDate = invoicePar.Range.Duplicate;
                boldUnderlineRangeDate.SetRange(dateStart, dateStart + formattedDate.Length);
                boldUnderlineRangeDate.Font.Bold = 1; // 1 - для включения жирного шрифта
                boldUnderlineRangeDate.Font.Underline = Word.WdUnderline.wdUnderlineSingle;

                invoicePar.Range.Font.Name = "Times new roman";
                invoicePar.Range.Font.Size = 14;

                invoicePar.Range.InsertParagraphAfter();
            }






            string PurchasertxtBox = provider_textBox.Text;
            Word.Paragraph providerPar = document.Content.Paragraphs.Add();
            providerPar.Range.Text = "Поставщик: ";
            providerPar.Range.Font.Name = "Times new roman";
            providerPar.Range.Font.Size = 14;

            // Добавляем часть текста с жирным и подчеркнутым форматированием
            Word.Range boldUnderlineRange = providerPar.Range.Paragraphs[1].Range;
            boldUnderlineRange.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
            boldUnderlineRange.Text = PurchasertxtBox;

            // Делаем текст жирным и подчеркнутым
            boldUnderlineRange.Font.Bold = 1; // 1 - для включения жирного шрифта
            boldUnderlineRange.Font.Underline = Word.WdUnderline.wdUnderlineSingle;

            providerPar.Range.InsertParagraphAfter();


            Word.Paragraph customerPar = document.Content.Paragraphs.Add();
            string ProvidertxtBox = buyer_textBox.Text;
            customerPar.Range.Text = "Покупатель: ";
            customerPar.Range.Font.Name = "Times new roman";
            customerPar.Range.Font.Size = 14;

            // Добавляем часть текста с жирным и подчеркнутым форматированием
            Word.Range boldUnderlineRange1 = customerPar.Range.Paragraphs[1].Range;
            boldUnderlineRange1.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
            boldUnderlineRange1.Text = ProvidertxtBox;

            // Делаем текст жирным и подчеркнутым
            boldUnderlineRange1.Font.Bold = 1; // 1 - для включения жирного шрифта
            boldUnderlineRange1.Font.Underline = Word.WdUnderline.wdUnderlineSingle;

            customerPar.Range.InsertParagraphAfter();



            int nRows = dataGridView1.Rows.Count;
            Word.Table myTable = document.Tables.Add(customerPar.Range, nRows, 5);
            myTable.Borders.Enable = 1;

            var headerRow = myTable.Rows[1].Cells;
            headerRow[1].Range.Text = "ID";
            headerRow[2].Range.Text = "Товар";
            headerRow[3].Range.Text = "Количество";
            headerRow[4].Range.Text = "Цена";
            headerRow[5].Range.Text = "Сумма";
            for (int i = 2; i < nRows + 1; i++)
            {
                var dataRow = myTable.Rows[i].Cells;

                dataRow[1].Range.Text = dataGridView1.Rows[i - 2].Cells[0].Value.ToString();
                dataRow[2].Range.Text = dataGridView1.Rows[i - 2].Cells[1].Value.ToString();
                dataRow[3].Range.Text = dataGridView1.Rows[i - 2].Cells[2].Value.ToString() + " кг";
                dataRow[4].Range.Text = dataGridView1.Rows[i - 2].Cells[3].Value.ToString() + " руб";
                dataRow[5].Range.Text = dataGridView1.Rows[i - 2].Cells[4].Value.ToString() + " руб";

                // Устанавливаем выравнивание по центру и делаем текст жирным
                dataRow[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                dataRow[1].Range.Font.Bold = 1;
                dataRow[2].Range.Font.Bold = 1;
                dataRow[3].Range.Font.Bold = 1;
                dataRow[4].Range.Font.Bold = 1;
                dataRow[5].Range.Font.Bold = 1;
            }


            // добавляем параграф с итогом
            Word.Paragraph result = document.Content.Paragraphs.Add();
            string resultString = res.Text;
            result.Range.Text = $"Итого:    {resultString}";

            // Устанавливаем отступ сверху (например, 12 поинтов)
            result.Range.ParagraphFormat.SpaceBefore = 12;

            result.Range.Font.Name = "Times new roman";
            result.Range.Font.Size = 14;
            result.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
            result.Range.InsertParagraphAfter();


            // Добавление диалога выбора пути сохранения файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Word (*.doc)|*.doc";
            saveFileDialog.Title = "Сохранить файл Word";
            saveFileDialog.FileName = "wordExample"; // Имя файла по умолчанию

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                object filename = saveFileDialog.FileName;
                document.SaveAs(filename);
                document.Close();
            }

            winword.Quit();

        }

        private void go_Excel_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];

            DateTime selectDate = dateTimePicker2.Value;

            if (selectDate != null)
            {
                string orderNumberText = order_number.Text;
                string formattedDate = selectDate.ToString("dd.MM.yyyy");

                // Форматирование всей строки
                string fullText = $"Расходная накладная № {orderNumberText} от {formattedDate}";
                worksheet.Cells[1, 1] = fullText;

                // Настройка форматирования для номера заказа
                int orderNumberStart = fullText.IndexOf(orderNumberText);
                Excel.Range boldUnderlineRangeOrderNumber = (Excel.Range)worksheet.Cells[1, 1];
                boldUnderlineRangeOrderNumber.Characters[orderNumberStart + 1, orderNumberText.Length].Font.Bold = true;
                boldUnderlineRangeOrderNumber.Characters[orderNumberStart + 1, orderNumberText.Length].Font.Underline = true;

                worksheet.Cells[1, 1].Font.Name = "Times new roman";
                worksheet.Cells[1, 1].Font.Size = 14;
            }

            string PurchasertxtBox = provider_textBox.Text;
            worksheet.Cells[2, 1] = "Поставщик: ";

            // Добавляем часть текста с жирным и подчеркнутым форматированием
            Excel.Range boldUnderlineRange = (Excel.Range)worksheet.Cells[2, 1];
            boldUnderlineRange.Characters[boldUnderlineRange.Text.Length + 1, PurchasertxtBox.Length].Text = PurchasertxtBox;
            boldUnderlineRange.Characters[boldUnderlineRange.Text.Length - PurchasertxtBox.Length + 1, PurchasertxtBox.Length].Font.Bold = true;
            boldUnderlineRange.Characters[boldUnderlineRange.Text.Length - PurchasertxtBox.Length + 1, PurchasertxtBox.Length].Font.Underline = true;

            worksheet.Cells[2, 1].Font.Name = "Times new roman";
            worksheet.Cells[2, 1].Font.Size = 14;

            string ProvidertxtBox = buyer_textBox.Text;
            worksheet.Cells[3, 1] = "Покупатель: ";

            // Добавляем часть текста с жирным и подчеркнутым форматированием
            Excel.Range boldUnderlineRange1 = (Excel.Range)worksheet.Cells[3, 1];
            boldUnderlineRange1.Characters[boldUnderlineRange1.Text.Length + 1, ProvidertxtBox.Length].Text = ProvidertxtBox;
            boldUnderlineRange1.Characters[boldUnderlineRange1.Text.Length - ProvidertxtBox.Length + 1, ProvidertxtBox.Length].Font.Bold = true;
            boldUnderlineRange1.Characters[boldUnderlineRange1.Text.Length - ProvidertxtBox.Length + 1, ProvidertxtBox.Length].Font.Underline = true;

            worksheet.Cells[3, 1].Font.Name = "Times new roman";
            worksheet.Cells[3, 1].Font.Size = 14;

            int nRows = dataGridView1.Rows.Count;

            for (int i = 1; i <= 5; i++)
            {
                worksheet.Cells[4, i] = dataGridView1.Columns[i - 1].HeaderText;
            }

            for (int i = 2; i <= nRows; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    var cellValue = dataGridView1.Rows[i - 2].Cells[j - 1].Value;

                    // Проверяем, что значение ячейки не равно null
                    if (cellValue != null)
                    {
                        worksheet.Cells[i + 2, j] = cellValue.ToString();
                        worksheet.Cells[i + 2, j].Font.Bold = true;
                        worksheet.Cells[i + 2, j].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    }
                    else
                    {
                        // Если значение ячейки равно null, установите значение по умолчанию или обработайте такой случай по вашему усмотрению.
                        worksheet.Cells[i + 2, j] = "N/A";
                    }
                }
            }


            Excel.Range totalCell = (Excel.Range)worksheet.Cells[nRows + 4, 1];
            totalCell.Value = $"Итого: {res.Text}";
            totalCell.Font.Name = "Times new roman";
            totalCell.Font.Size = 14;
            totalCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // Добавление диалога выбора пути сохранения файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Сохранить файл Excel";
            saveFileDialog.FileName = "excelExample"; // Имя файла по умолчанию

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName);
                workbook.Close();
                excelApp.Quit();
            }
        }
    }
}
