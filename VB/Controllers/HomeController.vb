Imports Microsoft.VisualBasic
Imports System.Linq
Imports System.Web.Mvc
Imports System.Collections
Imports DevExpress.Web.Mvc
Imports DevExpress.Xpo

Namespace SchedulerBindXPOMvc
	Public Class HomeController
		Inherits BaseXpoController(Of XPAppointment)
		Public Function Index() As ActionResult
			Return View(DataObject)
		End Function

		Public Function SchedulerPartial() As ActionResult
			Return PartialView("SchedulerPartial", DataObject)
		End Function

		<HttpPost> _
		Public Function EditAppointment() As ActionResult
			UpdateAppointment()
			Return PartialView("SchedulerPartial", DataObject)
		End Function

		Private Sub UpdateAppointment()
			Dim insertedAppt As XPAppointmentViewModel = SchedulerExtension.GetAppointmentToInsert(Of XPAppointmentViewModel)(SchedulerHelper.Settings, GetAppointments(), GetResources())

			If insertedAppt IsNot Nothing Then
				Save(insertedAppt)
			End If

			Dim updatedAppt() As XPAppointmentViewModel = SchedulerExtension.GetAppointmentsToUpdate(Of XPAppointmentViewModel)(SchedulerHelper.Settings, GetAppointments(), GetResources())

			For Each appt In updatedAppt
				Save(appt)
			Next appt

			Dim removedAppt() As XPAppointmentViewModel = SchedulerExtension.GetAppointmentsToRemove(Of XPAppointmentViewModel)(SchedulerHelper.Settings, GetAppointments(), GetResources())

			For Each appt In removedAppt
				Delete(appt)
			Next appt
		End Sub

		Public ReadOnly Property DataObject() As SchedulerDataObject
			Get
				Return New SchedulerDataObject() With {.Appointments = GetAppointments(), .Resources = GetResources()}
			End Get
		End Property

		Public Function GetResources() As IEnumerable
			Return ( _
					From r In XpoSession.Query(Of XPResource)().ToList() _
					Select New XPResourceViewModel() With {.ID = r.Oid, .Name = r.Name}).ToList()
		End Function

		Public Function GetAppointments() As IEnumerable
			Return ( _
					From a In XpoSession.Query(Of XPAppointment)().ToList() _
					Select New XPAppointmentViewModel() With {.ID = a.Oid, .Subject = a.Subject, .Created= a.Created, .Finish = a.Finish, .AllDay = a.AllDay, .Location = a.Location, .Description = a.Description, .Label = a.Label, .Status = a.Status, .ResourceIds = a.ResourceIds, .Recurrence = a.Recurrence, .AppointmentType = a.AppointmentType, .Reminder = a.Reminder}).ToList()
		End Function
	End Class
End Namespace