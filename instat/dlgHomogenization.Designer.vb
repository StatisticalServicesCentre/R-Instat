﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgHomogenization
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgHomogenization))
        Me.lblElement = New System.Windows.Forms.Label()
        Me.grpMethods = New System.Windows.Forms.GroupBox()
        Me.rdoCptMean = New System.Windows.Forms.RadioButton()
        Me.rdoMeanVariance = New System.Windows.Forms.RadioButton()
        Me.rdoCptVariance = New System.Windows.Forms.RadioButton()
        Me.grpCptOptions = New System.Windows.Forms.GroupBox()
        Me.lblMinSegLen = New System.Windows.Forms.Label()
        Me.lblQ = New System.Windows.Forms.Label()
        Me.lblPenalty = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblDistribution = New System.Windows.Forms.Label()
        Me.grpOutputOptions = New System.Windows.Forms.GroupBox()
        Me.ttOptions = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblPenaltyValue = New System.Windows.Forms.Label()
        Me.ucrSaveResult = New instat.ucrSave()
        Me.ucrChkPlot = New instat.ucrCheck()
        Me.ucrChkSummary = New instat.ucrCheck()
        Me.ucrInputPenValue = New instat.ucrInputTextBox()
        Me.ucrNudMinSegLen = New instat.ucrNud()
        Me.ucrInputQ = New instat.ucrInputTextBox()
        Me.ucrInputComboDistribution = New instat.ucrInputComboBox()
        Me.ucrInputComboMethod = New instat.ucrInputComboBox()
        Me.ucrInputComboPenalty = New instat.ucrInputComboBox()
        Me.ucrPnlMethods = New instat.UcrPanel()
        Me.ucrReceiverElement = New instat.ucrReceiverSingle()
        Me.ucrSelectorHomogenization = New instat.ucrSelectorByDataFrameAddRemove()
        Me.ucrBase = New instat.ucrButtons()
        Me.rdoSingle = New System.Windows.Forms.RadioButton()
        Me.rdoMultiple = New System.Windows.Forms.RadioButton()
        Me.ucrPnlOptions = New instat.UcrPanel()
        Me.grpMethods.SuspendLayout()
        Me.grpCptOptions.SuspendLayout()
        Me.grpOutputOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblElement
        '
        resources.ApplyResources(Me.lblElement, "lblElement")
        Me.lblElement.Name = "lblElement"
        '
        'grpMethods
        '
        Me.grpMethods.Controls.Add(Me.rdoCptMean)
        Me.grpMethods.Controls.Add(Me.rdoMeanVariance)
        Me.grpMethods.Controls.Add(Me.rdoCptVariance)
        Me.grpMethods.Controls.Add(Me.ucrPnlMethods)
        resources.ApplyResources(Me.grpMethods, "grpMethods")
        Me.grpMethods.Name = "grpMethods"
        Me.grpMethods.TabStop = False
        '
        'rdoCptMean
        '
        resources.ApplyResources(Me.rdoCptMean, "rdoCptMean")
        Me.rdoCptMean.Name = "rdoCptMean"
        Me.rdoCptMean.UseVisualStyleBackColor = True
        '
        'rdoMeanVariance
        '
        resources.ApplyResources(Me.rdoMeanVariance, "rdoMeanVariance")
        Me.rdoMeanVariance.Name = "rdoMeanVariance"
        Me.rdoMeanVariance.UseVisualStyleBackColor = True
        '
        'rdoCptVariance
        '
        resources.ApplyResources(Me.rdoCptVariance, "rdoCptVariance")
        Me.rdoCptVariance.Name = "rdoCptVariance"
        Me.rdoCptVariance.UseVisualStyleBackColor = True
        '
        'grpCptOptions
        '
        Me.grpCptOptions.Controls.Add(Me.lblPenaltyValue)
        Me.grpCptOptions.Controls.Add(Me.ucrInputPenValue)
        Me.grpCptOptions.Controls.Add(Me.lblMinSegLen)
        Me.grpCptOptions.Controls.Add(Me.lblQ)
        Me.grpCptOptions.Controls.Add(Me.lblPenalty)
        Me.grpCptOptions.Controls.Add(Me.Label2)
        Me.grpCptOptions.Controls.Add(Me.lblDistribution)
        Me.grpCptOptions.Controls.Add(Me.ucrNudMinSegLen)
        Me.grpCptOptions.Controls.Add(Me.ucrInputQ)
        Me.grpCptOptions.Controls.Add(Me.ucrInputComboDistribution)
        Me.grpCptOptions.Controls.Add(Me.ucrInputComboMethod)
        Me.grpCptOptions.Controls.Add(Me.ucrInputComboPenalty)
        resources.ApplyResources(Me.grpCptOptions, "grpCptOptions")
        Me.grpCptOptions.Name = "grpCptOptions"
        Me.grpCptOptions.TabStop = False
        '
        'lblMinSegLen
        '
        resources.ApplyResources(Me.lblMinSegLen, "lblMinSegLen")
        Me.lblMinSegLen.Name = "lblMinSegLen"
        '
        'lblQ
        '
        resources.ApplyResources(Me.lblQ, "lblQ")
        Me.lblQ.Name = "lblQ"
        '
        'lblPenalty
        '
        resources.ApplyResources(Me.lblPenalty, "lblPenalty")
        Me.lblPenalty.Name = "lblPenalty"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'lblDistribution
        '
        resources.ApplyResources(Me.lblDistribution, "lblDistribution")
        Me.lblDistribution.Name = "lblDistribution"
        '
        'grpOutputOptions
        '
        Me.grpOutputOptions.Controls.Add(Me.ucrChkPlot)
        Me.grpOutputOptions.Controls.Add(Me.ucrChkSummary)
        resources.ApplyResources(Me.grpOutputOptions, "grpOutputOptions")
        Me.grpOutputOptions.Name = "grpOutputOptions"
        Me.grpOutputOptions.TabStop = False
        '
        'lblPenaltyValue
        '
        resources.ApplyResources(Me.lblPenaltyValue, "lblPenaltyValue")
        Me.lblPenaltyValue.Name = "lblPenaltyValue"
        '
        'ucrSaveResult
        '
        resources.ApplyResources(Me.ucrSaveResult, "ucrSaveResult")
        Me.ucrSaveResult.Name = "ucrSaveResult"
        '
        'ucrChkPlot
        '
        Me.ucrChkPlot.Checked = False
        resources.ApplyResources(Me.ucrChkPlot, "ucrChkPlot")
        Me.ucrChkPlot.Name = "ucrChkPlot"
        '
        'ucrChkSummary
        '
        Me.ucrChkSummary.Checked = False
        resources.ApplyResources(Me.ucrChkSummary, "ucrChkSummary")
        Me.ucrChkSummary.Name = "ucrChkSummary"
        '
        'ucrInputPenValue
        '
        Me.ucrInputPenValue.AddQuotesIfUnrecognised = True
        Me.ucrInputPenValue.IsMultiline = False
        Me.ucrInputPenValue.IsReadOnly = False
        resources.ApplyResources(Me.ucrInputPenValue, "ucrInputPenValue")
        Me.ucrInputPenValue.Name = "ucrInputPenValue"
        '
        'ucrNudMinSegLen
        '
        Me.ucrNudMinSegLen.DecimalPlaces = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudMinSegLen.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        resources.ApplyResources(Me.ucrNudMinSegLen, "ucrNudMinSegLen")
        Me.ucrNudMinSegLen.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ucrNudMinSegLen.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudMinSegLen.Name = "ucrNudMinSegLen"
        Me.ucrNudMinSegLen.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'ucrInputQ
        '
        Me.ucrInputQ.AddQuotesIfUnrecognised = True
        Me.ucrInputQ.IsMultiline = False
        Me.ucrInputQ.IsReadOnly = False
        resources.ApplyResources(Me.ucrInputQ, "ucrInputQ")
        Me.ucrInputQ.Name = "ucrInputQ"
        '
        'ucrInputComboDistribution
        '
        Me.ucrInputComboDistribution.AddQuotesIfUnrecognised = True
        Me.ucrInputComboDistribution.IsReadOnly = False
        resources.ApplyResources(Me.ucrInputComboDistribution, "ucrInputComboDistribution")
        Me.ucrInputComboDistribution.Name = "ucrInputComboDistribution"
        '
        'ucrInputComboMethod
        '
        Me.ucrInputComboMethod.AddQuotesIfUnrecognised = True
        Me.ucrInputComboMethod.IsReadOnly = False
        resources.ApplyResources(Me.ucrInputComboMethod, "ucrInputComboMethod")
        Me.ucrInputComboMethod.Name = "ucrInputComboMethod"
        '
        'ucrInputComboPenalty
        '
        Me.ucrInputComboPenalty.AddQuotesIfUnrecognised = True
        Me.ucrInputComboPenalty.IsReadOnly = False
        resources.ApplyResources(Me.ucrInputComboPenalty, "ucrInputComboPenalty")
        Me.ucrInputComboPenalty.Name = "ucrInputComboPenalty"
        '
        'ucrPnlMethods
        '
        resources.ApplyResources(Me.ucrPnlMethods, "ucrPnlMethods")
        Me.ucrPnlMethods.Name = "ucrPnlMethods"
        '
        'ucrReceiverElement
        '
        Me.ucrReceiverElement.frmParent = Me
        resources.ApplyResources(Me.ucrReceiverElement, "ucrReceiverElement")
        Me.ucrReceiverElement.Name = "ucrReceiverElement"
        Me.ucrReceiverElement.Selector = Nothing
        Me.ucrReceiverElement.strNcFilePath = ""
        Me.ucrReceiverElement.ucrSelector = Nothing
        '
        'ucrSelectorHomogenization
        '
        Me.ucrSelectorHomogenization.bDropUnusedFilterLevels = False
        Me.ucrSelectorHomogenization.bShowHiddenColumns = False
        Me.ucrSelectorHomogenization.bUseCurrentFilter = True
        resources.ApplyResources(Me.ucrSelectorHomogenization, "ucrSelectorHomogenization")
        Me.ucrSelectorHomogenization.Name = "ucrSelectorHomogenization"
        '
        'ucrBase
        '
        resources.ApplyResources(Me.ucrBase, "ucrBase")
        Me.ucrBase.Name = "ucrBase"
        '
        'rdoSingle
        '
        resources.ApplyResources(Me.rdoSingle, "rdoSingle")
        Me.rdoSingle.BackColor = System.Drawing.SystemColors.Control
        Me.rdoSingle.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoSingle.FlatAppearance.BorderSize = 2
        Me.rdoSingle.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoSingle.Name = "rdoSingle"
        Me.rdoSingle.TabStop = True
        Me.rdoSingle.Tag = ""
        Me.rdoSingle.UseVisualStyleBackColor = False
        '
        'rdoMultiple
        '
        resources.ApplyResources(Me.rdoMultiple, "rdoMultiple")
        Me.rdoMultiple.BackColor = System.Drawing.SystemColors.Control
        Me.rdoMultiple.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoMultiple.FlatAppearance.BorderSize = 2
        Me.rdoMultiple.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoMultiple.Name = "rdoMultiple"
        Me.rdoMultiple.TabStop = True
        Me.rdoMultiple.Tag = ""
        Me.rdoMultiple.UseVisualStyleBackColor = False
        '
        'ucrPnlOptions
        '
        resources.ApplyResources(Me.ucrPnlOptions, "ucrPnlOptions")
        Me.ucrPnlOptions.Name = "ucrPnlOptions"
        '
        'dlgHomogenization
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.rdoSingle)
        Me.Controls.Add(Me.rdoMultiple)
        Me.Controls.Add(Me.ucrPnlOptions)
        Me.Controls.Add(Me.ucrSaveResult)
        Me.Controls.Add(Me.grpOutputOptions)
        Me.Controls.Add(Me.grpCptOptions)
        Me.Controls.Add(Me.grpMethods)
        Me.Controls.Add(Me.lblElement)
        Me.Controls.Add(Me.ucrReceiverElement)
        Me.Controls.Add(Me.ucrSelectorHomogenization)
        Me.Controls.Add(Me.ucrBase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgHomogenization"
        Me.grpMethods.ResumeLayout(False)
        Me.grpMethods.PerformLayout()
        Me.grpCptOptions.ResumeLayout(False)
        Me.grpCptOptions.PerformLayout()
        Me.grpOutputOptions.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents ucrSelectorHomogenization As ucrSelectorByDataFrameAddRemove
    Friend WithEvents ucrReceiverElement As ucrReceiverSingle
    Friend WithEvents lblElement As Label
    Friend WithEvents grpCptOptions As GroupBox
    Friend WithEvents grpMethods As GroupBox
    Friend WithEvents ucrPnlMethods As UcrPanel
    Friend WithEvents rdoCptMean As RadioButton
    Friend WithEvents rdoMeanVariance As RadioButton
    Friend WithEvents rdoCptVariance As RadioButton
    Friend WithEvents grpOutputOptions As GroupBox
    Friend WithEvents ucrChkPlot As ucrCheck
    Friend WithEvents ucrChkSummary As ucrCheck
    Friend WithEvents ucrNudMinSegLen As ucrNud
    Friend WithEvents ucrInputQ As ucrInputTextBox
    Friend WithEvents ucrInputComboDistribution As ucrInputComboBox
    Friend WithEvents ucrInputComboMethod As ucrInputComboBox
    Friend WithEvents ucrInputComboPenalty As ucrInputComboBox
    Friend WithEvents lblPenalty As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblDistribution As Label
    Friend WithEvents lblMinSegLen As Label
    Friend WithEvents lblQ As Label
    Friend WithEvents ucrSaveResult As ucrSave
    Friend WithEvents ttOptions As ToolTip
    Friend WithEvents lblPenaltyValue As Label
    Friend WithEvents ucrInputPenValue As ucrInputTextBox
    Friend WithEvents rdoSingle As RadioButton
    Friend WithEvents rdoMultiple As RadioButton
    Friend WithEvents ucrPnlOptions As UcrPanel
End Class
