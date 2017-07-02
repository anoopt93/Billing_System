<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Home
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btstock = New System.Windows.Forms.Button()
        Me.btexit = New System.Windows.Forms.Button()
        Me.btreport = New System.Windows.Forms.Button()
        Me.Table1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AnoopDataSet = New WindowsApplication1.AnoopDataSet()
        Me.Table1TableAdapter = New WindowsApplication1.AnoopDataSetTableAdapters.Table1TableAdapter()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbTax = New System.Windows.Forms.TextBox()
        Me.btTax = New System.Windows.Forms.Button()
        Me.btInvoice = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btDiscount = New System.Windows.Forms.Button()
        Me.tbDisc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LabelTax = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LabelDisc = New System.Windows.Forms.Label()
        CType(Me.Table1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnoopDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btstock
        '
        Me.btstock.BackColor = System.Drawing.Color.DimGray
        Me.btstock.Font = New System.Drawing.Font("Palatino Linotype", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btstock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btstock.Location = New System.Drawing.Point(1033, 66)
        Me.btstock.Name = "btstock"
        Me.btstock.Size = New System.Drawing.Size(222, 67)
        Me.btstock.TabIndex = 4
        Me.btstock.Text = "Stock"
        Me.btstock.UseVisualStyleBackColor = False
        '
        'btexit
        '
        Me.btexit.BackColor = System.Drawing.Color.DimGray
        Me.btexit.Font = New System.Drawing.Font("Palatino Linotype", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btexit.Location = New System.Drawing.Point(1033, 497)
        Me.btexit.Name = "btexit"
        Me.btexit.Size = New System.Drawing.Size(222, 67)
        Me.btexit.TabIndex = 8
        Me.btexit.Text = "Exit"
        Me.btexit.UseVisualStyleBackColor = False
        '
        'btreport
        '
        Me.btreport.BackColor = System.Drawing.Color.DimGray
        Me.btreport.Font = New System.Drawing.Font("Palatino Linotype", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btreport.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btreport.Location = New System.Drawing.Point(1033, 167)
        Me.btreport.Name = "btreport"
        Me.btreport.Size = New System.Drawing.Size(222, 67)
        Me.btreport.TabIndex = 5
        Me.btreport.Text = "Report"
        Me.btreport.UseVisualStyleBackColor = False
        '
        'Table1BindingSource
        '
        Me.Table1BindingSource.DataMember = "Table1"
        Me.Table1BindingSource.DataSource = Me.AnoopDataSet
        '
        'AnoopDataSet
        '
        Me.AnoopDataSet.DataSetName = "AnoopDataSet"
        Me.AnoopDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Table1TableAdapter
        '
        Me.Table1TableAdapter.ClearBeforeFill = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DimGray
        Me.Button1.Font = New System.Drawing.Font("Palatino Linotype", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(1033, 270)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(222, 67)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Staff Registration"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(384, 341)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "TAX %"
        '
        'tbTax
        '
        Me.tbTax.Location = New System.Drawing.Point(448, 341)
        Me.tbTax.Name = "tbTax"
        Me.tbTax.Size = New System.Drawing.Size(162, 20)
        Me.tbTax.TabIndex = 0
        '
        'btTax
        '
        Me.btTax.BackColor = System.Drawing.Color.DimGray
        Me.btTax.Font = New System.Drawing.Font("Palatino Linotype", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btTax.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btTax.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btTax.Location = New System.Drawing.Point(388, 382)
        Me.btTax.Name = "btTax"
        Me.btTax.Size = New System.Drawing.Size(222, 67)
        Me.btTax.TabIndex = 1
        Me.btTax.Text = "Edit Tax"
        Me.btTax.UseVisualStyleBackColor = False
        '
        'btInvoice
        '
        Me.btInvoice.BackColor = System.Drawing.Color.DimGray
        Me.btInvoice.Font = New System.Drawing.Font("Palatino Linotype", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btInvoice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btInvoice.Location = New System.Drawing.Point(1033, 382)
        Me.btInvoice.Name = "btInvoice"
        Me.btInvoice.Size = New System.Drawing.Size(222, 67)
        Me.btInvoice.TabIndex = 7
        Me.btInvoice.Text = "Invoice"
        Me.btInvoice.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.WindowsApplication1.My.Resources.Resources.administration1
        Me.PictureBox1.Location = New System.Drawing.Point(613, 507)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(419, 215)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.WindowsApplication1.My.Resources.Resources.ADMIN1
        Me.PictureBox2.Location = New System.Drawing.Point(0, 28)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(310, 105)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 12
        Me.PictureBox2.TabStop = False
        '
        'btDiscount
        '
        Me.btDiscount.BackColor = System.Drawing.Color.DimGray
        Me.btDiscount.Font = New System.Drawing.Font("Palatino Linotype", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btDiscount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btDiscount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btDiscount.Location = New System.Drawing.Point(703, 382)
        Me.btDiscount.Name = "btDiscount"
        Me.btDiscount.Size = New System.Drawing.Size(222, 67)
        Me.btDiscount.TabIndex = 3
        Me.btDiscount.Text = "Edit Discount"
        Me.btDiscount.UseVisualStyleBackColor = False
        '
        'tbDisc
        '
        Me.tbDisc.Location = New System.Drawing.Point(795, 341)
        Me.tbDisc.Name = "tbDisc"
        Me.tbDisc.Size = New System.Drawing.Size(130, 20)
        Me.tbDisc.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(699, 341)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 20)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Discount %"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(384, 296)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 24)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Tax %"
        '
        'LabelTax
        '
        Me.LabelTax.AutoSize = True
        Me.LabelTax.BackColor = System.Drawing.Color.Transparent
        Me.LabelTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTax.Location = New System.Drawing.Point(465, 296)
        Me.LabelTax.Name = "LabelTax"
        Me.LabelTax.Size = New System.Drawing.Size(67, 24)
        Me.LabelTax.TabIndex = 18
        Me.LabelTax.Text = "Tax %"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(698, 296)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 24)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Discount %"
        '
        'LabelDisc
        '
        Me.LabelDisc.AutoSize = True
        Me.LabelDisc.BackColor = System.Drawing.Color.Transparent
        Me.LabelDisc.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDisc.Location = New System.Drawing.Point(816, 296)
        Me.LabelDisc.Name = "LabelDisc"
        Me.LabelDisc.Size = New System.Drawing.Size(113, 24)
        Me.LabelDisc.TabIndex = 20
        Me.LabelDisc.Text = "Discount %"
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.professional_painting_contractors_affiliates_background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1315, 591)
        Me.Controls.Add(Me.LabelDisc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LabelTax)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btDiscount)
        Me.Controls.Add(Me.tbDisc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btInvoice)
        Me.Controls.Add(Me.btTax)
        Me.Controls.Add(Me.tbTax)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btreport)
        Me.Controls.Add(Me.btexit)
        Me.Controls.Add(Me.btstock)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Home"
        Me.Text = "Home"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Table1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnoopDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btstock As System.Windows.Forms.Button
    Friend WithEvents btexit As System.Windows.Forms.Button
    Friend WithEvents btreport As System.Windows.Forms.Button
    Friend WithEvents AnoopDataSet As WindowsApplication1.AnoopDataSet
    Friend WithEvents Table1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Table1TableAdapter As WindowsApplication1.AnoopDataSetTableAdapters.Table1TableAdapter
    Friend WithEvents EditDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeleteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbTax As System.Windows.Forms.TextBox
    Friend WithEvents btTax As System.Windows.Forms.Button
    Friend WithEvents btInvoice As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btDiscount As System.Windows.Forms.Button
    Friend WithEvents tbDisc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LabelTax As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LabelDisc As System.Windows.Forms.Label
End Class
