Public Class frmRipple
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Public WithEvents lblAmpMax As System.Windows.Forms.Label
    Public WithEvents lblAmpMin As System.Windows.Forms.Label
    Public WithEvents lblAmplitude As System.Windows.Forms.Label
    Private WithEvents tbAmplitude As System.Windows.Forms.TrackBar
    Public WithEvents btnApply As System.Windows.Forms.Button
    Public WithEvents lblFreqMax As System.Windows.Forms.Label
    Public WithEvents lblFreqMin As System.Windows.Forms.Label
    Public WithEvents lblFrequency As System.Windows.Forms.Label
    Friend WithEvents gbAmplitude As System.Windows.Forms.GroupBox
    Friend WithEvents gbFrequency As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents startRadiusBar As System.Windows.Forms.TrackBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents startRadiusTxt As System.Windows.Forms.Label
    Private WithEvents tbFrequency As System.Windows.Forms.TrackBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblAmpMax = New System.Windows.Forms.Label
        Me.lblAmpMin = New System.Windows.Forms.Label
        Me.lblAmplitude = New System.Windows.Forms.Label
        Me.tbAmplitude = New System.Windows.Forms.TrackBar
        Me.btnApply = New System.Windows.Forms.Button
        Me.lblFreqMax = New System.Windows.Forms.Label
        Me.lblFreqMin = New System.Windows.Forms.Label
        Me.lblFrequency = New System.Windows.Forms.Label
        Me.tbFrequency = New System.Windows.Forms.TrackBar
        Me.gbAmplitude = New System.Windows.Forms.GroupBox
        Me.gbFrequency = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.startRadiusBar = New System.Windows.Forms.TrackBar
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.startRadiusTxt = New System.Windows.Forms.Label
        CType(Me.tbAmplitude, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFrequency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAmplitude.SuspendLayout()
        Me.gbFrequency.SuspendLayout()
        CType(Me.startRadiusBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblAmpMax
        '
        Me.lblAmpMax.AutoSize = True
        Me.lblAmpMax.Location = New System.Drawing.Point(205, 56)
        Me.lblAmpMax.Name = "lblAmpMax"
        Me.lblAmpMax.Size = New System.Drawing.Size(17, 12)
        Me.lblAmpMax.TabIndex = 14
        Me.lblAmpMax.Text = "20"
        '
        'lblAmpMin
        '
        Me.lblAmpMin.AutoSize = True
        Me.lblAmpMin.Location = New System.Drawing.Point(19, 56)
        Me.lblAmpMin.Name = "lblAmpMin"
        Me.lblAmpMin.Size = New System.Drawing.Size(11, 12)
        Me.lblAmpMin.TabIndex = 13
        Me.lblAmpMin.Text = "1"
        '
        'lblAmplitude
        '
        Me.lblAmplitude.Location = New System.Drawing.Point(234, 28)
        Me.lblAmplitude.Name = "lblAmplitude"
        Me.lblAmplitude.Size = New System.Drawing.Size(30, 15)
        Me.lblAmplitude.TabIndex = 12
        Me.lblAmplitude.Text = "0"
        Me.lblAmplitude.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbAmplitude
        '
        Me.tbAmplitude.Location = New System.Drawing.Point(12, 21)
        Me.tbAmplitude.Maximum = 20
        Me.tbAmplitude.Minimum = 1
        Me.tbAmplitude.Name = "tbAmplitude"
        Me.tbAmplitude.Size = New System.Drawing.Size(216, 45)
        Me.tbAmplitude.TabIndex = 10
        Me.tbAmplitude.Value = 1
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(103, 312)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(80, 28)
        Me.btnApply.TabIndex = 9
        Me.btnApply.Text = "Apply"
        '
        'lblFreqMax
        '
        Me.lblFreqMax.AutoSize = True
        Me.lblFreqMax.Location = New System.Drawing.Point(205, 56)
        Me.lblFreqMax.Name = "lblFreqMax"
        Me.lblFreqMax.Size = New System.Drawing.Size(17, 12)
        Me.lblFreqMax.TabIndex = 19
        Me.lblFreqMax.Text = "20"
        '
        'lblFreqMin
        '
        Me.lblFreqMin.AutoSize = True
        Me.lblFreqMin.Location = New System.Drawing.Point(19, 56)
        Me.lblFreqMin.Name = "lblFreqMin"
        Me.lblFreqMin.Size = New System.Drawing.Size(11, 12)
        Me.lblFreqMin.TabIndex = 18
        Me.lblFreqMin.Text = "1"
        '
        'lblFrequency
        '
        Me.lblFrequency.Location = New System.Drawing.Point(234, 28)
        Me.lblFrequency.Name = "lblFrequency"
        Me.lblFrequency.Size = New System.Drawing.Size(30, 15)
        Me.lblFrequency.TabIndex = 17
        Me.lblFrequency.Text = "0"
        Me.lblFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbFrequency
        '
        Me.tbFrequency.Location = New System.Drawing.Point(12, 21)
        Me.tbFrequency.Maximum = 20
        Me.tbFrequency.Minimum = 1
        Me.tbFrequency.Name = "tbFrequency"
        Me.tbFrequency.Size = New System.Drawing.Size(216, 45)
        Me.tbFrequency.TabIndex = 15
        Me.tbFrequency.Value = 1
        '
        'gbAmplitude
        '
        Me.gbAmplitude.Controls.Add(Me.lblAmpMax)
        Me.gbAmplitude.Controls.Add(Me.lblAmpMin)
        Me.gbAmplitude.Controls.Add(Me.lblAmplitude)
        Me.gbAmplitude.Controls.Add(Me.tbAmplitude)
        Me.gbAmplitude.Location = New System.Drawing.Point(12, 14)
        Me.gbAmplitude.Name = "gbAmplitude"
        Me.gbAmplitude.Size = New System.Drawing.Size(270, 88)
        Me.gbAmplitude.TabIndex = 20
        Me.gbAmplitude.TabStop = False
        Me.gbAmplitude.Text = "Amplitude of Sine Wave"
        '
        'gbFrequency
        '
        Me.gbFrequency.Controls.Add(Me.lblFreqMin)
        Me.gbFrequency.Controls.Add(Me.lblFreqMax)
        Me.gbFrequency.Controls.Add(Me.lblFrequency)
        Me.gbFrequency.Controls.Add(Me.tbFrequency)
        Me.gbFrequency.Location = New System.Drawing.Point(12, 116)
        Me.gbFrequency.Name = "gbFrequency"
        Me.gbFrequency.Size = New System.Drawing.Size(270, 88)
        Me.gbFrequency.TabIndex = 21
        Me.gbFrequency.TabStop = False
        Me.gbFrequency.Text = "Frequency of Sine Wave"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 220)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 12)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Starting Radius"
        '
        'startRadiusBar
        '
        Me.startRadiusBar.LargeChange = 1
        Me.startRadiusBar.Location = New System.Drawing.Point(24, 247)
        Me.startRadiusBar.Maximum = 100
        Me.startRadiusBar.Name = "startRadiusBar"
        Me.startRadiusBar.Size = New System.Drawing.Size(210, 45)
        Me.startRadiusBar.TabIndex = 10
        Me.startRadiusBar.TickFrequency = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 280)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 12)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(196, 280)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 12)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "diagonal/2"
        '
        'startRadiusTxt
        '
        Me.startRadiusTxt.AutoSize = True
        Me.startRadiusTxt.Location = New System.Drawing.Point(238, 247)
        Me.startRadiusTxt.Name = "startRadiusTxt"
        Me.startRadiusTxt.Size = New System.Drawing.Size(11, 12)
        Me.startRadiusTxt.TabIndex = 26
        Me.startRadiusTxt.Text = "0"
        '
        'frmRipple
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(332, 352)
        Me.Controls.Add(Me.startRadiusTxt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.startRadiusBar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbFrequency)
        Me.Controls.Add(Me.gbAmplitude)
        Me.Controls.Add(Me.btnApply)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRipple"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ripple Effect"
        CType(Me.tbAmplitude, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFrequency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAmplitude.ResumeLayout(False)
        Me.gbAmplitude.PerformLayout()
        Me.gbFrequency.ResumeLayout(False)
        Me.gbFrequency.PerformLayout()
        CType(Me.startRadiusBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public settings As RippleSettings

    Public Sub New(ByVal settings As RippleSettings)
        Me.New()
        Me.settings = settings
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        settings.amplitude = tbAmplitude.Value
        settings.frequency = tbFrequency.Value
        settings.startradius = startRadiusBar.Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub tbAmplitude_Updated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbAmplitude.ValueChanged, tbAmplitude.Scroll
        lblAmplitude.Text = tbAmplitude.Value
    End Sub

    Private Sub tbFrequency_Updated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbFrequency.ValueChanged, tbFrequency.Scroll
        lblFrequency.Text = tbFrequency.Value
    End Sub

    Private Sub startRadiusBar_Updated(ByVal sender As Object, ByVal e As System.EventArgs) Handles startRadiusBar.ValueChanged, startRadiusBar.Scroll
        startRadiusTxt.Text = startRadiusBar.Value & "%"
    End Sub

    Private Sub frmRipple_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tbAmplitude.Value = settings.amplitude
        tbFrequency.Value = settings.frequency
        startRadiusBar.Value = settings.startradius
    End Sub

End Class
