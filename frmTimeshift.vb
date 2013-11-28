Public Class frmTimeshift
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Public WithEvents lblMax As System.Windows.Forms.Label
    Public WithEvents lblMin As System.Windows.Forms.Label
    Public WithEvents cmdApply As System.Windows.Forms.Button
    Private WithEvents tbPosition As System.Windows.Forms.TrackBar
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents tbRegion As System.Windows.Forms.TrackBar

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblMax = New System.Windows.Forms.Label
        Me.lblMin = New System.Windows.Forms.Label
        Me.cmdApply = New System.Windows.Forms.Button
        Me.tbPosition = New System.Windows.Forms.TrackBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.tbRegion = New System.Windows.Forms.TrackBar
        CType(Me.tbPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbRegion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMax
        '
        Me.lblMax.AutoSize = True
        Me.lblMax.Location = New System.Drawing.Point(233, 82)
        Me.lblMax.Name = "lblMax"
        Me.lblMax.Size = New System.Drawing.Size(31, 12)
        Me.lblMax.TabIndex = 14
        Me.lblMax.Text = "Right"
        '
        'lblMin
        '
        Me.lblMin.AutoSize = True
        Me.lblMin.Location = New System.Drawing.Point(18, 82)
        Me.lblMin.Name = "lblMin"
        Me.lblMin.Size = New System.Drawing.Size(24, 12)
        Me.lblMin.TabIndex = 13
        Me.lblMin.Text = "Left"
        '
        'cmdApply
        '
        Me.cmdApply.BackColor = System.Drawing.SystemColors.Control
        Me.cmdApply.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdApply.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdApply.Location = New System.Drawing.Point(97, 207)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdApply.Size = New System.Drawing.Size(80, 34)
        Me.cmdApply.TabIndex = 9
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.UseVisualStyleBackColor = False
        '
        'tbPosition
        '
        Me.tbPosition.LargeChange = 10
        Me.tbPosition.Location = New System.Drawing.Point(20, 49)
        Me.tbPosition.Maximum = 100
        Me.tbPosition.Name = "tbPosition"
        Me.tbPosition.Size = New System.Drawing.Size(240, 45)
        Me.tbPosition.SmallChange = 10
        Me.tbPosition.TabIndex = 10
        Me.tbPosition.TickFrequency = 10
        Me.tbPosition.Value = 70
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(122, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 12)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Center"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 12)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Position"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 12)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Crossfade Region"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(131, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 12)
        Me.Label4.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(225, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 12)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "50 pixels"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 182)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "5 pixels"
        '
        'tbRegion
        '
        Me.tbRegion.LargeChange = 10
        Me.tbRegion.Location = New System.Drawing.Point(20, 145)
        Me.tbRegion.Maximum = 50
        Me.tbRegion.Minimum = 5
        Me.tbRegion.Name = "tbRegion"
        Me.tbRegion.Size = New System.Drawing.Size(240, 45)
        Me.tbRegion.SmallChange = 10
        Me.tbRegion.TabIndex = 18
        Me.tbRegion.TickFrequency = 10
        Me.tbRegion.Value = 35
        '
        'frmTimeshift
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(300, 260)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbRegion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblMax)
        Me.Controls.Add(Me.lblMin)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.tbPosition)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTimeshift"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Timeshift Effect"
        CType(Me.tbPosition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbRegion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public settings As TimeshiftSettings

    Public Sub New(ByVal settings As TimeshiftSettings)
        Me.New()
        Me.settings = settings
    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        settings.position = tbPosition.Value
        settings.region = tbRegion.Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmTransition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tbPosition.Value = settings.position
        tbRegion.Value = settings.region
    End Sub

    Private Sub tbPosition_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPosition.Scroll
        settings.position = tbPosition.Value
    End Sub


    Private Sub tbRegion_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbRegion.Scroll
        settings.region = tbRegion.Value
    End Sub
End Class
