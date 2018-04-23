Imports Microsoft.VisualBasic
Imports System.Collections

Namespace SchedulerBindXPOMvc
	Public Class SchedulerDataObject
		Private privateAppointments As IEnumerable
		Public Property Appointments() As IEnumerable
			Get
				Return privateAppointments
			End Get
			Set(ByVal value As IEnumerable)
				privateAppointments = value
			End Set
		End Property
		Private privateResources As IEnumerable
		Public Property Resources() As IEnumerable
			Get
				Return privateResources
			End Get
			Set(ByVal value As IEnumerable)
				privateResources = value
			End Set
		End Property
	End Class
End Namespace