<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DSEDE
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboMSTSource = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.cboDestinationFolder = New System.Windows.Forms.ComboBox()
        Me.cboIndexSymbolName = New System.Windows.Forms.ComboBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.chkValidationCheck = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(66, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "DSE MST File Source: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(66, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "DSEX Symbol Name:"
        '
        'cboMSTSource
        '
        Me.cboMSTSource.FormattingEnabled = True
        Me.cboMSTSource.Items.AddRange(New Object() {"http://www.dsebd.org/mst.txt"})
        Me.cboMSTSource.Location = New System.Drawing.Point(184, 38)
        Me.cboMSTSource.Name = "cboMSTSource"
        Me.cboMSTSource.Size = New System.Drawing.Size(323, 21)
        Me.cboMSTSource.TabIndex = 8
        Me.cboMSTSource.Text = "http://www.dsebd.org/mst.txt"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(66, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(66, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Destination Folder"
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(69, 243)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(436, 57)
        Me.btnGo.TabIndex = 12
        Me.btnGo.Text = "Go!"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'cboDestinationFolder
        '
        Me.cboDestinationFolder.FormattingEnabled = True
        Me.cboDestinationFolder.Location = New System.Drawing.Point(184, 91)
        Me.cboDestinationFolder.Name = "cboDestinationFolder"
        Me.cboDestinationFolder.Size = New System.Drawing.Size(323, 21)
        Me.cboDestinationFolder.TabIndex = 15
        '
        'cboIndexSymbolName
        '
        Me.cboIndexSymbolName.FormattingEnabled = True
        Me.cboIndexSymbolName.Items.AddRange(New Object() {"00DSEGEN", "DSEX"})
        Me.cboIndexSymbolName.Location = New System.Drawing.Point(184, 64)
        Me.cboIndexSymbolName.Name = "cboIndexSymbolName"
        Me.cboIndexSymbolName.Size = New System.Drawing.Size(323, 21)
        Me.cboIndexSymbolName.TabIndex = 16
        Me.cboIndexSymbolName.Text = "00DSEGEN"
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.LightGray
        Me.txtStatus.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(69, 119)
        Me.txtStatus.Multiline = True
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStatus.Size = New System.Drawing.Size(437, 64)
        Me.txtStatus.TabIndex = 17
        Me.txtStatus.Text = "Click Go! to get data for today"
        Me.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkValidationCheck
        '
        Me.chkValidationCheck.AutoSize = True
        Me.chkValidationCheck.Location = New System.Drawing.Point(196, 199)
        Me.chkValidationCheck.Name = "chkValidationCheck"
        Me.chkValidationCheck.Size = New System.Drawing.Size(169, 17)
        Me.chkValidationCheck.TabIndex = 18
        Me.chkValidationCheck.Text = "Perform extra validation check"
        Me.chkValidationCheck.UseVisualStyleBackColor = True
        '
        'DSEDE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 312)
        Me.Controls.Add(Me.chkValidationCheck)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.cboIndexSymbolName)
        Me.Controls.Add(Me.cboDestinationFolder)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboMSTSource)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "DSEDE"
        Me.Text = "DSE Data Extractor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboMSTSource As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents cboDestinationFolder As System.Windows.Forms.ComboBox
    Friend WithEvents cboIndexSymbolName As System.Windows.Forms.ComboBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents chkValidationCheck As System.Windows.Forms.CheckBox

End Class
