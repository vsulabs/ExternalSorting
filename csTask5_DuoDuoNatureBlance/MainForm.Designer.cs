namespace csTask5_DuoDuoNatureBlance
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlView = new System.Windows.Forms.Panel();
            this.lblRandom = new System.Windows.Forms.Label();
            this.lblReverseData = new System.Windows.Forms.Label();
            this.gridReverseRating = new System.Windows.Forms.DataGridView();
            this.gridRandomRating = new System.Windows.Forms.DataGridView();
            this.lblRight = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.tbRightFile = new System.Windows.Forms.TextBox();
            this.tbLeftFile = new System.Windows.Forms.TextBox();
            this.pnlSortOptions = new System.Windows.Forms.Panel();
            this.btnCreateFile = new System.Windows.Forms.Button();
            this.gbTypeOfFile = new System.Windows.Forms.GroupBox();
            this.rbReverse = new System.Windows.Forms.RadioButton();
            this.rbRandom = new System.Windows.Forms.RadioButton();
            this.btnSort = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.updwnCounter = new System.Windows.Forms.NumericUpDown();
            this.gbAction = new System.Windows.Forms.GroupBox();
            this.rbRating = new System.Windows.Forms.RadioButton();
            this.rbSort = new System.Windows.Forms.RadioButton();
            this.pnlMain.SuspendLayout();
            this.pnlView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReverseRating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRandomRating)).BeginInit();
            this.pnlSortOptions.SuspendLayout();
            this.gbTypeOfFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updwnCounter)).BeginInit();
            this.gbAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlView);
            this.pnlMain.Controls.Add(this.pnlSortOptions);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(709, 447);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlView
            // 
            this.pnlView.Controls.Add(this.lblRandom);
            this.pnlView.Controls.Add(this.lblReverseData);
            this.pnlView.Controls.Add(this.gridReverseRating);
            this.pnlView.Controls.Add(this.gridRandomRating);
            this.pnlView.Controls.Add(this.lblRight);
            this.pnlView.Controls.Add(this.lblLeft);
            this.pnlView.Controls.Add(this.tbRightFile);
            this.pnlView.Controls.Add(this.tbLeftFile);
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Location = new System.Drawing.Point(201, 0);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(508, 447);
            this.pnlView.TabIndex = 1;
            // 
            // lblRandom
            // 
            this.lblRandom.AutoSize = true;
            this.lblRandom.Location = new System.Drawing.Point(22, 9);
            this.lblRandom.Name = "lblRandom";
            this.lblRandom.Size = new System.Drawing.Size(147, 13);
            this.lblRandom.TabIndex = 7;
            this.lblRandom.Text = "Данные рандомного файла";
            // 
            // lblReverseData
            // 
            this.lblReverseData.AutoSize = true;
            this.lblReverseData.Location = new System.Drawing.Point(22, 212);
            this.lblReverseData.Name = "lblReverseData";
            this.lblReverseData.Size = new System.Drawing.Size(138, 13);
            this.lblReverseData.TabIndex = 6;
            this.lblReverseData.Text = "Данные обратного файла";
            // 
            // gridReverseRating
            // 
            this.gridReverseRating.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReverseRating.Location = new System.Drawing.Point(25, 232);
            this.gridReverseRating.Name = "gridReverseRating";
            this.gridReverseRating.Size = new System.Drawing.Size(462, 148);
            this.gridReverseRating.TabIndex = 5;
            // 
            // gridRandomRating
            // 
            this.gridRandomRating.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRandomRating.Location = new System.Drawing.Point(22, 32);
            this.gridRandomRating.Name = "gridRandomRating";
            this.gridRandomRating.Size = new System.Drawing.Size(462, 148);
            this.gridRandomRating.TabIndex = 4;
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.Location = new System.Drawing.Point(253, 8);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(128, 13);
            this.lblRight.TabIndex = 3;
            this.lblRight.Text = "Отсортированный файл";
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Location = new System.Drawing.Point(22, 8);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(87, 13);
            this.lblLeft.TabIndex = 2;
            this.lblLeft.Text = "Исходный файл";
            // 
            // tbRightFile
            // 
            this.tbRightFile.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbRightFile.Location = new System.Drawing.Point(256, 28);
            this.tbRightFile.Multiline = true;
            this.tbRightFile.Name = "tbRightFile";
            this.tbRightFile.ReadOnly = true;
            this.tbRightFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRightFile.Size = new System.Drawing.Size(228, 319);
            this.tbRightFile.TabIndex = 1;
            this.tbRightFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbLeftFile
            // 
            this.tbLeftFile.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbLeftFile.Location = new System.Drawing.Point(22, 28);
            this.tbLeftFile.Multiline = true;
            this.tbLeftFile.Name = "tbLeftFile";
            this.tbLeftFile.ReadOnly = true;
            this.tbLeftFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLeftFile.Size = new System.Drawing.Size(228, 319);
            this.tbLeftFile.TabIndex = 0;
            this.tbLeftFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlSortOptions
            // 
            this.pnlSortOptions.Controls.Add(this.btnCreateFile);
            this.pnlSortOptions.Controls.Add(this.gbTypeOfFile);
            this.pnlSortOptions.Controls.Add(this.btnSort);
            this.pnlSortOptions.Controls.Add(this.lblCount);
            this.pnlSortOptions.Controls.Add(this.updwnCounter);
            this.pnlSortOptions.Controls.Add(this.gbAction);
            this.pnlSortOptions.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSortOptions.Location = new System.Drawing.Point(0, 0);
            this.pnlSortOptions.Name = "pnlSortOptions";
            this.pnlSortOptions.Size = new System.Drawing.Size(201, 447);
            this.pnlSortOptions.TabIndex = 0;
            // 
            // btnCreateFile
            // 
            this.btnCreateFile.Location = new System.Drawing.Point(10, 129);
            this.btnCreateFile.Name = "btnCreateFile";
            this.btnCreateFile.Size = new System.Drawing.Size(124, 23);
            this.btnCreateFile.TabIndex = 6;
            this.btnCreateFile.Text = "Создать файл";
            this.btnCreateFile.UseVisualStyleBackColor = true;
            this.btnCreateFile.Click += new System.EventHandler(this.btnCreateFile_Click);
            // 
            // gbTypeOfFile
            // 
            this.gbTypeOfFile.Controls.Add(this.rbReverse);
            this.gbTypeOfFile.Controls.Add(this.rbRandom);
            this.gbTypeOfFile.Location = new System.Drawing.Point(3, 12);
            this.gbTypeOfFile.Name = "gbTypeOfFile";
            this.gbTypeOfFile.Size = new System.Drawing.Size(187, 72);
            this.gbTypeOfFile.TabIndex = 2;
            this.gbTypeOfFile.TabStop = false;
            this.gbTypeOfFile.Text = "Тип файла";
            // 
            // rbReverse
            // 
            this.rbReverse.AutoSize = true;
            this.rbReverse.Location = new System.Drawing.Point(7, 43);
            this.rbReverse.Name = "rbReverse";
            this.rbReverse.Size = new System.Drawing.Size(76, 17);
            this.rbReverse.TabIndex = 1;
            this.rbReverse.Text = "Обратный";
            this.rbReverse.UseVisualStyleBackColor = true;
            // 
            // rbRandom
            // 
            this.rbRandom.AutoSize = true;
            this.rbRandom.Checked = true;
            this.rbRandom.Location = new System.Drawing.Point(7, 20);
            this.rbRandom.Name = "rbRandom";
            this.rbRandom.Size = new System.Drawing.Size(80, 17);
            this.rbRandom.TabIndex = 0;
            this.rbRandom.TabStop = true;
            this.rbRandom.Text = "Случайный";
            this.rbRandom.UseVisualStyleBackColor = true;
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(10, 304);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(124, 23);
            this.btnSort.TabIndex = 5;
            this.btnSort.Text = "Выполнить";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(7, 87);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(127, 13);
            this.lblCount.TabIndex = 4;
            this.lblCount.Text = "Количество элементов:";
            // 
            // updwnCounter
            // 
            this.updwnCounter.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.updwnCounter.Location = new System.Drawing.Point(10, 103);
            this.updwnCounter.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.updwnCounter.Name = "updwnCounter";
            this.updwnCounter.Size = new System.Drawing.Size(124, 20);
            this.updwnCounter.TabIndex = 1;
            // 
            // gbAction
            // 
            this.gbAction.Controls.Add(this.rbRating);
            this.gbAction.Controls.Add(this.rbSort);
            this.gbAction.Location = new System.Drawing.Point(3, 212);
            this.gbAction.Name = "gbAction";
            this.gbAction.Size = new System.Drawing.Size(187, 72);
            this.gbAction.TabIndex = 0;
            this.gbAction.TabStop = false;
            this.gbAction.Text = "Действие";
            // 
            // rbRating
            // 
            this.rbRating.AutoSize = true;
            this.rbRating.Location = new System.Drawing.Point(7, 43);
            this.rbRating.Name = "rbRating";
            this.rbRating.Size = new System.Drawing.Size(133, 17);
            this.rbRating.TabIndex = 1;
            this.rbRating.Text = "Производительность";
            this.rbRating.UseVisualStyleBackColor = true;
            // 
            // rbSort
            // 
            this.rbSort.AutoSize = true;
            this.rbSort.Checked = true;
            this.rbSort.Location = new System.Drawing.Point(7, 20);
            this.rbSort.Name = "rbSort";
            this.rbSort.Size = new System.Drawing.Size(85, 17);
            this.rbSort.TabIndex = 0;
            this.rbSort.TabStop = true;
            this.rbSort.Text = "Сортировка";
            this.rbSort.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 447);
            this.Controls.Add(this.pnlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Сортировка";
            this.pnlMain.ResumeLayout(false);
            this.pnlView.ResumeLayout(false);
            this.pnlView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReverseRating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRandomRating)).EndInit();
            this.pnlSortOptions.ResumeLayout(false);
            this.pnlSortOptions.PerformLayout();
            this.gbTypeOfFile.ResumeLayout(false);
            this.gbTypeOfFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updwnCounter)).EndInit();
            this.gbAction.ResumeLayout(false);
            this.gbAction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlView;
        private System.Windows.Forms.TextBox tbRightFile;
        private System.Windows.Forms.TextBox tbLeftFile;
        private System.Windows.Forms.Panel pnlSortOptions;
        private System.Windows.Forms.GroupBox gbAction;
        private System.Windows.Forms.RadioButton rbRating;
        private System.Windows.Forms.RadioButton rbSort;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.NumericUpDown updwnCounter;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.DataGridView gridRandomRating;
        private System.Windows.Forms.Button btnCreateFile;
        private System.Windows.Forms.GroupBox gbTypeOfFile;
        private System.Windows.Forms.RadioButton rbReverse;
        private System.Windows.Forms.RadioButton rbRandom;
        private System.Windows.Forms.Label lblReverseData;
        private System.Windows.Forms.DataGridView gridReverseRating;
        private System.Windows.Forms.Label lblRandom;
    }
}

