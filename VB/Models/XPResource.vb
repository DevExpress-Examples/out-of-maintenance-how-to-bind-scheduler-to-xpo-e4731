Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Xml

Public Class XPResource
	Inherits XPObject
	Public Sub New(ByVal session As Session)
		MyBase.New(session)
	End Sub

	<Size(SizeAttribute.Unlimited)> _
	Public Name As String ' Resource.Caption

	<Association()> _
	Public ReadOnly Property Appointments() As XPCollection(Of XPAppointment)
		Get
			Return GetCollection(Of XPAppointment)("Appointments")
		End Get
	End Property
End Class