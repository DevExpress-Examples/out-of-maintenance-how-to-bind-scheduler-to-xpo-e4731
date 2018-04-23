Imports Microsoft.VisualBasic
Imports System

Public Class XPAppointmentViewModel
	Inherits BaseViewModel(Of XPAppointment)
	Private privateSubject As String
	Public Property Subject() As String
		Get
			Return privateSubject
		End Get
		Set(ByVal value As String)
			privateSubject = value
		End Set
	End Property
	Private privateCreated As DateTime
	Public Property Created() As DateTime
		Get
			Return privateCreated
		End Get
		Set(ByVal value As DateTime)
			privateCreated = value
		End Set
	End Property
	Private privateFinish As DateTime
	Public Property Finish() As DateTime
		Get
			Return privateFinish
		End Get
		Set(ByVal value As DateTime)
			privateFinish = value
		End Set
	End Property
	Private privateAllDay As Boolean
	Public Property AllDay() As Boolean
		Get
			Return privateAllDay
		End Get
		Set(ByVal value As Boolean)
			privateAllDay = value
		End Set
	End Property
	Private privateLocation As String
	Public Property Location() As String
		Get
			Return privateLocation
		End Get
		Set(ByVal value As String)
			privateLocation = value
		End Set
	End Property
	Private privateDescription As String
	Public Property Description() As String
		Get
			Return privateDescription
		End Get
		Set(ByVal value As String)
			privateDescription = value
		End Set
	End Property
	Private privateResourceIds As String
	Public Property ResourceIds() As String
		Get
			Return privateResourceIds
		End Get
		Set(ByVal value As String)
			privateResourceIds = value
		End Set
	End Property
	Private privateLabel As Integer
	Public Property Label() As Integer
		Get
			Return privateLabel
		End Get
		Set(ByVal value As Integer)
			privateLabel = value
		End Set
	End Property
	Private privateStatus As Integer
	Public Property Status() As Integer
		Get
			Return privateStatus
		End Get
		Set(ByVal value As Integer)
			privateStatus = value
		End Set
	End Property
	Private privateRecurrence As String
	Public Property Recurrence() As String
		Get
			Return privateRecurrence
		End Get
		Set(ByVal value As String)
			privateRecurrence = value
		End Set
	End Property
	Private privateAppointmentType As Integer
	Public Property AppointmentType() As Integer
		Get
			Return privateAppointmentType
		End Get
		Set(ByVal value As Integer)
			privateAppointmentType = value
		End Set
	End Property
	Private privateReminder As String
	Public Property Reminder() As String
		Get
			Return privateReminder
		End Get
		Set(ByVal value As String)
			privateReminder = value
		End Set
	End Property

	Public Overrides Sub GetData(ByVal model As XPAppointment)
		model.Subject = Subject
		model.Created = Created
		model.Finish = Finish
		model.AllDay = AllDay
		model.Location = Location
		model.Description = Description
		model.Label = Label
		model.Status = Status
		model.ResourceIds = ResourceIds
		model.Recurrence = Recurrence
		model.AppointmentType = AppointmentType
		model.Reminder = Reminder
	End Sub
End Class