Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Localization
Imports System.Drawing
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors

Namespace LinqServerMode
	Public Class MyGridView
		Inherits DevExpress.XtraGrid.Views.Grid.GridView
		Private lastError As String = String.Empty

		Public Sub New()
			Me.New(Nothing)
		End Sub
		Public Sub New(ByVal grid As DevExpress.XtraGrid.GridControl)
			MyBase.New(grid)
		End Sub

		Protected Overrides ReadOnly Property ViewName() As String
			Get
				Return "MyGridView"
			End Get
		End Property

		Protected Overrides Sub CheckDataControllerError()
			' show a tooltip
			ShowDataControllerError()
		End Sub

		Protected Overrides Sub OnDataControllerError(ByVal lastError As String)
			'additional code
		   ' XtraMessageBox.Show(lastError);
		End Sub

		Protected Shadows Sub ShowDataControllerError()
			If GridControl Is Nothing OrElse (Not GridControl.IsHandleCreated) Then
				Return
			End If
			If lastError <> DataController.LastErrorText Then
				lastError = DataController.LastErrorText
				If (Not String.IsNullOrEmpty(lastError)) Then
					OnDataControllerError(lastError)
				End If
			End If
			If DataController.LastErrorText = "" Then
				If GridControl.EditorHelper.RealToolTipController.ActiveObject Is Nothing Then
					HideHint()
				End If
				Return
			End If

			Dim ee As New ToolTipControllerShowEventArgs()
			ee.AutoHide = False
			ee.Title = "Error"
			ee.ToolTipLocation = ToolTipLocation.RightTop
			'set an exception text here
			ee.ToolTip = String.Format(GridLocalizer.Active.GetLocalizedString(GridStringId.ServerRequestError), DataController.LastErrorText)
			ee.ToolTipType = ToolTipType.SuperTip
			ee.IconType = ToolTipIconType.Error
			ee.IconSize = ToolTipIconSize.Small
			ToolTipController.DefaultController.ShowHint(ee, GridControl.PointToScreen(New Point(ViewRect.Left, ViewRect.Bottom)))
			lastError = DataController.LastErrorText
		End Sub

		Public Shadows Property GridControl() As MyGridControl
			Get
				Return TryCast(MyBase.GridControl, MyGridControl)
			End Get
			Set(ByVal value As MyGridControl)
				MyBase.GridControl = value
			End Set
		End Property
	End Class
End Namespace
