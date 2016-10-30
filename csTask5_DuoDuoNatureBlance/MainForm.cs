using System;
using System.Windows.Forms;

namespace csTask5_DuoDuoNatureBlance
{
    public partial class MainForm : Form
    {
        /// <summary> Структура данных, отвечающая за сортировку файлов
        /// двухпутевым двухфазным естественным сбалансированным слиянием
        /// </summary>
        private readonly GuiSequences _seq;

        /// <summary> Некий "флажок", показывающий, можно ли производить сортировку
        /// </summary>
        private bool _canSort;

        public MainForm()
        {
            InitializeComponent();            
            _seq = new GuiSequences("exturn.dat", tbLeftFile, tbRightFile);            
            GuiSequences.InitGridView(gridRandomRating);
            GuiSequences.InitGridView(gridReverseRating);
            Application.Idle += MainIdle;
        }

        /// <summary> Нажатие на кнопки создает соответствующий файл 
        /// (чисел в обратном порядке или из случайных)
        /// </summary>
        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            if (rbRandom.Checked)
                _seq.GenerateRandomFile(Convert.ToUInt32(updwnCounter.Value));
            else 
                _seq.GenerateReverseFile(Convert.ToUInt32(updwnCounter.Value));
            _canSort = true;
        }

        /// <summary> Нажатие на кнопку производит сортировку 
        /// (тестовую или с получением статистики)
        /// </summary>
        private void btnSort_Click(object sender, EventArgs e)
        {
            if (rbSort.Checked) 
                _seq.Sort();            
            else  // rbRatio.Checked
                _seq.RatioSort(gridRandomRating, gridReverseRating);            
            _canSort = false;
        }

        /// <summary> Контроль видимости и доступности элементов на форме
        /// </summary>        
        private void MainIdle(object sender, EventArgs e)
        {
            btnSort.Enabled = _seq != null && (rbRating.Checked || _canSort);            
            btnCreateFile.Enabled = updwnCounter.Value > 1 && rbSort.Checked;
            
            lblLeft.Visible = lblRight.Visible = tbRightFile.Visible =
                btnCreateFile.Visible = updwnCounter.Visible = tbLeftFile.Visible =
                lblCount.Visible = gbTypeOfFile.Enabled = rbSort.Checked;

            lblRandom.Visible = lblReverseData.Visible = 
                gridRandomRating.Visible = gridReverseRating.Visible = rbRating.Checked;
        }
        
    }
}
