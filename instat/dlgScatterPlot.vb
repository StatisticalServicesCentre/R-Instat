﻿' R- Instat
' Copyright (C) 2015-2017
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program.  If not, see <http://www.gnu.org/licenses/>.
Imports instat.Translations

Public Class dlgScatterPlot
    Private clsRggplotFunction As New RFunction
    Private clsRScatterGeomFunction, clsLabelFunction As New RFunction
    Private clsRaesFunction As New RFunction
    Private clsLocalRaesFunction As New RFunction
    Private clsBaseOperator As New ROperator
    Private bFirstLoad As Boolean = True
    Private bReset As Boolean = True
    Private bResetSubdialog As Boolean = True
    Private bResetlayerSubdialog As Boolean = True
    Private clsLabsFunction As New RFunction
    Private clsXlabsFunction As New RFunction
    Private clsYlabsFunction As New RFunction
    Private clsXScalecontinuousFunction As New RFunction
    Private clsYScalecontinuousFunction As New RFunction
    Private clsFacetsFunction As New RFunction
    Private clsThemeFunction As New RFunction
    Private dctThemeFunctions As New Dictionary(Of String, RFunction)
    Private clsGeomSmoothFunction As New RFunction
    Private clsCoordPolarFunction As New RFunction
    Private clsCoordPolarStartOperator As New ROperator
    Private clsXScaleDateFunction As New RFunction
    Private clsYScaleDateFunction As New RFunction
    Private clsScaleFillViridisFunction As New RFunction
    Private clsScaleColourViridisFunction As New RFunction
    Private clsAnnotateFunction As New RFunction
    Private clsGeomRugFunction As New RFunction
    'Parameter names for geoms
    Private strFirstParameterName As String = "geomfunc"
    Private strGeomSmoothParameterName As String = "geom_smooth"
    Private strGeomTextRepelParameterName As String = "geom_text_repel"
    Private strGeomParameterNames() As String = {strFirstParameterName, strGeomSmoothParameterName, strGeomTextRepelParameterName}

    Private Sub dlgScatterPlot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitialiseDialog()
            bFirstLoad = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRCodeForControls(bReset)
        bReset = False
        TestOkEnabled()
        autoTranslate(Me)
    End Sub

    Private Sub InitialiseDialog()
        Dim clsGeomRugParameter As New RParameter
        Dim dctSidesOptions As New Dictionary(Of String, String)

        ucrBase.iHelpTopicID = 433
        ucrBase.clsRsyntax.bExcludeAssignedFunctionOutput = False
        ucrBase.clsRsyntax.iCallType = 3

        ucrSelectorForScatter.SetParameter(New RParameter("data", 0))
        ucrSelectorForScatter.SetParameterIsrfunction()

        ucrVariablesAsFactorForScatter.SetParameter(New RParameter("y", 1))
        ucrVariablesAsFactorForScatter.SetParameterIsString()
        ucrVariablesAsFactorForScatter.bWithQuotes = False
        ucrVariablesAsFactorForScatter.Selector = ucrSelectorForScatter
        ucrVariablesAsFactorForScatter.SetFactorReceiver(ucrFactorOptionalReceiver)
        ucrVariablesAsFactorForScatter.strSelectorHeading = "Variables"
        ucrVariablesAsFactorForScatter.SetValuesToIgnore({Chr(34) & Chr(34)})
        ucrVariablesAsFactorForScatter.bAddParameterIfEmpty = True

        ucrReceiverX.SetParameter(New RParameter("x", 0))
        ucrReceiverX.SetParameterIsString()
        ucrReceiverX.bWithQuotes = False
        ucrReceiverX.Selector = ucrSelectorForScatter
        ucrReceiverX.strSelectorHeading = "Variables"
        ucrReceiverX.SetValuesToIgnore({Chr(34) & Chr(34)})
        ucrReceiverX.bAddParameterIfEmpty = True

        ucrReceiverLabel.SetParameter(New RParameter("label"))
        ucrReceiverLabel.SetParameterIsString()
        ucrReceiverLabel.bWithQuotes = False
        ucrReceiverLabel.Selector = ucrSelectorForScatter
        ucrReceiverLabel.strSelectorHeading = "Variables"

        ucrFactorOptionalReceiver.SetParameter(New RParameter("colour", 2))
        ucrFactorOptionalReceiver.SetParameterIsString()
        ucrFactorOptionalReceiver.bWithQuotes = False
        ucrFactorOptionalReceiver.Selector = ucrSelectorForScatter
        ucrFactorOptionalReceiver.strSelectorHeading = "Variables"

        ucrChkLineofBestFit.SetText("Add Line of Best Fit")
        ucrChkLineofBestFit.AddParameterPresentCondition(True, "geom_smooth")
        ucrChkLineofBestFit.AddParameterPresentCondition(False, "geom_smooth", False)
        ucrChkLineofBestFit.AddToLinkedControls(ucrChkWithSE, {True}, bNewLinkedHideIfParameterMissing:=True)

        ucrChkWithSE.SetText("With Standard Error")
        ucrChkWithSE.SetParameter(New RParameter("se"), bNewAddRemoveParameter:=False, bNewChangeParameterValue:=True)
        ucrChkWithSE.SetValuesCheckedAndUnchecked("TRUE", "FALSE")
        ucrChkWithSE.SetRDefault("TRUE")

        ucrChkAddRugPlot.SetText("Add Rug Plot")
        ucrChkAddRugPlot.AddParameterPresentCondition(True, "geom_rug")
        ucrChkAddRugPlot.AddParameterPresentCondition(False, "geom_rug", False)
        ucrChkAddRugPlot.AddToLinkedControls({ucrNudSize, ucrInputSides}, {True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)

        ucrSaveScatterPlot.SetPrefix("scatter_plot")
        ucrSaveScatterPlot.SetSaveType(strRObjectType:=RObjectTypeLabel.Graph,
                                       strRObjectFormat:=RObjectFormat.Image)
        ucrSaveScatterPlot.SetDataFrameSelector(ucrSelectorForScatter.ucrAvailableDataFrames)
        ucrSaveScatterPlot.SetCheckBoxText("Save Graph")
        ucrSaveScatterPlot.SetIsComboBox()
        ucrSaveScatterPlot.SetAssignToIfUncheckedValue("last_graph")

        ucrNudSize.SetParameter(New RParameter("size", 0))
        ucrNudSize.Increment = 0.1
        ucrNudSize.DecimalPlaces = 1

        ucrInputSides.SetParameter(New RParameter("sides", 1))
        dctSidesOptions.Add("Bottom and left", Chr(34) & "bl" & Chr(34))
        dctSidesOptions.Add("Top, right and bottom", Chr(34) & "trb" & Chr(34))
        dctSidesOptions.Add("Top, right and left", Chr(34) & "trl" & Chr(34))
        dctSidesOptions.Add("Top, bottom and left", Chr(34) & "tbl" & Chr(34))
        dctSidesOptions.Add("Right, bottom and left", Chr(34) & "rbl" & Chr(34))
        dctSidesOptions.Add("Top and right", Chr(34) & "tr" & Chr(34))
        dctSidesOptions.Add("Top and bottom", Chr(34) & "tb" & Chr(34))
        dctSidesOptions.Add("Top and left", Chr(34) & "tl" & Chr(34))
        dctSidesOptions.Add("Right and bottom", Chr(34) & "rb" & Chr(34))
        dctSidesOptions.Add("Right and left", Chr(34) & "rl" & Chr(34))
        dctSidesOptions.Add("Top", Chr(34) & "t" & Chr(34))
        dctSidesOptions.Add("Right", Chr(34) & "r" & Chr(34))
        dctSidesOptions.Add("Bottom", Chr(34) & "b" & Chr(34))
        dctSidesOptions.Add("Left", Chr(34) & "l" & Chr(34))
        ucrInputSides.SetItems(dctSidesOptions)
        ucrInputSides.SetRDefault(Chr(34) & "bl" & Chr(34))
        ucrInputSides.SetDropDownStyleAsNonEditable()

        ucrNudSize.SetLinkedDisplayControl(lblSize)
        ucrInputSides.SetLinkedDisplayControl(lblSides)
    End Sub

    Private Sub SetDefaults()
        clsBaseOperator = New ROperator
        clsRggplotFunction = New RFunction
        clsRScatterGeomFunction = New RFunction
        clsLabelFunction = New RFunction
        clsRaesFunction = New RFunction
        clsGeomSmoothFunction = New RFunction
        clsGeomRugFunction = New RFunction

        ucrSelectorForScatter.Reset()
        ucrSelectorForScatter.SetGgplotFunction(clsBaseOperator)
        ucrSaveScatterPlot.Reset()
        ucrVariablesAsFactorForScatter.SetMeAsReceiver()
        sdgPlots.Reset()
        bResetSubdialog = True
        bResetlayerSubdialog = True

        toolStripMenuItemRugOptions.Enabled = False
        toolStripMenuItemSmoothOptions.Enabled = False
        toolStripMenuItemTextrepelOptions.Enabled = False

        clsBaseOperator.SetOperation("+")
        clsBaseOperator.AddParameter("ggplot", clsRFunctionParameter:=clsRggplotFunction, iPosition:=0)
        clsBaseOperator.AddParameter(strFirstParameterName, clsRFunctionParameter:=clsRScatterGeomFunction, iPosition:=2)

        clsRggplotFunction.SetPackageName("ggplot2")
        clsRggplotFunction.SetRCommand("ggplot")
        clsRggplotFunction.AddParameter("mapping", clsRFunctionParameter:=clsRaesFunction, iPosition:=1)

        clsRaesFunction.SetPackageName("ggplot2")
        clsRaesFunction.SetRCommand("aes")
        clsRaesFunction.AddParameter("x", Chr(34) & Chr(34))
        clsRaesFunction.AddParameter("y", Chr(34) & Chr(34))

        clsRScatterGeomFunction.SetPackageName("ggplot2")
        clsRScatterGeomFunction.SetRCommand("geom_point")

        clsLabelFunction.SetPackageName("ggrepel")
        clsLabelFunction.SetRCommand("geom_text_repel")

        clsGeomRugFunction.SetPackageName("ggplot2")
        clsGeomRugFunction.SetRCommand("geom_rug")
        clsGeomRugFunction.AddParameter("size", 0.5, iPosition:=0)

        clsBaseOperator.AddParameter(GgplotDefaults.clsDefaultThemeParameter.Clone())
        clsXlabsFunction = GgplotDefaults.clsXlabTitleFunction.Clone()
        clsYlabsFunction = GgplotDefaults.clsYlabTitleFunction.Clone()
        clsLabsFunction = GgplotDefaults.clsDefaultLabs.Clone()
        clsXScalecontinuousFunction = GgplotDefaults.clsXScalecontinuousFunction.Clone()
        clsYScalecontinuousFunction = GgplotDefaults.clsYScalecontinuousFunction.Clone()
        clsFacetsFunction = GgplotDefaults.clsFacetFunction.Clone()
        dctThemeFunctions = New Dictionary(Of String, RFunction)(GgplotDefaults.dctThemeFunctions)
        clsCoordPolarStartOperator = GgplotDefaults.clsCoordPolarStartOperator.Clone()
        clsCoordPolarFunction = GgplotDefaults.clsCoordPolarFunction.Clone()
        clsThemeFunction = GgplotDefaults.clsDefaultThemeFunction
        clsLocalRaesFunction = GgplotDefaults.clsAesFunction.Clone()
        clsXScaleDateFunction = GgplotDefaults.clsXScaleDateFunction.Clone()
        clsYScaleDateFunction = GgplotDefaults.clsYScaleDateFunction.Clone()
        clsScaleFillViridisFunction = GgplotDefaults.clsScaleFillViridisFunction
        clsScaleColourViridisFunction = GgplotDefaults.clsScaleColorViridisFunction
        clsAnnotateFunction = GgplotDefaults.clsAnnotateFunction

        clsGeomSmoothFunction.SetPackageName("ggplot2")
        clsGeomSmoothFunction.SetRCommand("geom_smooth")
        clsGeomSmoothFunction.AddParameter("method", Chr(34) & "lm" & Chr(34), iPosition:=0)
        clsGeomSmoothFunction.AddParameter("se", "FALSE", iPosition:=1)

        clsBaseOperator.SetAssignToOutputObject(strRObjectToAssignTo:="last_graph",
                                           strRObjectTypeLabelToAssignTo:=RObjectTypeLabel.Graph,
                                           strRObjectFormatToAssignTo:=RObjectFormat.Image,
                                           strRDataFrameNameToAddObjectTo:=ucrSelectorForScatter.strCurrentDataFrame,
                                           strObjectName:="last_graph")

        ucrBase.clsRsyntax.SetBaseROperator(clsBaseOperator)
    End Sub

    Public Sub SetRCodeForControls(bReset As Boolean)
        ucrSelectorForScatter.SetRCode(clsRggplotFunction, bReset)
        ucrReceiverX.SetRCode(clsRaesFunction, bReset)
        ucrReceiverLabel.SetRCode(clsRaesFunction, bReset)
        ucrVariablesAsFactorForScatter.SetRCode(clsRaesFunction, bReset)
        ucrFactorOptionalReceiver.SetRCode(clsRaesFunction, bReset)
        ucrChkLineofBestFit.SetRCode(clsBaseOperator, bReset)
        ucrSaveScatterPlot.SetRCode(clsBaseOperator, bReset)
        ucrChkWithSE.SetRCode(clsGeomSmoothFunction, bReset)
        ucrChkAddRugPlot.SetRCode(clsBaseOperator, bReset)
        ucrNudSize.SetRCode(clsGeomRugFunction, bReset)
        ucrInputSides.SetRCode(clsGeomRugFunction, bReset)
    End Sub

    Private Sub TestOkEnabled()
        ' Either y or x can be empty but not both
        If (Not ucrSaveScatterPlot.IsComplete) OrElse (ucrVariablesAsFactorForScatter.IsEmpty AndAlso ucrReceiverX.IsEmpty()) Then
            ucrBase.OKEnabled(False)
        Else
            ucrBase.OKEnabled(True)
        End If
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOkEnabled()
    End Sub

    Private Sub ucrChkLineofBestFit_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrChkLineofBestFit.ControlValueChanged
        If ucrChkLineofBestFit.Checked Then
            clsBaseOperator.AddParameter("geom_smooth", clsRFunctionParameter:=clsGeomSmoothFunction, iPosition:=4)
        Else
            clsBaseOperator.RemoveParameterByName("geom_smooth")
        End If
        toolStripMenuItemSmoothOptions.Enabled = ucrChkLineofBestFit.Checked
    End Sub

    Private Sub ucrChkAddRugPlot_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrChkAddRugPlot.ControlValueChanged
        If ucrChkAddRugPlot.Checked Then
            clsBaseOperator.AddParameter("geom_rug", clsRFunctionParameter:=clsGeomRugFunction, iPosition:=3)
        Else
            clsBaseOperator.RemoveParameterByName("geom_rug")
        End If
        toolStripMenuItemRugOptions.Enabled = ucrChkAddRugPlot.Checked
    End Sub

    Private Sub cmdOptions_Click(sender As Object, e As EventArgs) Handles cmdOptions.Click, toolStripMenuItemPlotOptions.Click
        sdgPlots.SetRCode(clsNewOperator:=ucrBase.clsRsyntax.clsBaseOperator, clsNewGlobalAesFunction:=clsRaesFunction,
                          clsNewYScalecontinuousFunction:=clsYScalecontinuousFunction, clsNewXScalecontinuousFunction:=clsXScalecontinuousFunction,
                          clsNewLabsFunction:=clsLabsFunction, clsNewXLabsTitleFunction:=clsXlabsFunction, clsNewYLabTitleFunction:=clsYlabsFunction,
                          clsNewFacetFunction:=clsFacetsFunction, clsNewCoordPolarFunction:=clsCoordPolarFunction, clsNewCoordPolarStartOperator:=clsCoordPolarStartOperator,
                          clsNewThemeFunction:=clsThemeFunction, clsNewScaleFillViridisFunction:=clsScaleFillViridisFunction,
                          clsNewScaleColourViridisFunction:=clsScaleColourViridisFunction, clsNewXScaleDateFunction:=clsXScaleDateFunction,
                          clsNewYScaleDateFunction:=clsYScaleDateFunction, dctNewThemeFunctions:=dctThemeFunctions, ucrNewBaseSelector:=ucrSelectorForScatter,
                          strMainDialogGeomParameterNames:=strGeomParameterNames, clsNewAnnotateFunction:=clsAnnotateFunction, bReset:=bResetSubdialog)
        sdgPlots.ShowDialog()
        bResetSubdialog = False
    End Sub

    Private Sub toolStripMenuItemPointOptions_Click(sender As Object, e As EventArgs) Handles toolStripMenuItemPointOptions.Click
        EnableDisableOptions(clsRScatterGeomFunction)
    End Sub

    Private Sub toolStripMenuItemRugOptions_Click(sender As Object, e As EventArgs) Handles toolStripMenuItemRugOptions.Click
        EnableDisableOptions(clsGeomRugFunction)
    End Sub

    Private Sub toolStripMenuItemSmoothOptions_Click(sender As Object, e As EventArgs) Handles toolStripMenuItemSmoothOptions.Click
        EnableDisableOptions(clsGeomSmoothFunction)
    End Sub

    Private Sub toolStripMenuItemTextrepelOptions_Click(sender As Object, e As EventArgs) Handles toolStripMenuItemTextrepelOptions.Click
        EnableDisableOptions(clsLabelFunction)
    End Sub

    Private Sub EnableDisableOptions(clsTempFunction As RFunction)
        'SetupLayer sends the components storing the plot info (clsRaesFunction, clsRggplotFunction, ...) of dlgScatteredPlot through to sdgLayerOptions where these will be edited.
        sdgLayerOptions.SetupLayer(clsNewGgPlot:=clsRggplotFunction, clsNewGeomFunc:=clsTempFunction,
                                   clsNewGlobalAesFunc:=clsRaesFunction, clsNewLocalAes:=clsLocalRaesFunction,
                                   bFixGeom:=True, ucrNewBaseSelector:=ucrSelectorForScatter, bApplyAesGlobally:=True,
                                   bReset:=bResetlayerSubdialog)
        'Coming from the sdgLayerOptions, clsRaesFunction and others has been modified. One then needs to display these modifications on the dlgScatteredPlot.
        sdgLayerOptions.ShowDialog()
        ucrReceiverLabel.SetRCode(clsRaesFunction, bReset)
        bResetlayerSubdialog = False
        'The aesthetics parameters on the main dialog are repopulated as required.
        For Each clsParam In clsRaesFunction.clsParameters
            Select Case clsParam.strArgumentName
                Case "x"
                    If clsParam.strArgumentValue = Chr(34) & Chr(34) Then
                        ucrReceiverX.Clear()
                    Else
                        ucrReceiverX.Add(clsParam.strArgumentValue)
                    End If
                Case "y"
                    ' If we are in multiple variables mode and 'y = value', 
                    '     then we should not write 'value' to the multiple variables receiver
                    If Not ucrVariablesAsFactorForScatter.bSingleVariable _
                            AndAlso clsParam.strArgumentValue Is "value" Then
                        Exit Select
                    End If

                    If clsParam.strArgumentValue = (Chr(34) & Chr(34)) Then
                        ucrVariablesAsFactorForScatter.Clear()
                    Else
                        ucrVariablesAsFactorForScatter.Add(clsParam.strArgumentValue)
                    End If
                Case "colour"
                    ucrFactorOptionalReceiver.Add(clsParam.strArgumentValue)
            End Select
        Next
    End Sub

    Private Sub ucrSaveScatterPlot_ContentsChanged() Handles ucrSaveScatterPlot.ControlContentsChanged,
        ucrReceiverX.ControlContentsChanged, ucrVariablesAsFactorForScatter.ControlContentsChanged, ucrSaveScatterPlot.ControlContentsChanged
        TestOkEnabled()
    End Sub

    Private Sub ucrReceiverLabel_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrReceiverLabel.ControlValueChanged
        If ucrReceiverLabel.IsEmpty Then
            clsBaseOperator.RemoveParameterByName(strGeomTextRepelParameterName)
        Else
            clsBaseOperator.AddParameter(strGeomTextRepelParameterName, clsRFunctionParameter:=clsLabelFunction, iPosition:=3)
        End If
        toolStripMenuItemTextrepelOptions.Enabled = Not ucrReceiverLabel.IsEmpty
    End Sub
End Class
