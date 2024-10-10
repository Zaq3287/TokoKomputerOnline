<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_menu_admin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_menu_admin))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblToko = New System.Windows.Forms.Label()
        Me.lblOnline = New System.Windows.Forms.Label()
        Me.bgw = New System.ComponentModel.BackgroundWorker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.btnDataServis = New System.Windows.Forms.Button()
        Me.panOnline = New System.Windows.Forms.Panel()
        Me.btnDataJual = New System.Windows.Forms.Button()
        Me.lblHari = New System.Windows.Forms.Label()
        Me.lblBulan = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPLunasHari = New System.Windows.Forms.Label()
        Me.lblPLunasBulan = New System.Windows.Forms.Label()
        Me.lblPATMBulan = New System.Windows.Forms.Label()
        Me.lblPATMHari = New System.Windows.Forms.Label()
        Me.lblPTempoBulan = New System.Windows.Forms.Label()
        Me.lblPTempoHari = New System.Windows.Forms.Label()
        Me.lblSTempoBulan = New System.Windows.Forms.Label()
        Me.lblSTempoHari = New System.Windows.Forms.Label()
        Me.lblSATMBulan = New System.Windows.Forms.Label()
        Me.lblSATMHari = New System.Windows.Forms.Label()
        Me.lblSLunasBulan = New System.Windows.Forms.Label()
        Me.lblSLunasHari = New System.Windows.Forms.Label()
        Me.lblLKeluarBulan = New System.Windows.Forms.Label()
        Me.lblLKeluarHari = New System.Windows.Forms.Label()
        Me.lblLMasukBulan = New System.Windows.Forms.Label()
        Me.lblLMasukHari = New System.Windows.Forms.Label()
        Me.lblCTotalBulan = New System.Windows.Forms.Label()
        Me.lblCTotalHari = New System.Windows.Forms.Label()
        Me.lblCKeluarBulan = New System.Windows.Forms.Label()
        Me.lblCKeluarHari = New System.Windows.Forms.Label()
        Me.lblCMasukBulan = New System.Windows.Forms.Label()
        Me.lblCMasukHari = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.pLaporan = New System.Windows.Forms.Panel()
        Me.btnDataLainnya = New System.Windows.Forms.Button()
        Me.dtTanggal = New System.Windows.Forms.DateTimePicker()
        Me.bgwLaporan = New System.ComponentModel.BackgroundWorker()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbShow = New System.Windows.Forms.ComboBox()
        Me.btnKaryawan = New System.Windows.Forms.Button()
        Me.btnPelanggan = New System.Windows.Forms.Button()
        Me.btnJualTempo = New System.Windows.Forms.Button()
        Me.btnBarang = New System.Windows.Forms.Button()
        Me.btnInfo = New System.Windows.Forms.Button()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.lblPendapatanBulan = New System.Windows.Forms.Label()
        Me.lblPendapatanHari = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblPendapatanTahun = New System.Windows.Forms.Label()
        Me.lblCTotalTahun = New System.Windows.Forms.Label()
        Me.lblCKeluarTahun = New System.Windows.Forms.Label()
        Me.lblCMasukTahun = New System.Windows.Forms.Label()
        Me.lblLKeluarTahun = New System.Windows.Forms.Label()
        Me.lblLMasukTahun = New System.Windows.Forms.Label()
        Me.lblSTempoTahun = New System.Windows.Forms.Label()
        Me.lblSATMTahun = New System.Windows.Forms.Label()
        Me.lblSLunasTahun = New System.Windows.Forms.Label()
        Me.lblPTempoTahun = New System.Windows.Forms.Label()
        Me.lblPATMTahun = New System.Windows.Forms.Label()
        Me.lblPLunasTahun = New System.Windows.Forms.Label()
        Me.lblTahun = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.panOnline.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.Controls.Add(Me.lblStatus)
        Me.Panel1.Controls.Add(Me.lblToko)
        Me.Panel1.Location = New System.Drawing.Point(0, 416)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(594, 24)
        Me.Panel1.TabIndex = 0
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(171, 5)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(32, 13)
        Me.lblStatus.TabIndex = 1
        Me.lblStatus.Text = "Error!"
        '
        'lblToko
        '
        Me.lblToko.AutoSize = True
        Me.lblToko.Location = New System.Drawing.Point(9, 5)
        Me.lblToko.Name = "lblToko"
        Me.lblToko.Size = New System.Drawing.Size(52, 13)
        Me.lblToko.TabIndex = 0
        Me.lblToko.Text = "Wonosari"
        '
        'lblOnline
        '
        Me.lblOnline.AutoSize = True
        Me.lblOnline.Location = New System.Drawing.Point(26, 5)
        Me.lblOnline.Name = "lblOnline"
        Me.lblOnline.Size = New System.Drawing.Size(35, 13)
        Me.lblOnline.TabIndex = 0
        Me.lblOnline.Text = "wait..."
        '
        'bgw
        '
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblSaldo)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(675, 48)
        Me.Panel2.TabIndex = 1
        '
        'lblSaldo
        '
        Me.lblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.Location = New System.Drawing.Point(366, 7)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(296, 39)
        Me.lblSaldo.TabIndex = 0
        Me.lblSaldo.Text = "Saldo: Rp. 1.000.000,-"
        Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnDataServis
        '
        Me.btnDataServis.BackColor = System.Drawing.Color.White
        Me.btnDataServis.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDataServis.Location = New System.Drawing.Point(12, 186)
        Me.btnDataServis.Name = "btnDataServis"
        Me.btnDataServis.Size = New System.Drawing.Size(131, 38)
        Me.btnDataServis.TabIndex = 3
        Me.btnDataServis.Text = "Servis"
        Me.btnDataServis.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDataServis.UseVisualStyleBackColor = False
        '
        'panOnline
        '
        Me.panOnline.Controls.Add(Me.lblOnline)
        Me.panOnline.Location = New System.Drawing.Point(591, 416)
        Me.panOnline.Name = "panOnline"
        Me.panOnline.Size = New System.Drawing.Size(84, 24)
        Me.panOnline.TabIndex = 10
        '
        'btnDataJual
        '
        Me.btnDataJual.BackColor = System.Drawing.Color.White
        Me.btnDataJual.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDataJual.Location = New System.Drawing.Point(12, 98)
        Me.btnDataJual.Name = "btnDataJual"
        Me.btnDataJual.Size = New System.Drawing.Size(131, 38)
        Me.btnDataJual.TabIndex = 1
        Me.btnDataJual.Text = "Penjualan"
        Me.btnDataJual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDataJual.UseVisualStyleBackColor = False
        '
        'lblHari
        '
        Me.lblHari.BackColor = System.Drawing.Color.Bisque
        Me.lblHari.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHari.Location = New System.Drawing.Point(171, 77)
        Me.lblHari.Name = "lblHari"
        Me.lblHari.Size = New System.Drawing.Size(240, 23)
        Me.lblHari.TabIndex = 13
        Me.lblHari.Text = "[23 September 2024]"
        Me.lblHari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBulan
        '
        Me.lblBulan.BackColor = System.Drawing.Color.Bisque
        Me.lblBulan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBulan.Location = New System.Drawing.Point(411, 77)
        Me.lblBulan.Name = "lblBulan"
        Me.lblBulan.Size = New System.Drawing.Size(124, 23)
        Me.lblBulan.TabIndex = 14
        Me.lblBulan.Text = "[September 2024]"
        Me.lblBulan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Silver
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(171, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(488, 23)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = " Laporan"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPLunasHari
        '
        Me.lblPLunasHari.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblPLunasHari.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPLunasHari.Location = New System.Drawing.Point(291, 100)
        Me.lblPLunasHari.Name = "lblPLunasHari"
        Me.lblPLunasHari.Size = New System.Drawing.Size(117, 23)
        Me.lblPLunasHari.TabIndex = 17
        Me.lblPLunasHari.Text = "20,000,000"
        Me.lblPLunasHari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPLunasBulan
        '
        Me.lblPLunasBulan.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblPLunasBulan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPLunasBulan.Location = New System.Drawing.Point(408, 100)
        Me.lblPLunasBulan.Name = "lblPLunasBulan"
        Me.lblPLunasBulan.Size = New System.Drawing.Size(127, 23)
        Me.lblPLunasBulan.TabIndex = 18
        Me.lblPLunasBulan.Text = "20,000,000"
        Me.lblPLunasBulan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPATMBulan
        '
        Me.lblPATMBulan.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblPATMBulan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPATMBulan.Location = New System.Drawing.Point(408, 123)
        Me.lblPATMBulan.Name = "lblPATMBulan"
        Me.lblPATMBulan.Size = New System.Drawing.Size(127, 23)
        Me.lblPATMBulan.TabIndex = 21
        Me.lblPATMBulan.Text = "20,000,000"
        Me.lblPATMBulan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPATMHari
        '
        Me.lblPATMHari.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblPATMHari.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPATMHari.Location = New System.Drawing.Point(291, 123)
        Me.lblPATMHari.Name = "lblPATMHari"
        Me.lblPATMHari.Size = New System.Drawing.Size(117, 23)
        Me.lblPATMHari.TabIndex = 20
        Me.lblPATMHari.Text = "20,000,000"
        Me.lblPATMHari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPTempoBulan
        '
        Me.lblPTempoBulan.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblPTempoBulan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPTempoBulan.Location = New System.Drawing.Point(408, 146)
        Me.lblPTempoBulan.Name = "lblPTempoBulan"
        Me.lblPTempoBulan.Size = New System.Drawing.Size(127, 23)
        Me.lblPTempoBulan.TabIndex = 24
        Me.lblPTempoBulan.Text = "20,000,000"
        Me.lblPTempoBulan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPTempoHari
        '
        Me.lblPTempoHari.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblPTempoHari.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPTempoHari.Location = New System.Drawing.Point(291, 146)
        Me.lblPTempoHari.Name = "lblPTempoHari"
        Me.lblPTempoHari.Size = New System.Drawing.Size(117, 23)
        Me.lblPTempoHari.TabIndex = 23
        Me.lblPTempoHari.Text = "20,000,000"
        Me.lblPTempoHari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSTempoBulan
        '
        Me.lblSTempoBulan.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblSTempoBulan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSTempoBulan.Location = New System.Drawing.Point(408, 215)
        Me.lblSTempoBulan.Name = "lblSTempoBulan"
        Me.lblSTempoBulan.Size = New System.Drawing.Size(127, 23)
        Me.lblSTempoBulan.TabIndex = 33
        Me.lblSTempoBulan.Text = "20,000,000"
        Me.lblSTempoBulan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSTempoHari
        '
        Me.lblSTempoHari.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblSTempoHari.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSTempoHari.Location = New System.Drawing.Point(291, 215)
        Me.lblSTempoHari.Name = "lblSTempoHari"
        Me.lblSTempoHari.Size = New System.Drawing.Size(117, 23)
        Me.lblSTempoHari.TabIndex = 32
        Me.lblSTempoHari.Text = "20,000,000"
        Me.lblSTempoHari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSATMBulan
        '
        Me.lblSATMBulan.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblSATMBulan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSATMBulan.Location = New System.Drawing.Point(408, 192)
        Me.lblSATMBulan.Name = "lblSATMBulan"
        Me.lblSATMBulan.Size = New System.Drawing.Size(127, 23)
        Me.lblSATMBulan.TabIndex = 30
        Me.lblSATMBulan.Text = "20,000,000"
        Me.lblSATMBulan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSATMHari
        '
        Me.lblSATMHari.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblSATMHari.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSATMHari.Location = New System.Drawing.Point(291, 192)
        Me.lblSATMHari.Name = "lblSATMHari"
        Me.lblSATMHari.Size = New System.Drawing.Size(117, 23)
        Me.lblSATMHari.TabIndex = 29
        Me.lblSATMHari.Text = "20,000,000"
        Me.lblSATMHari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSLunasBulan
        '
        Me.lblSLunasBulan.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblSLunasBulan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSLunasBulan.Location = New System.Drawing.Point(408, 169)
        Me.lblSLunasBulan.Name = "lblSLunasBulan"
        Me.lblSLunasBulan.Size = New System.Drawing.Size(127, 23)
        Me.lblSLunasBulan.TabIndex = 27
        Me.lblSLunasBulan.Text = "20,000,000"
        Me.lblSLunasBulan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSLunasHari
        '
        Me.lblSLunasHari.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblSLunasHari.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSLunasHari.Location = New System.Drawing.Point(291, 169)
        Me.lblSLunasHari.Name = "lblSLunasHari"
        Me.lblSLunasHari.Size = New System.Drawing.Size(117, 23)
        Me.lblSLunasHari.TabIndex = 26
        Me.lblSLunasHari.Text = "20,000,000"
        Me.lblSLunasHari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLKeluarBulan
        '
        Me.lblLKeluarBulan.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblLKeluarBulan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLKeluarBulan.Location = New System.Drawing.Point(408, 261)
        Me.lblLKeluarBulan.Name = "lblLKeluarBulan"
        Me.lblLKeluarBulan.Size = New System.Drawing.Size(127, 23)
        Me.lblLKeluarBulan.TabIndex = 39
        Me.lblLKeluarBulan.Text = "20,000,000"
        Me.lblLKeluarBulan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLKeluarHari
        '
        Me.lblLKeluarHari.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblLKeluarHari.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLKeluarHari.Location = New System.Drawing.Point(291, 261)
        Me.lblLKeluarHari.Name = "lblLKeluarHari"
        Me.lblLKeluarHari.Size = New System.Drawing.Size(117, 23)
        Me.lblLKeluarHari.TabIndex = 38
        Me.lblLKeluarHari.Text = "20,000,000"
        Me.lblLKeluarHari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLMasukBulan
        '
        Me.lblLMasukBulan.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblLMasukBulan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLMasukBulan.Location = New System.Drawing.Point(408, 238)
        Me.lblLMasukBulan.Name = "lblLMasukBulan"
        Me.lblLMasukBulan.Size = New System.Drawing.Size(127, 23)
        Me.lblLMasukBulan.TabIndex = 36
        Me.lblLMasukBulan.Text = "20,000,000"
        Me.lblLMasukBulan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLMasukHari
        '
        Me.lblLMasukHari.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblLMasukHari.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLMasukHari.Location = New System.Drawing.Point(291, 238)
        Me.lblLMasukHari.Name = "lblLMasukHari"
        Me.lblLMasukHari.Size = New System.Drawing.Size(117, 23)
        Me.lblLMasukHari.TabIndex = 35
        Me.lblLMasukHari.Text = "20,000,000"
        Me.lblLMasukHari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCTotalBulan
        '
        Me.lblCTotalBulan.BackColor = System.Drawing.Color.Beige
        Me.lblCTotalBulan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTotalBulan.Location = New System.Drawing.Point(408, 330)
        Me.lblCTotalBulan.Name = "lblCTotalBulan"
        Me.lblCTotalBulan.Size = New System.Drawing.Size(127, 23)
        Me.lblCTotalBulan.TabIndex = 48
        Me.lblCTotalBulan.Text = "20,000,000"
        Me.lblCTotalBulan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCTotalHari
        '
        Me.lblCTotalHari.BackColor = System.Drawing.Color.Beige
        Me.lblCTotalHari.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTotalHari.Location = New System.Drawing.Point(291, 330)
        Me.lblCTotalHari.Name = "lblCTotalHari"
        Me.lblCTotalHari.Size = New System.Drawing.Size(117, 23)
        Me.lblCTotalHari.TabIndex = 47
        Me.lblCTotalHari.Text = "20,000,000"
        Me.lblCTotalHari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCKeluarBulan
        '
        Me.lblCKeluarBulan.BackColor = System.Drawing.Color.Beige
        Me.lblCKeluarBulan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCKeluarBulan.Location = New System.Drawing.Point(408, 307)
        Me.lblCKeluarBulan.Name = "lblCKeluarBulan"
        Me.lblCKeluarBulan.Size = New System.Drawing.Size(127, 23)
        Me.lblCKeluarBulan.TabIndex = 45
        Me.lblCKeluarBulan.Text = "20,000,000"
        Me.lblCKeluarBulan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCKeluarHari
        '
        Me.lblCKeluarHari.BackColor = System.Drawing.Color.Beige
        Me.lblCKeluarHari.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCKeluarHari.Location = New System.Drawing.Point(291, 307)
        Me.lblCKeluarHari.Name = "lblCKeluarHari"
        Me.lblCKeluarHari.Size = New System.Drawing.Size(117, 23)
        Me.lblCKeluarHari.TabIndex = 44
        Me.lblCKeluarHari.Text = "20,000,000"
        Me.lblCKeluarHari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCMasukBulan
        '
        Me.lblCMasukBulan.BackColor = System.Drawing.Color.Beige
        Me.lblCMasukBulan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCMasukBulan.Location = New System.Drawing.Point(408, 284)
        Me.lblCMasukBulan.Name = "lblCMasukBulan"
        Me.lblCMasukBulan.Size = New System.Drawing.Size(127, 23)
        Me.lblCMasukBulan.TabIndex = 42
        Me.lblCMasukBulan.Text = "20,000,000"
        Me.lblCMasukBulan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCMasukHari
        '
        Me.lblCMasukHari.BackColor = System.Drawing.Color.Beige
        Me.lblCMasukHari.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCMasukHari.Location = New System.Drawing.Point(291, 284)
        Me.lblCMasukHari.Name = "lblCMasukHari"
        Me.lblCMasukHari.Size = New System.Drawing.Size(117, 23)
        Me.lblCMasukHari.TabIndex = 41
        Me.lblCMasukHari.Text = "20,000,000"
        Me.lblCMasukHari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(171, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 23)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Penjualan lunas: "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(171, 123)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 23)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Penjualan ATM : "
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(171, 146)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 23)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Penjualan tempo:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(171, 169)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(120, 23)
        Me.Label21.TabIndex = 25
        Me.Label21.Text = "Servis lunas: "
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(171, 192)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(120, 23)
        Me.Label18.TabIndex = 28
        Me.Label18.Text = "Servis ATM:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(171, 215)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 23)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Servis tempo:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(171, 238)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(120, 23)
        Me.Label27.TabIndex = 34
        Me.Label27.Text = "Lain masuk:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(171, 261)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(120, 23)
        Me.Label24.TabIndex = 37
        Me.Label24.Text = "Lain keluar:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Beige
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(171, 284)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(120, 23)
        Me.Label36.TabIndex = 40
        Me.Label36.Text = "Cash masuk:"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Beige
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(171, 307)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(120, 23)
        Me.Label33.TabIndex = 43
        Me.Label33.Text = "Cash keluar:"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Beige
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(171, 330)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(120, 23)
        Me.Label30.TabIndex = 46
        Me.Label30.Text = "Total:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pLaporan
        '
        Me.pLaporan.Location = New System.Drawing.Point(164, 54)
        Me.pLaporan.Name = "pLaporan"
        Me.pLaporan.Size = New System.Drawing.Size(509, 322)
        Me.pLaporan.TabIndex = 49
        '
        'btnDataLainnya
        '
        Me.btnDataLainnya.BackColor = System.Drawing.Color.White
        Me.btnDataLainnya.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDataLainnya.Location = New System.Drawing.Point(12, 229)
        Me.btnDataLainnya.Name = "btnDataLainnya"
        Me.btnDataLainnya.Size = New System.Drawing.Size(131, 38)
        Me.btnDataLainnya.TabIndex = 4
        Me.btnDataLainnya.Text = "Lainnya"
        Me.btnDataLainnya.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDataLainnya.UseVisualStyleBackColor = False
        '
        'dtTanggal
        '
        Me.dtTanggal.CalendarMonthBackground = System.Drawing.Color.Tomato
        Me.dtTanggal.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtTanggal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTanggal.Location = New System.Drawing.Point(217, 80)
        Me.dtTanggal.Name = "dtTanggal"
        Me.dtTanggal.Size = New System.Drawing.Size(48, 20)
        Me.dtTanggal.TabIndex = 52
        '
        'bgwLaporan
        '
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Bisque
        Me.Panel3.Location = New System.Drawing.Point(213, 77)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(35, 23)
        Me.Panel3.TabIndex = 53
        '
        'cmbShow
        '
        Me.cmbShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbShow.FormattingEnabled = True
        Me.cmbShow.Location = New System.Drawing.Point(174, 79)
        Me.cmbShow.Name = "cmbShow"
        Me.cmbShow.Size = New System.Drawing.Size(68, 21)
        Me.cmbShow.TabIndex = 54
        Me.cmbShow.TabStop = False
        '
        'btnKaryawan
        '
        Me.btnKaryawan.BackColor = System.Drawing.Color.White
        Me.btnKaryawan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKaryawan.Location = New System.Drawing.Point(12, 273)
        Me.btnKaryawan.Name = "btnKaryawan"
        Me.btnKaryawan.Size = New System.Drawing.Size(131, 38)
        Me.btnKaryawan.TabIndex = 5
        Me.btnKaryawan.Text = "Karyawan"
        Me.btnKaryawan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKaryawan.UseVisualStyleBackColor = False
        '
        'btnPelanggan
        '
        Me.btnPelanggan.BackColor = System.Drawing.Color.White
        Me.btnPelanggan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPelanggan.Location = New System.Drawing.Point(12, 317)
        Me.btnPelanggan.Name = "btnPelanggan"
        Me.btnPelanggan.Size = New System.Drawing.Size(131, 38)
        Me.btnPelanggan.TabIndex = 6
        Me.btnPelanggan.Text = "Pelanggan"
        Me.btnPelanggan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPelanggan.UseVisualStyleBackColor = False
        '
        'btnJualTempo
        '
        Me.btnJualTempo.BackColor = System.Drawing.Color.White
        Me.btnJualTempo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJualTempo.Location = New System.Drawing.Point(12, 142)
        Me.btnJualTempo.Name = "btnJualTempo"
        Me.btnJualTempo.Size = New System.Drawing.Size(131, 38)
        Me.btnJualTempo.TabIndex = 2
        Me.btnJualTempo.Text = "Jual tempo"
        Me.btnJualTempo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnJualTempo.UseVisualStyleBackColor = False
        '
        'btnBarang
        '
        Me.btnBarang.BackColor = System.Drawing.Color.White
        Me.btnBarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBarang.Location = New System.Drawing.Point(12, 54)
        Me.btnBarang.Name = "btnBarang"
        Me.btnBarang.Size = New System.Drawing.Size(131, 38)
        Me.btnBarang.TabIndex = 0
        Me.btnBarang.Text = "Barang"
        Me.btnBarang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBarang.UseVisualStyleBackColor = False
        '
        'btnInfo
        '
        Me.btnInfo.BackgroundImage = Global.TokoVBNet.My.Resources.Resources.info
        Me.btnInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnInfo.Location = New System.Drawing.Point(575, 381)
        Me.btnInfo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnInfo.Name = "btnInfo"
        Me.btnInfo.Size = New System.Drawing.Size(30, 30)
        Me.btnInfo.TabIndex = 7
        Me.btnInfo.TabStop = False
        Me.btnInfo.UseVisualStyleBackColor = True
        '
        'btnChange
        '
        Me.btnChange.BackgroundImage = Global.TokoVBNet.My.Resources.Resources.refresh
        Me.btnChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnChange.Location = New System.Drawing.Point(609, 381)
        Me.btnChange.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(30, 30)
        Me.btnChange.TabIndex = 8
        Me.btnChange.TabStop = False
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox7.Image = Global.TokoVBNet.My.Resources.Resources.presentation
        Me.PictureBox7.InitialImage = Nothing
        Me.PictureBox7.Location = New System.Drawing.Point(18, 61)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox7.TabIndex = 62
        Me.PictureBox7.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Image = Global.TokoVBNet.My.Resources.Resources.presentation
        Me.PictureBox6.InitialImage = Nothing
        Me.PictureBox6.Location = New System.Drawing.Point(18, 149)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 60
        Me.PictureBox6.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = Global.TokoVBNet.My.Resources.Resources.presentation
        Me.PictureBox5.InitialImage = Nothing
        Me.PictureBox5.Location = New System.Drawing.Point(18, 324)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 58
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.TokoVBNet.My.Resources.Resources.presentation
        Me.PictureBox4.InitialImage = Nothing
        Me.PictureBox4.Location = New System.Drawing.Point(18, 280)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 56
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.TokoVBNet.My.Resources.Resources.presentation
        Me.PictureBox3.InitialImage = Nothing
        Me.PictureBox3.Location = New System.Drawing.Point(18, 236)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 51
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.TokoVBNet.My.Resources.Resources.presentation
        Me.PictureBox2.InitialImage = Nothing
        Me.PictureBox2.Location = New System.Drawing.Point(18, 105)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 12
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.TokoVBNet.My.Resources.Resources.presentation
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(18, 193)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'btnHome
        '
        Me.btnHome.BackgroundImage = Global.TokoVBNet.My.Resources.Resources._exit
        Me.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnHome.Location = New System.Drawing.Point(643, 381)
        Me.btnHome.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(30, 30)
        Me.btnHome.TabIndex = 9
        Me.btnHome.TabStop = False
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'lblPendapatanBulan
        '
        Me.lblPendapatanBulan.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.lblPendapatanBulan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendapatanBulan.Location = New System.Drawing.Point(408, 353)
        Me.lblPendapatanBulan.Name = "lblPendapatanBulan"
        Me.lblPendapatanBulan.Size = New System.Drawing.Size(127, 23)
        Me.lblPendapatanBulan.TabIndex = 65
        Me.lblPendapatanBulan.Text = "20,000,000"
        Me.lblPendapatanBulan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPendapatanHari
        '
        Me.lblPendapatanHari.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.lblPendapatanHari.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendapatanHari.Location = New System.Drawing.Point(291, 353)
        Me.lblPendapatanHari.Name = "lblPendapatanHari"
        Me.lblPendapatanHari.Size = New System.Drawing.Size(117, 23)
        Me.lblPendapatanHari.TabIndex = 64
        Me.lblPendapatanHari.Text = "20,000,000"
        Me.lblPendapatanHari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(171, 353)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 23)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "Pendapatan:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPendapatanTahun
        '
        Me.lblPendapatanTahun.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.lblPendapatanTahun.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendapatanTahun.Location = New System.Drawing.Point(532, 353)
        Me.lblPendapatanTahun.Name = "lblPendapatanTahun"
        Me.lblPendapatanTahun.Size = New System.Drawing.Size(127, 23)
        Me.lblPendapatanTahun.TabIndex = 78
        Me.lblPendapatanTahun.Text = "20,000,000"
        Me.lblPendapatanTahun.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCTotalTahun
        '
        Me.lblCTotalTahun.BackColor = System.Drawing.Color.Beige
        Me.lblCTotalTahun.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTotalTahun.Location = New System.Drawing.Point(532, 330)
        Me.lblCTotalTahun.Name = "lblCTotalTahun"
        Me.lblCTotalTahun.Size = New System.Drawing.Size(127, 23)
        Me.lblCTotalTahun.TabIndex = 77
        Me.lblCTotalTahun.Text = "20,000,000"
        Me.lblCTotalTahun.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCKeluarTahun
        '
        Me.lblCKeluarTahun.BackColor = System.Drawing.Color.Beige
        Me.lblCKeluarTahun.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCKeluarTahun.Location = New System.Drawing.Point(532, 307)
        Me.lblCKeluarTahun.Name = "lblCKeluarTahun"
        Me.lblCKeluarTahun.Size = New System.Drawing.Size(127, 23)
        Me.lblCKeluarTahun.TabIndex = 76
        Me.lblCKeluarTahun.Text = "20,000,000"
        Me.lblCKeluarTahun.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCMasukTahun
        '
        Me.lblCMasukTahun.BackColor = System.Drawing.Color.Beige
        Me.lblCMasukTahun.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCMasukTahun.Location = New System.Drawing.Point(532, 284)
        Me.lblCMasukTahun.Name = "lblCMasukTahun"
        Me.lblCMasukTahun.Size = New System.Drawing.Size(127, 23)
        Me.lblCMasukTahun.TabIndex = 75
        Me.lblCMasukTahun.Text = "20,000,000"
        Me.lblCMasukTahun.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLKeluarTahun
        '
        Me.lblLKeluarTahun.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblLKeluarTahun.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLKeluarTahun.Location = New System.Drawing.Point(532, 261)
        Me.lblLKeluarTahun.Name = "lblLKeluarTahun"
        Me.lblLKeluarTahun.Size = New System.Drawing.Size(127, 23)
        Me.lblLKeluarTahun.TabIndex = 74
        Me.lblLKeluarTahun.Text = "20,000,000"
        Me.lblLKeluarTahun.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLMasukTahun
        '
        Me.lblLMasukTahun.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblLMasukTahun.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLMasukTahun.Location = New System.Drawing.Point(532, 238)
        Me.lblLMasukTahun.Name = "lblLMasukTahun"
        Me.lblLMasukTahun.Size = New System.Drawing.Size(127, 23)
        Me.lblLMasukTahun.TabIndex = 73
        Me.lblLMasukTahun.Text = "20,000,000"
        Me.lblLMasukTahun.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSTempoTahun
        '
        Me.lblSTempoTahun.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblSTempoTahun.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSTempoTahun.Location = New System.Drawing.Point(532, 215)
        Me.lblSTempoTahun.Name = "lblSTempoTahun"
        Me.lblSTempoTahun.Size = New System.Drawing.Size(127, 23)
        Me.lblSTempoTahun.TabIndex = 72
        Me.lblSTempoTahun.Text = "20,000,000"
        Me.lblSTempoTahun.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSATMTahun
        '
        Me.lblSATMTahun.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblSATMTahun.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSATMTahun.Location = New System.Drawing.Point(532, 192)
        Me.lblSATMTahun.Name = "lblSATMTahun"
        Me.lblSATMTahun.Size = New System.Drawing.Size(127, 23)
        Me.lblSATMTahun.TabIndex = 71
        Me.lblSATMTahun.Text = "20,000,000"
        Me.lblSATMTahun.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSLunasTahun
        '
        Me.lblSLunasTahun.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblSLunasTahun.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSLunasTahun.Location = New System.Drawing.Point(532, 169)
        Me.lblSLunasTahun.Name = "lblSLunasTahun"
        Me.lblSLunasTahun.Size = New System.Drawing.Size(127, 23)
        Me.lblSLunasTahun.TabIndex = 70
        Me.lblSLunasTahun.Text = "20,000,000"
        Me.lblSLunasTahun.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPTempoTahun
        '
        Me.lblPTempoTahun.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblPTempoTahun.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPTempoTahun.Location = New System.Drawing.Point(532, 146)
        Me.lblPTempoTahun.Name = "lblPTempoTahun"
        Me.lblPTempoTahun.Size = New System.Drawing.Size(127, 23)
        Me.lblPTempoTahun.TabIndex = 69
        Me.lblPTempoTahun.Text = "20,000,000"
        Me.lblPTempoTahun.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPATMTahun
        '
        Me.lblPATMTahun.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblPATMTahun.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPATMTahun.Location = New System.Drawing.Point(532, 123)
        Me.lblPATMTahun.Name = "lblPATMTahun"
        Me.lblPATMTahun.Size = New System.Drawing.Size(127, 23)
        Me.lblPATMTahun.TabIndex = 68
        Me.lblPATMTahun.Text = "20,000,000"
        Me.lblPATMTahun.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPLunasTahun
        '
        Me.lblPLunasTahun.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblPLunasTahun.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPLunasTahun.Location = New System.Drawing.Point(532, 100)
        Me.lblPLunasTahun.Name = "lblPLunasTahun"
        Me.lblPLunasTahun.Size = New System.Drawing.Size(127, 23)
        Me.lblPLunasTahun.TabIndex = 67
        Me.lblPLunasTahun.Text = "20,000,000"
        Me.lblPLunasTahun.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTahun
        '
        Me.lblTahun.BackColor = System.Drawing.Color.Bisque
        Me.lblTahun.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTahun.Location = New System.Drawing.Point(535, 77)
        Me.lblTahun.Name = "lblTahun"
        Me.lblTahun.Size = New System.Drawing.Size(124, 23)
        Me.lblTahun.TabIndex = 66
        Me.lblTahun.Text = "[2024]"
        Me.lblTahun.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(542, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 23)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "Tahun"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(418, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 23)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Bulan"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Silver
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(291, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 23)
        Me.Label6.TabIndex = 81
        Me.Label6.Text = "Tanggal"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_menu_admin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(675, 441)
        Me.Controls.Add(Me.pLaporan)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblPendapatanTahun)
        Me.Controls.Add(Me.lblCTotalTahun)
        Me.Controls.Add(Me.lblCKeluarTahun)
        Me.Controls.Add(Me.lblCMasukTahun)
        Me.Controls.Add(Me.lblLKeluarTahun)
        Me.Controls.Add(Me.lblLMasukTahun)
        Me.Controls.Add(Me.lblSTempoTahun)
        Me.Controls.Add(Me.lblSATMTahun)
        Me.Controls.Add(Me.lblSLunasTahun)
        Me.Controls.Add(Me.lblPTempoTahun)
        Me.Controls.Add(Me.lblPATMTahun)
        Me.Controls.Add(Me.lblPLunasTahun)
        Me.Controls.Add(Me.lblTahun)
        Me.Controls.Add(Me.lblPendapatanBulan)
        Me.Controls.Add(Me.lblPendapatanHari)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnInfo)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.btnBarang)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.btnJualTempo)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.btnPelanggan)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.btnKaryawan)
        Me.Controls.Add(Me.cmbShow)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.dtTanggal)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.btnDataLainnya)
        Me.Controls.Add(Me.lblCTotalBulan)
        Me.Controls.Add(Me.lblCTotalHari)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.lblCKeluarBulan)
        Me.Controls.Add(Me.lblCKeluarHari)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.lblCMasukBulan)
        Me.Controls.Add(Me.lblCMasukHari)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.lblLKeluarBulan)
        Me.Controls.Add(Me.lblLKeluarHari)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.lblLMasukBulan)
        Me.Controls.Add(Me.lblLMasukHari)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.lblSTempoBulan)
        Me.Controls.Add(Me.lblSTempoHari)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblSATMBulan)
        Me.Controls.Add(Me.lblSATMHari)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblSLunasBulan)
        Me.Controls.Add(Me.lblSLunasHari)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.lblPTempoBulan)
        Me.Controls.Add(Me.lblPTempoHari)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblPATMBulan)
        Me.Controls.Add(Me.lblPATMHari)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblPLunasBulan)
        Me.Controls.Add(Me.lblPLunasHari)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblBulan)
        Me.Controls.Add(Me.lblHari)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.btnDataJual)
        Me.Controls.Add(Me.panOnline)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.btnDataServis)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_menu_admin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_menu_admin"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.panOnline.ResumeLayout(False)
        Me.panOnline.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblOnline As Label
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblSaldo As Label
    Friend WithEvents btnDataServis As Button
    Friend WithEvents btnHome As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents panOnline As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnDataJual As Button
    Friend WithEvents lblHari As Label
    Friend WithEvents lblBulan As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblPLunasHari As Label
    Friend WithEvents lblPLunasBulan As Label
    Friend WithEvents lblPATMBulan As Label
    Friend WithEvents lblPATMHari As Label
    Friend WithEvents lblPTempoBulan As Label
    Friend WithEvents lblPTempoHari As Label
    Friend WithEvents lblSTempoBulan As Label
    Friend WithEvents lblSTempoHari As Label
    Friend WithEvents lblSATMBulan As Label
    Friend WithEvents lblSATMHari As Label
    Friend WithEvents lblSLunasBulan As Label
    Friend WithEvents lblSLunasHari As Label
    Friend WithEvents lblLKeluarBulan As Label
    Friend WithEvents lblLKeluarHari As Label
    Friend WithEvents lblLMasukBulan As Label
    Friend WithEvents lblLMasukHari As Label
    Friend WithEvents lblCTotalBulan As Label
    Friend WithEvents lblCTotalHari As Label
    Friend WithEvents lblCKeluarBulan As Label
    Friend WithEvents lblCKeluarHari As Label
    Friend WithEvents lblCMasukBulan As Label
    Friend WithEvents lblCMasukHari As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents pLaporan As Panel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents btnDataLainnya As Button
    Friend WithEvents dtTanggal As DateTimePicker
    Friend WithEvents bgwLaporan As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cmbShow As ComboBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents btnKaryawan As Button
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents btnPelanggan As Button
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents btnJualTempo As Button
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents btnBarang As Button
    Friend WithEvents btnChange As Button
    Friend WithEvents btnInfo As Button
    Friend WithEvents lblToko As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblPendapatanBulan As Label
    Friend WithEvents lblPendapatanHari As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblPendapatanTahun As Label
    Friend WithEvents lblCTotalTahun As Label
    Friend WithEvents lblCKeluarTahun As Label
    Friend WithEvents lblCMasukTahun As Label
    Friend WithEvents lblLKeluarTahun As Label
    Friend WithEvents lblLMasukTahun As Label
    Friend WithEvents lblSTempoTahun As Label
    Friend WithEvents lblSATMTahun As Label
    Friend WithEvents lblSLunasTahun As Label
    Friend WithEvents lblPTempoTahun As Label
    Friend WithEvents lblPATMTahun As Label
    Friend WithEvents lblPLunasTahun As Label
    Friend WithEvents lblTahun As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
End Class
