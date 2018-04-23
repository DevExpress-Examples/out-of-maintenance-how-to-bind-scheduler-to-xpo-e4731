Imports Microsoft.VisualBasic
Imports System
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports DevExpress.XtraScheduler

Namespace SchedulerBindXPOMvc
	Public Module SchedulerHelper
        Private settings_Renamed As SchedulerSettings

        Public ReadOnly Property Settings() As SchedulerSettings
            Get
                If settings_Renamed Is Nothing Then
                    settings_Renamed = CreateSchedulerSettings(Nothing)
                End If
                Return settings_Renamed
            End Get
        End Property

        <System.Runtime.CompilerServices.Extension()> _
        Public Function CreateSchedulerSettings(ByVal htmlHelper As HtmlHelper) As SchedulerSettings
            Dim settings As New SchedulerSettings()
            settings.Name = "scheduler"
            settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "SchedulerPartial"}
            settings.EditAppointmentRouteValues = New With {Key .Controller = "Home", Key .Action = "EditAppointment"}

            settings.Storage.Appointments.Assign(DefaultAppointmentStorage)
            settings.Storage.Resources.Assign(DefaultResourceStorage)

            settings.GroupType = SchedulerGroupType.Resource
            settings.Storage.Appointments.ResourceSharing = True
            settings.Start = New DateTime(2008, 7, 11)
            Return settings
        End Function

        Private defaultAppointmentStorage_Renamed As MVCxAppointmentStorage
        Public ReadOnly Property DefaultAppointmentStorage() As MVCxAppointmentStorage
            Get
                If defaultAppointmentStorage_Renamed Is Nothing Then
                    defaultAppointmentStorage_Renamed = CreateDefaultAppointmentStorage()
                End If
                Return defaultAppointmentStorage_Renamed
            End Get
        End Property
        Private Function CreateDefaultAppointmentStorage() As MVCxAppointmentStorage
            Dim appointmentStorage As New MVCxAppointmentStorage()

            appointmentStorage.Mappings.AppointmentId = "ID"
            appointmentStorage.Mappings.Subject = "Subject"
            appointmentStorage.Mappings.Start = "Created"
            appointmentStorage.Mappings.End = "Finish"
            appointmentStorage.Mappings.AllDay = "AllDay"
            appointmentStorage.Mappings.Location = "Location"
            appointmentStorage.Mappings.Description = "Description"
            appointmentStorage.Mappings.Label = "Label"
            appointmentStorage.Mappings.Status = "Status"
            appointmentStorage.Mappings.ResourceId = "ResourceIds"
            appointmentStorage.Mappings.RecurrenceInfo = "Recurrence"
            appointmentStorage.Mappings.Type = "AppointmentType"
            appointmentStorage.Mappings.ReminderInfo = "Reminder"

            Return appointmentStorage
        End Function

        Private defaultResourceStorage_Renamed As MVCxResourceStorage
        Public ReadOnly Property DefaultResourceStorage() As MVCxResourceStorage
            Get
                If defaultResourceStorage_Renamed Is Nothing Then
                    defaultResourceStorage_Renamed = CreateDefaultResourceStorage()
                End If
                Return defaultResourceStorage_Renamed
            End Get
        End Property
        Private Function CreateDefaultResourceStorage() As MVCxResourceStorage
            Dim resourceStorage As New MVCxResourceStorage()

            resourceStorage.Mappings.ResourceId = "ID"
            resourceStorage.Mappings.Caption = "Name"

            Return resourceStorage
        End Function
	End Module
End Namespace