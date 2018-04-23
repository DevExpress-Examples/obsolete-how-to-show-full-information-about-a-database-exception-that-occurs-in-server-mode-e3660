Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Data.Linq
Imports DevExpress.XtraEditors

Namespace LinqServerMode
	Partial Public Class Main
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()

			linqInstantFeedbackSource.KeyExpression = "SupplierID"
			gridControl1.DataSource = linqInstantFeedbackSource
		End Sub


		Private Sub OnGetQueryable(ByVal sender As Object, ByVal e As GetQueryableEventArgs) Handles linqInstantFeedbackSource.GetQueryable
			Dim dt As New NorthwindClassesDataContext()
			e.QueryableSource = dt.Suppliers
			e.Tag = dt
		End Sub

		Private Sub OnDismissQueryable(ByVal sender As Object, ByVal e As GetQueryableEventArgs) Handles linqInstantFeedbackSource.DismissQueryable
			TryCast(e.Tag, NorthwindClassesDataContext).Dispose()
		End Sub
	End Class
End Namespace
