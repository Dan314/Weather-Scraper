namespace WeatherApp
{
    partial class weatherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cityInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.currTemp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.wind = new System.Windows.Forms.TextBox();
            this.condition = new System.Windows.Forms.TextBox();
            this.feelsLikeTemp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.internationalBox = new System.Windows.Forms.CheckBox();
            //this.countriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //this.stateAndCountryNamesDataSet = new WeatherApp.StateAndCountryNamesDataSet();
            this.stateListBox = new System.Windows.Forms.ListBox();
            //this.statesTableAdapter = new WeatherApp.StateAndCountryNamesDataSetTableAdapters.StatesTableAdapter();
            //this.countriesTableAdapter = new WeatherApp.StateAndCountryNamesDataSetTableAdapters.CountriesTableAdapter();
            this.submitButton = new System.Windows.Forms.Button();
            //this.statesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //((System.ComponentModel.ISupportInitialize)(this.countriesBindingSource)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.stateAndCountryNamesDataSet)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.statesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cityInput
            // 
            this.cityInput.Location = new System.Drawing.Point(15, 25);
            this.cityInput.Name = "cityInput";
            this.cityInput.Size = new System.Drawing.Size(159, 20);
            this.cityInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Enter City:";
            // 
            // currTemp
            // 
            this.currTemp.Location = new System.Drawing.Point(15, 170);
            this.currTemp.Name = "currTemp";
            this.currTemp.ReadOnly = true;
            this.currTemp.Size = new System.Drawing.Size(117, 20);
            this.currTemp.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Select State:";
            // 
            // wind
            // 
            this.wind.Location = new System.Drawing.Point(186, 229);
            this.wind.Name = "wind";
            this.wind.ReadOnly = true;
            this.wind.Size = new System.Drawing.Size(117, 20);
            this.wind.TabIndex = 8;
            // 
            // condition
            // 
            this.condition.Location = new System.Drawing.Point(186, 170);
            this.condition.Name = "condition";
            this.condition.ReadOnly = true;
            this.condition.Size = new System.Drawing.Size(117, 20);
            this.condition.TabIndex = 6;
            // 
            // feelsLikeTemp
            // 
            this.feelsLikeTemp.Location = new System.Drawing.Point(15, 229);
            this.feelsLikeTemp.Name = "feelsLikeTemp";
            this.feelsLikeTemp.ReadOnly = true;
            this.feelsLikeTemp.Size = new System.Drawing.Size(117, 20);
            this.feelsLikeTemp.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Temperature:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Condition:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Feels Like:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Wind:";
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(256, 25);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.ReadOnly = true;
            this.messageTextBox.Size = new System.Drawing.Size(160, 65);
            this.messageTextBox.TabIndex = 9;
            this.messageTextBox.Visible = false;
            // 
            // internationalBox
            // 
            this.internationalBox.AutoSize = true;
            this.internationalBox.Location = new System.Drawing.Point(402, 153);
            this.internationalBox.Name = "internationalBox";
            this.internationalBox.Size = new System.Drawing.Size(84, 17);
            this.internationalBox.TabIndex = 2;
            this.internationalBox.Text = "International";
            this.internationalBox.UseVisualStyleBackColor = true;
            this.internationalBox.CheckedChanged += new System.EventHandler(this.internationalBox_CheckedChanged);
            // 
            // countriesBindingSource
            // 
            //this.countriesBindingSource.DataMember = "Countries";
            //this.countriesBindingSource.DataSource = this.stateAndCountryNamesDataSet;
            // 
            // stateAndCountryNamesDataSet
            // 
            //this.stateAndCountryNamesDataSet.DataSetName = "StateAndCountryNamesDataSet";
            //this.stateAndCountryNamesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stateListBox
            // 
            //this.stateListBox.DataSource = this.statesBindingSource;
            //this.stateListBox.DisplayMember = "State";
            this.stateListBox.FormattingEnabled = true;
            this.stateListBox.Location = new System.Drawing.Point(15, 70);
            this.stateListBox.Name = "stateListBox";
            this.stateListBox.Size = new System.Drawing.Size(159, 43);
            this.stateListBox.TabIndex = 3;
            // 
            // statesTableAdapter
            // 
            //this.statesTableAdapter.ClearBeforeFill = true;
            // 
            // countriesTableAdapter
            // 
            //this.countriesTableAdapter.ClearBeforeFill = true;
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.OrangeRed;
            this.submitButton.Location = new System.Drawing.Point(57, 119);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // statesBindingSource
            // 
            //this.statesBindingSource.DataMember = "States";
            //this.statesBindingSource.DataSource = this.stateAndCountryNamesDataSet;
            // 
            // weatherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(506, 261);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.stateListBox);
            this.Controls.Add(this.internationalBox);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.feelsLikeTemp);
            this.Controls.Add(this.condition);
            this.Controls.Add(this.wind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currTemp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cityInput);
            this.Name = "weatherForm";
            this.Text = "Weather Application";
            this.Load += new System.EventHandler(this.weatherForm_Load);
            //((System.ComponentModel.ISupportInitialize)(this.countriesBindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.stateAndCountryNamesDataSet)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.statesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox cityInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox currTemp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox wind;
        private System.Windows.Forms.TextBox condition;
        private System.Windows.Forms.TextBox feelsLikeTemp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.CheckBox internationalBox;
        //private System.Windows.Forms.BindingSource countriesBindingSource;
        private System.Windows.Forms.ListBox stateListBox;
        //private StateAndCountryNamesDataSet stateAndCountryNamesDataSet;
        //private StateAndCountryNamesDataSetTableAdapters.StatesTableAdapter statesTableAdapter;
        //private StateAndCountryNamesDataSetTableAdapters.CountriesTableAdapter countriesTableAdapter;
        private System.Windows.Forms.Button submitButton;
        //private System.Windows.Forms.BindingSource statesBindingSource;
    }
}

